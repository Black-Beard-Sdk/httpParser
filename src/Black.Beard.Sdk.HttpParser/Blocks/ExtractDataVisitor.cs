using Bb.Sdk.HttpParser.Grammar;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Bb.Sdk.HttpParser.Blocks
{


    public class ExtractDataVisitor : IBlockVisitor
    {

        public ExtractDataVisitor(BlockList config)
        {
            this._config = config;
        }

        public JToken Run(StringBuilder plain)
        {

            //var lines = plain.ToString().Split('\n');
            //int oldPosition = 0;
            //this._indexes = new List<int>();
            //foreach (var line in lines)
            //{
            //    _indexes.Add(oldPosition);
            //    oldPosition += line.Length + 1;
            //}

            this._config.Accept(this, plain);

            return this.Output;

        }

        public void VisitList(BlockList b, StringBuilder plain)
        {

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(plain.ToString());

            var items = new List<JToken>();

            foreach (var block in this._config)
            {
                var ctx = new Context() { HtmlDoc = htmlDoc.DocumentNode };
                block.Accept(this, ctx);

                var o = ctx.Outputs.ToList();

                if (o.Count == 1)
                    items.Add(o[0]);
                else
                    foreach (var item in o)
                        items.AddRange(item);
            }

            if (items.Count == 1)
                this.Output = items[0];

            else
            {

            }

        }

        public void VisitSearch(BlockSearch b, Context context)
        {

            List<HtmlNode> nodeList1 = new List<HtmlNode>();
            FoundHtmlNode parent;

            if (context.Datas.Count > 0)
            {

                parent = context.Datas.Peek();
                nodeList1 = SearchNodes(b, parent.Tag);

                var n = new FoundHtmlNode() { Message = b.ToString() + $" -> {nodeList1.Count}", SearchNode = true, Parent = parent.Id };
                if (Selected != null)
                    this.Selected(n);

                Loop(b, context, nodeList1, n);

            }
            else
            {
                nodeList1 = SearchNodes(b, context.HtmlDoc);

                parent = new FoundHtmlNode() { Message = b.ToString() + $" -> {nodeList1.Count}", SearchNode = true, };
                if (Selected != null)
                    this.Selected(parent);

                Loop(b, context, nodeList1, parent);

            }

        }

        private void Loop(BlockSearch b, Context context, List<HtmlNode> l1, FoundHtmlNode parent)
        {
            foreach (var item in l1)
            {

                FoundHtmlNode node = CreateSearchNode(parent, item);

                if (b.Subs.Count > 0)
                {

                    context.Datas.Push(node);

                    try
                    {
                        foreach (var sub in b.Subs)
                            sub.Accept(this, context);
                    }
                    finally
                    {
                        context.Datas.Pop();
                    }
                }

            }
        }

        private List<HtmlNode> SearchNodes(BlockSearch b, HtmlNode tag)
        {

            List<HtmlNode> listResult = new List<HtmlNode>();

            foreach (var matching in b.Matchings)
                foreach (HtmlNode item in SearchSubNodes(tag, matching, b.SearchInSub))
                    listResult.Add(item);

            if (b.Skip > 0)
                listResult = listResult.Skip(b.Skip).ToList();

            if (b.Limit > 0)
                listResult = listResult.Take(b.Limit).ToList();

            return listResult;

        }

        private IEnumerable<HtmlNode> SearchSubNodes(HtmlNode tag, string matching, int sub)
        {

            List<HtmlNode> list = new List<HtmlNode>();

            try
            {
                var c = tag.SelectNodes(matching);
                if (c != null)
                    list.AddRange(c.ToList());

            }
            catch (System.Xml.XPath.XPathException) // Bad matching
            {
                if (this.Error != null)
                    Error(
                        new ErrorModel(
                            $"Xpath {matching} is invalid",
                            0,
                            0
                            )
                        );
            }

            if (list.Count > 0)
                foreach (var item in list)
                    yield return item;

            else if (sub > 0)
                foreach (var item in tag.Descendants())
                    foreach (var item2 in SearchSubNodes(item, matching, --sub))
                        yield return item2;


        }

        private FoundHtmlNode CreateSearchNode(FoundHtmlNode parent, HtmlNode item)
        {
            var node = new FoundHtmlNode()
            {
                Message = item.Name,
                Tag = item,
                Parent = parent.Id,
                //IndexStart = _indexes[item.Line] + item.LinePosition,
                ResultNode = true,
            };

            node.IndexLength = item.OuterHtml.Length;

            if (Selected != null)
                this.Selected(node);

            return node;
        }

        public void VisitObject(OutputBlock b, Context context)
        {

            if (b.Subs.Count > 0)
            {

                List<JToken> items = new List<JToken>();
                context.Results.Push(items);

                try
                {
                    foreach (var sub in b.Subs)
                        sub.Accept(this, context);
                }
                finally
                {
                    context.Results.Pop();
                }

                var parent = context.Datas.Peek();

                if (b.ObjectKind == OutputKind.Object)
                    BuildObject(context, items, parent);

                else if (b.ObjectKind == OutputKind.Array)
                    BuildArray(context, items, parent);

                else if (b.ObjectKind == OutputKind.Property)
                    BuildProperty(b, context, items, parent);

            }

        }

        private void BuildProperty(OutputBlock b, Context context, List<JToken> items, FoundHtmlNode parent)
        {
            JToken value = null;

            if (items.Count > 1)
            {
                var y = new JArray();
                foreach (var item in items)
                    y.Add(item);
                value = y;
            }
            else if (items.Count == 1)
                value = items[0];

            JProperty result = new JProperty(b.PropertyName, value);

            PushOutput("new property " + b.PropertyName, context, parent, result);
        }

        private void BuildArray(Context context, List<JToken> items, FoundHtmlNode parent)
        {
            JArray result = new JArray();
            foreach (JObject item in items)
                result.Add(item);
            PushOutput("new array ", context, parent, result);
        }

        private void BuildObject(Context context, List<JToken> items, FoundHtmlNode parent)
        {
            JObject result = new JObject();
            foreach (JProperty item in items)
                result.Add(item);
            PushOutput("new object ", context, parent, result);
        }

        private void PushOutput(string message, Context context, FoundHtmlNode parent, JToken result)
        {
            var n = new FoundHtmlNode() { Message = message, ObjectNode = true, Parent = parent.Id, Tag2 = result, Tooltip = result.ToString(Newtonsoft.Json.Formatting.None) };
            if (Selected != null)
                this.Selected(n);

            if (context.Results.Count > 0)
                context.Results.Peek().Add(result);
            else
                context.Outputs.Add(result);
        }

        public void VisitSelect(SelectBlock b, Context context)
        {

            var parent = context.Datas.Peek();

            //if (b.Skip > 0)
            //    list2 = list2.Skip(b.Skip).ToList();

            //if (b.Limit > 0)
            //    list2 = list2.Take(b.Limit).ToList();

            List<string> values = new List<string>();

            context.Value = parent.Tag;
            b.Function.Accept(this, context);
            values.Add(context.Value.ToString());


            List<JValue> jvalues = new List<JValue>();

            foreach (var item in values)
                jvalues.Add(ConvertJvalue(b, item));

            JToken value;
            if (values.Count == 1)
                value = jvalues[0];

            else
                value = new JArray(jvalues);


            var p = new JProperty(b.Label, value);

            if (context.Results.Count > 0)
            {
                var result = context.Results.Peek();
                result.Add(p);
            }

            var n = new FoundHtmlNode() { Message = "Select " + p.ToString(), SelectNode = true, Parent = parent.Id };
            if (Selected != null)
                this.Selected(n);

        }

        private static JValue ConvertJvalue(SelectBlock b, string item)
        {
            switch (b.Type)
            {
                case TypeEnum.Decimal:
                    if (decimal.TryParse(item, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out decimal d))
                        return new JValue(d);
                    break;
                case TypeEnum.Integer:
                    if (int.TryParse(item, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out int i))
                        return new JValue(i);
                    break;

                case TypeEnum.Date:
                    if (DateTime.TryParse(item, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime d2))
                        return new JValue(d2);
                    break;

                case TypeEnum.Uuid:
                    if (Guid.TryParse(item, out Guid g))
                        return new JValue(g);
                    break;

                case TypeEnum.Boolean:
                    return new JValue(Convert.ToBoolean(item));

                case TypeEnum.String:
                default:
                    break;
            }

            return JValue.CreateString(item);

        }

        public void VisitReadInnerText(ReadInnerTextBlock b, Context context)
        {

            var node = context.Value as HtmlNode;
            context.Value = node.InnerText;

            if (b.Sub != null)
                b.Sub.Accept(this, context);

        }

        public void VisitReadAttribute(ReadAttributeBlock b, Context context)
        {

            var node = context.Value as HtmlNode;
            context.Value = node.Attributes[b.Name].Value;

            if (b.Sub != null)
                b.Sub.Accept(this, context);

        }

        public void VisitCallFunction(CallFunctionBlock b, Context context)
        {

            context.Value = b.Method(context.Value);

            if (b.Sub != null)
                b.Sub.Accept(this, context);
        }

        public Action<FoundHtmlNode> Selected { get; set; }
        public Action<ErrorModel> Error { get; set; }


        private readonly BlockList _config;
        private JToken Output;
        //private List<int> _indexes;
    }

}
