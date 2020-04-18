using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Bb.Sdk.HttpParser.Blocks
{

    public class FoundHtmlNode
    {

        public FoundHtmlNode()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public Guid Parent { get; internal set; }

        public string Message { get; internal set; }

        public HtmlNode Tag { get; set; }
        public bool SearchNode { get; internal set; }
        public int IndexStart { get; internal set; }
        public int IndexLength { get; internal set; }
        public bool ResultNode { get; internal set; }
        public bool SelectNode { get; internal set; }
        public bool ObjectNode { get; internal set; }
        public JToken Tag2 { get; internal set; }
        public string Tooltip { get; internal set; }
    }

}
