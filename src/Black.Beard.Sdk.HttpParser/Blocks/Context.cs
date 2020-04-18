using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;

namespace Bb.Sdk.HttpParser.Blocks
{
    public class Context
    {

        public Context()
        {
            Datas = new Stack<FoundHtmlNode>();
            Results = new Stack<List<JToken>>();
            Outputs = new List<JToken>();
        }

        public HtmlNode HtmlDoc { get; internal set; }

        public Stack<FoundHtmlNode> Datas { get; }

        public Stack<List<JToken>> Results { get; }

        public JToken Last { get; set; }

        public object Value { get; set; }

        public List<JToken> Outputs { get; set; }
    }

}
