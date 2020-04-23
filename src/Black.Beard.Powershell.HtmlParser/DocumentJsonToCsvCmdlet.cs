using Bb.Sdk.HttpParser;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;

namespace Bb.Powershell.HtmlParser
{

    [Cmdlet(VerbsData.Convert, "DocumentJsonToCsv")]
    [OutputType(typeof(JToken))]
    public class DocumentJsonToCsvCmdlet : Cmdlet
    {

        [Parameter(HelpMessage = "documents to convert", Mandatory = true)]
        public string Path { get; set; }

        [Parameter(HelpMessage = "Filter if the path is a folder")]
        public string Filter { get; set; }

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

            List<string> _files = new List<string>();
            
            if (File.Exists(this.Path))
            {
                FileInfo f = new FileInfo(this.Path);
                _files.Add(f.FullName);
            }
            else if (Directory.Exists(this.Path))
            {
                
                DirectoryInfo d = new DirectoryInfo(this.Path);
                if (!string.IsNullOrEmpty(this.Filter))
                    this.Filter = "*.*";
                foreach (var item in d.GetFiles(this.Filter))
                    _files.Add(item.FullName);
            }
            else
                throw new Exception("Json document file not found");

            if (_files.Count > 0)
            {

                bool writeHeader = this.WriteHeaders;
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

                foreach (var item in _files)
                {

                    var document = ContentHelper.LoadContentFromFile(item);
                    var json = JToken.Parse(document);

                    if (json is JArray a)
                        csv.Append(a);

                    else if (json is JObject o)
                        csv.Append(o);

                    else
                    {

                    }
                }

                csv.Flush();


            }

            base.ProcessRecord();

        }


    }

}
