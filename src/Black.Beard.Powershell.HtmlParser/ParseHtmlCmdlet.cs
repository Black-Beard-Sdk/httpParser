using Bb.Sdk.HttpParser;
using Bb.Sdk.HttpParser.Blocks;
using Newtonsoft.Json.Linq;
using System;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Powershell.HtmlParser
{

    [Cmdlet(VerbsCommon.Watch, "Html")]
    [OutputType(typeof(JToken))]
    public class ParseHtmlCmdlet : Cmdlet
    {

        [Parameter(HelpMessage = "document to parse", Mandatory =true)]
        public Uri Document { get; set; }

        [Parameter(HelpMessage = "template configuration", Mandatory = true)]
        public Uri Template { get; set; }

        [Parameter(HelpMessage = "token object", Mandatory = false)]
        public JArray ToMerge { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {

            // Load configuration
            var payloadConfig = new StringBuilder(ContentHelper.LoadContentFromFile(Template.LocalPath));
            var parser = ReaderHtmlParser.ParseString(payloadConfig, Template.LocalPath);
            var config = parser.Parse();

            // create a new Parser
            var visitor = new ExtractDataVisitor(config);

            StringBuilder payload = null;

            if (Document.IsFile)
                payload = new StringBuilder(ContentHelper.LoadContentFromFile(Document.LocalPath));
            
            else if (Document.Scheme.StartsWith("http"))
            {
                var  b = new Uri(Document.Scheme + "://" + Document.Host);
                SessionHttp session = new SessionHttp(b);
                var result = session.Get(Document);
                payload = result.ResultBodyText;
            }

            JToken jtoken = visitor.Run(payload);

            if (ToMerge != null)
            {
                
                if (jtoken is JArray a)
                    ToMerge.Merge(a);
                
                else if (jtoken is JObject o)
                    ToMerge.Add(o);
            
            }
            else 
                this.WriteObject(jtoken);

            base.ProcessRecord();
        
        }


    }

}


