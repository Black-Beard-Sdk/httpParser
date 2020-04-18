//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from HtmlPatternParser.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Bb.Sdk.HttpParser.Grammar.Generated {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="HtmlPatternParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public interface IHtmlPatternParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.script"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScript([NotNull] HtmlPatternParser.ScriptContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.unit_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnit_statement([NotNull] HtmlPatternParser.Unit_statementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.using"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUsing([NotNull] HtmlPatternParser.UsingContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.search"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSearch([NotNull] HtmlPatternParser.SearchContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.output"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOutput([NotNull] HtmlPatternParser.OutputContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.select"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSelect([NotNull] HtmlPatternParser.SelectContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] HtmlPatternParser.TypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.attribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAttribute([NotNull] HtmlPatternParser.AttributeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.pagination"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPagination([NotNull] HtmlPatternParser.PaginationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.count"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCount([NotNull] HtmlPatternParser.CountContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction([NotNull] HtmlPatternParser.FunctionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.arguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArguments([NotNull] HtmlPatternParser.ArgumentsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.argument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgument([NotNull] HtmlPatternParser.ArgumentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.key"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitKey([NotNull] HtmlPatternParser.KeyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.numbers"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumbers([NotNull] HtmlPatternParser.NumbersContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="HtmlPatternParser.text"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitText([NotNull] HtmlPatternParser.TextContext context);
}
} // namespace Bb.Sdk.HttpParser.Grammar.Generated