using Bb.Sdk.HttpParser.Blocks;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Powershell.HtmlParser
{

    [Cmdlet(VerbsData.Convert, "JsonToCsv")]
    [OutputType(typeof(JToken))]
    public class JsonToCsvCmdlet : Cmdlet
    {

        [Parameter(HelpMessage = "json document to convert", Mandatory = true)]
        public JToken Document { get; set; }


        [Parameter(HelpMessage = "Charset bloc delimiter. by default the value is empty")]
        public Char BlocDelimiter { get; set; } = (char)0;

        [Parameter(HelpMessage = "Charset column delimiter. by default the value is ';'")]
        public Char CharColumnDelimiter { get; set; } = ';';

        [Parameter(HelpMessage = "Escape charset is used if a column contains charset bloc delimiter or a charset column delimiter. by default the value is '\'")]
        public Char EscapeChar { get; set; } = '\\';

        [Parameter(HelpMessage = "filename csv output", Mandatory = true)]
        public string OutputFilename { get; set; }

        [Parameter(HelpMessage = "Remove the output file if exists")]
        public bool RemoveOutputFileIfExist { get; set; }

        [Parameter(HelpMessage = "Write headers. By default the value is true")]
        public bool WriteHeaders { get; set; } = true;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {

            bool writeHeader = false;
            FileInfo file = new FileInfo(OutputFilename);
            if (!file.Directory.Exists)
                file.Directory.Create();

            if (file.Exists)
            {
                if (this.RemoveOutputFileIfExist)
                    file.Delete();
                else
                    writeHeader = false;
            }

            var writer = new WriteCsv(OutputFilename, writeHeader)
            {
                BlocDelimiter = this.BlocDelimiter,
                CharColumnDelimiter = this.CharColumnDelimiter,
                EscapeChar = this.EscapeChar,
                WithBlocDelimiter = this.BlocDelimiter != 0,
            };


            JSonToCsv csv = new JSonToCsv(writer);

            if (this.Document is JArray a)
                csv.Append(a);

            else if (this.Document is JObject o)
                csv.Append(o);

            else
            {

            }

            csv.Flush();

            base.ProcessRecord();

        }


    }

}
