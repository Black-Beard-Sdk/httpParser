using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Bb.Sdk.HttpParser.Blocks;
using Bb.Sdk.HttpParser.Grammar.Generated;

namespace Bb.Sdk.HttpParser.Grammar
{

    public class TranslateConfigVisitor : HtmlPatternParserBaseVisitor<object>
    {

        public TranslateConfigVisitor()
        {
        }

        public string Filename { get; set; }

        public void SetText(StringBuilder sb)
        {
            this._initialSource = sb;
        }

        public void EvaluateErrors(IParseTree item)
        {

            if (item != null)
            {

                if (item is ErrorNodeImpl e)
                    this._errors.Add(

                        new ErrorModel($"Failed to parse script at position {e.Symbol.StartIndex}, line {e.Symbol.Line}, col {e.Symbol.Column} ' {e.Symbol.Text}'"
                        , e.Symbol.StartIndex
                        , e.Symbol.Line
                        ));

                int c = item.ChildCount;
                for (int i = 0; i < c; i++)
                {
                    IParseTree child = item.GetChild(i);
                    EvaluateErrors(child);
                }

            }

        }

        public IEnumerable<ErrorModel> Errors { get => this._errors; }

        public override object Visit(IParseTree tree)
        {
            this._errors = new List<ErrorModel>();
            EvaluateErrors(tree);

            return base.Visit(tree);

        }

        public override object VisitErrorNode(IErrorNode node)
        {
            Stop();
            return base.VisitErrorNode(node);
        }

        /// <summary>
        /// script :
        ///     using*
        ///     (unit_statement SEMICOLON) * EOF
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitScript([NotNull] HtmlPatternParser.ScriptContext context)
        {

            BlockList list = new BlockList();

            List<MethodInfo> methods = new List<MethodInfo>();

            methods.AddRange(GetMethods(typeof(string)));
            var usings = context.@using();
            if (usings != null)
            {
                foreach (var u in usings)
                {
                    var us = (Type)VisitUsing(u);
                    methods.AddRange(GetMethods(us));
                }
            }

            _Methods = methods.ToLookup(c => c.Name);

            var array = context.unit_statement();
            if (array != null)
            {
                foreach (var item in array)
                {
                    var result = (Block)VisitUnit_statement(item);
                    list.Add(result);
                }
            }

            return list;
        }

        private IEnumerable<MethodInfo> GetMethods(Type type)
        {

            if (type != null)
            {
                var m = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).ToList();
                return m;
            }

            return new MethodInfo[] { };
        }

        public override object VisitUsing([NotNull] HtmlPatternParser.UsingContext context)
        {

            var txt = context.text().GetText().Trim('\'');
            if (!string.IsNullOrEmpty(txt))
            {

                try
                {
                    return Type.GetType(txt);
                }
                catch (Exception)
                {
                    this._errors.Add(new ErrorModel(
                        $"type {txt} can't be loaded",
                        context.text().Start.StartIndex,
                        context.text().Start.Line
                        ));
                }

            }

            return null;
        }

        /// <summary>
        ///     SEARCH (SUB numbers)? NODE text (PIPE text)* pagination output? LEFT_PAREN (search | select)* RIGHT_PAREN
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitSearch([NotNull] HtmlPatternParser.SearchContext context)
        {

            var pagination = ((int, int))VisitPagination(context.pagination());
            List<string> _textMatchings = new List<string>();
            var texts = context.text();
            if (texts != null)
                foreach (var txt in texts)
                    _textMatchings.Add(((string)VisitText(txt)).Replace("\"", "'"));

            List<Block> results = new List<Block>();

            var searchs = context.search();
            if (searchs != null)
                foreach (var search in searchs)
                    results.Add((Block)VisitSearch(search));

            var selects = context.select();
            if (selects != null)
                foreach (var select in selects)
                    results.Add((Block)VisitSelect(select));

            int countSubNumber = 0;
            if (context.SUB() != null)
                countSubNumber = (int)VisitNumbers(context.numbers());

            var result = new BlockSearch()
            {
                Order = context.Start.StartIndex,
                Skip = pagination.Item1,
                Limit = pagination.Item2,
                SearchInSub = countSubNumber,
            };
            result.Matchings.AddRange(_textMatchings);

            var o = context.output();
            if (o != null)
            {
                var result2 = (OutputBlock)VisitOutput(o);
                result2.Subs.AddRange(results.OrderBy(c => c.Order));
                result.Subs.Add(result2);
            }
            else
                result.Subs.AddRange(results.OrderBy(c => c.Order));

            return result;

        }

        /// <summary>
        /// output : 
        ///     AS NEW
        ///     (
        ///         OBJECT
        ///       | ARRAY
        ///       | PROPERTY text COLON
        ///     )
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitOutput([NotNull] HtmlPatternParser.OutputContext context)
        {

            OutputKind output = OutputKind.Undefined;
            string propertyName = string.Empty;

            if (context.ARRAY() != null)
                output = OutputKind.Array;

            else if (context.OBJECT() != null)
                output = OutputKind.Object;

            else if (context.PROPERTY() != null)
            {
                output = OutputKind.Property;
                propertyName = (string)VisitText(context.text());
            }

            var result = new OutputBlock()
            {
                Order = context.Start.StartIndex,
                ObjectKind = output,
                PropertyName = propertyName,
            };

            return result;

        }

        /// <summary>
        /// select : 
        ///     (text | variable) COLON (AS type)? selectItem (LEFT_PAREN search RIGHT_PAREN)*
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitSelect([NotNull] HtmlPatternParser.SelectContext context)
        {

            string label;
            bool isVariable = false;

            var txt = context.text();

            if (txt != null)
                label = (string)VisitText(txt);
            else
            {
                isVariable = true;
                label = (string)VisitVariable(context.variable());
            }

            //(int, int) pagination = (1, -1);

            //var p = context.pagination();
            //if (p != null)
            //    pagination = ((int, int))VisitPagination(p);

            Block function = null;
            List<Block> results = new List<Block>();
            var i = context.selectItem();
            if (i != null)
                function = (Block)VisitSelectItem(i);

            TypeEnum type = TypeEnum.String;
            if (context.AS() != null)
            {
                var _type = context.type();
                if (_type != null)
                    type = (TypeEnum)VisitType(_type);
            }

            var searchs = context.search();
            if (searchs != null)
                foreach (var search in searchs)
                    results.Add((Block)VisitSearch(search));

            var result = new SelectBlock()
            {
                Order = context.Start.StartIndex,
                Label = label,
                //Skip = pagination.Item1,
                //Limit = pagination.Item2,
                Function = function,
                IsVariable = isVariable,
                Type = type,
            };

            result.Subs.AddRange(results.OrderBy(c => c.Order));

            return result;

        }

        /// <summary>
        /// selectItem : SELECT (attribute | HTML | TEXT | text | numbers | float | boolean | variable) function?;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitSelectItem([NotNull] HtmlPatternParser.SelectItemContext context)
        {

            SubsBlock function;

            var t2 = context.attribute();
            if (t2 != null)
            {
                var attributeName = (string)VisitAttribute(t2);
                function = new ReadAttributeBlock() { Name = attributeName };
            }
            else
            {

                var text = context.text();
                if (text != null)
                {
                    function = new ReadConstantBlock()
                    {
                        Order = text.Start.StartIndex,
                        Value = VisitText(text),
                    };
                }
                else
                {
                    var integers = context.numbers();
                    if (integers != null)
                    {
                        function = new ReadConstantBlock()
                        {
                            Order = integers.Start.StartIndex,
                            Value = VisitNumbers(integers),
                        };
                    }
                    else
                    {
                        var floats = context.@float();
                        if (floats != null)
                        {
                            function = new ReadConstantBlock()
                            {
                                Order = floats.Start.StartIndex,
                                Value = VisitFloat(floats),
                            };
                        }
                        else
                        {
                            var booleans = context.boolean();
                            if (booleans != null)
                            {
                                function = new ReadConstantBlock()
                                {
                                    Order = booleans.Start.StartIndex,
                                    Value = VisitBoolean(booleans),
                                };
                            }
                            else
                            {
                                var variables = context.variable();
                                if (variables != null)
                                {
                                    function = new ReadVariableBlock()
                                    {
                                        Order = variables.Start.StartIndex,
                                        Name = (string)VisitVariable(variables),
                                    };
                                }
                                else
                                {
                                    function = new ReadInnerTextBlock()
                                    {
                                        Html = context.HTML() != null,
                                        Text = context.TEXT() != null,
                                    };
                                }
                            }

                        }
                    }
                }
            }

            var f = context.function();
            if (f != null)
                function.Sub = (CallFunctionBlock)VisitFunction(f);

            return function;

        }

        /// <summary>
        /// float : numbers DOT numbers;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitFloat([NotNull] HtmlPatternParser.FloatContext context)
        {

            var txt = context.GetText();

            if (float.TryParse(txt, out float f))
                return f;

            return 0f;

        }

        public override object VisitBoolean([NotNull] HtmlPatternParser.BooleanContext context)
        {
            var txt = context.GetText();
            return txt == "true";
        }

        /// <summary>
        /// type : STRING | DECIMAL | INTEGER | DATE | UUID;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitType([NotNull] HtmlPatternParser.TypeContext context)
        {

            if (context == null)
                return TypeEnum.String;

            var typeTxt = context.GetText().ToUpper();

            switch (typeTxt)
            {

                case "STRING":
                    return TypeEnum.String;

                case "DECIMAL":
                    return TypeEnum.Decimal;

                case "INTEGER":
                    return TypeEnum.Integer;

                case "DATE":
                    return TypeEnum.Date;

                case "UUID":
                    return TypeEnum.Uuid;

                case "BOOLEAN":
                    return TypeEnum.Boolean;

                default:
                    break;
            }

            return TypeEnum.String;

        }

        /// <summary>
        /// ATTRIBUTE text
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitAttribute([NotNull] HtmlPatternParser.AttributeContext context)
        {
            return VisitText(context.text());
        }

        /// <summary>
        /// text : CHAR_STRING;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitText([NotNull] HtmlPatternParser.TextContext context)
        {
            if (context != null)
            {
                var result = context.GetText();
                return result.Trim('\'');
            }

            return string.Empty;
        }

        /// <summary>
        /// unit_statement : 
        ///     search
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitUnit_statement([NotNull] HtmlPatternParser.Unit_statementContext context)
        {
            return VisitSearch(context.search());
        }

        /// <summary>
        /// function : key LEFT_PAREN arguments? RIGHT_PAREN (PIPE function)?;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitFunction([NotNull] HtmlPatternParser.FunctionContext context)
        {

            var k = context.key();
            var functionName = (string)VisitKey(k);
            var result = new CallFunctionBlock()
            {
                Name = functionName,
            };

            var a = context.arguments();
            if (a != null)
                result.Arguments.AddRange((List<object>)VisitArguments(a));

            var types = result.Arguments.Select(c => c.GetType()).ToList();

            var m = _Methods[functionName]
                .Where(c => EvaluateMethodParameters(c, types))
                .ToList();

            if (m.Count == 0)
            {
                this._errors.Add(new ErrorModel(
                        $"no method called {functionName} has been found",
                        k.Start.StartIndex,
                        k.Start.Line
                        ));
            }
            else
            {
                foreach (var item in m)
                {
                    try
                    {
                        Expression<Func<object, object>> lambda = GetMethod(result, item);
                        result.Method = lambda.Compile();
                        break;
                    }
                    catch (Exception)
                    {
                        this._errors.Add(new ErrorModel(
                            $"method called {functionName} can't be compiled",
                            k.Start.StartIndex,
                            k.Start.Line
                        ));
                    }

                }

                var f = context.function();
                if (f != null)
                    result.Sub = (CallFunctionBlock)VisitFunction(f);

            }

            return result;

        }

        private static Expression<Func<object, object>> GetMethod(CallFunctionBlock result, MethodInfo item)
        {
            ParameterInfo[] paramsInfo = item.GetParameters();
            ParameterExpression param = Expression.Parameter(typeof(object), "arg");
            MethodCallExpression newExp;

            List<Expression> args = new List<Expression>();

            int ii = 0;
            if (item.IsStatic)
            {
                var ar = paramsInfo[0];
                args.Add(Expression.Convert(param, ar.ParameterType));
                ii = 1;
            }

            for (int i = ii; i < paramsInfo.Length; i++)
            {
                var ar = result.Arguments[i - ii];
                args.Add(Expression.Constant(ar));
            }

            Expression pa2 = param;
            if (item.DeclaringType != param.Type)
                pa2 = Expression.Convert(param, item.DeclaringType);

            if (item.IsStatic)
                newExp = Expression.Call(item, args.ToArray());
            else
                newExp = Expression.Call(pa2, item, args.ToArray());

            Expression<Func<object, object>> lambda = Expression.Lambda<Func<object, object>>(newExp, param);
            return lambda;
        }

        private static bool EvaluateMethodParameters(MethodInfo item, List<Type> parameters)
        {

            if (parameters != null)
            {
                var _parameters = item.GetParameters();

                if (item.IsStatic)
                {
                    if (_parameters.Length != parameters.Count + 1)
                        return false;

                    for (var i = 1; i < parameters.Count; i++)
                    {
                        var _p1 = _parameters[i];
                        var _p2 = parameters[i];
                        if (_p1.ParameterType != _p2)
                            return false;
                    }

                }
                else
                {
                    if (_parameters.Length != parameters.Count)
                        return false;

                    for (var i = 0; i < parameters.Count; i++)
                    {
                        var _p1 = _parameters[i];
                        var _p2 = parameters[i];
                        if (_p1.ParameterType != _p2)
                            return false;
                    }
                }

            }

            return true;

        }

        public override object VisitArguments([NotNull] HtmlPatternParser.ArgumentsContext context)
        {

            List<object> argList = new List<object>();
            var args = context.argument();
            foreach (HtmlPatternParser.ArgumentContext arg in args)
            {
                var a = VisitArgument(arg);
                argList.Add(a);
            }

            return argList;

        }

        /// <summary>
        /// numbers | text;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitArgument([NotNull] HtmlPatternParser.ArgumentContext context)
        {

            var n = context.numbers();
            if (n != null)
            {
                var c = n.GetText();
                if (int.TryParse(c, out int i))
                    return i;
            }

            return VisitText(context.text());

        }

        /// <summary>
        /// variable : DOLLAR key;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitVariable([NotNull] HtmlPatternParser.VariableContext context)
        {
            return context.GetText();
        }

        /// <summary>
        /// REGULAR_ID
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitKey([NotNull] HtmlPatternParser.KeyContext context)
        {
            return context.GetText();
        }

        /// <summary>
        /// numbers : NUMBER*;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitNumbers([NotNull] HtmlPatternParser.NumbersContext context)
        {
            if (context != null)
            {
                var c = context.GetText();

                if (int.TryParse(c, out int i))
                    return i;

            }
            return 0;

        }

        /// <summary>
        /// pagination : 
        ///     (FROM c1=count)? (TOP c2=count)? 
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitPagination([NotNull] HtmlPatternParser.PaginationContext context)
        {

            int _skip = 0;
            int _top = 0;

            if (context != null)
            {
                // from
                if (context.c1 != null)
                {
                    _skip = (int)VisitCount(context.c1);
                    if (_skip < 0)
                        _skip = 0;
                }

                // top
                if (context.c2 != null)
                    _top = (int)VisitCount(context.c2);

            }

            (int, int) i = (_skip, _top);

            return i;
        }


        /// <summary>
        /// count : 
        ///     (NUMBER | WILDCARD)
        ///     ;
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override object VisitCount([NotNull] HtmlPatternParser.CountContext context)
        {

            if (context.WILDCARD() != null)
                return 01;

            else
                return VisitNumbers(context.numbers());

        }

        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.DebuggerNonUserCode]
        private void Stop()
        {
            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Debugger.Break();
        }

        private StringBuilder GetText(RuleContext context)
        {

            if (context is ParserRuleContext s)
                return GetText(s.Start.StartIndex, s.Stop.StopIndex + 1);
            return new StringBuilder();
        }

        private StringBuilder GetText(int startIndex, int stopIndex)
        {

            int length = stopIndex - startIndex;

            length++;

            StringBuilder sb2 = new StringBuilder(length);
            char[] ar = new char[length];
            _initialSource.CopyTo(startIndex, ar, 0, length);
            sb2.Append(ar);

            return sb2;

        }

        private StringBuilder _initialSource;
        private List<ErrorModel> _errors;
        private ILookup<string, MethodInfo> _Methods;
    }

}
