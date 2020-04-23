using Bb.Sdk.HttpParser;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;

namespace Bb.Powershell.HtmlParser
{
    [Cmdlet(VerbsData.Convert, "DocumentJsonToExcel")]
    [OutputType(typeof(JToken))]
    public class DocumentJsonToExcelCmdlet : Cmdlet
    {

        [Parameter(HelpMessage = "documents to convert", Mandatory = true)]
        public string Path { get; set; }

        [Parameter(HelpMessage = "Name of the sheetname", Mandatory = true)]
        public string SheetName { get; set; }

        [Parameter(HelpMessage = "Filter if the path is a folder")]
        public string Filter { get; set; }

        [Parameter(HelpMessage = "filename excel output", Mandatory = true)]
        public string OutputFilename { get; set; }

        [Parameter(HelpMessage = "Remove the output file if exists")]
        public bool RemoveOutputFileIfExist { get; set; }

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

                FileInfo file = new FileInfo(OutputFilename);
                if (!file.Directory.Exists)
                    file.Directory.Create();

                if (file.Exists && this.RemoveOutputFileIfExist)
                        file.Delete();

                var xlsx = new JSonToExcel(OutputFilename, SheetName);

                foreach (var item in _files)
                {

                    var document = ContentHelper.LoadContentFromFile(item);
                    var json = JToken.Parse(document);

                    if (json is JArray a)
                        xlsx.Append(a);

                    else if (json is JObject o)
                        xlsx.Append(o);

                    else
                    {

                    }
                }

                xlsx.Flush();


            }

            base.ProcessRecord();

        }


    }

}
