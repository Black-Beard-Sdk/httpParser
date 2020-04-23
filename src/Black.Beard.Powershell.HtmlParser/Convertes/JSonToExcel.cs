using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Powershell.HtmlParser
{
    public class JSonToExcel : BaseJSonTo
    {

        public JSonToExcel(string filename, string sheetname) : this()
        {
            this.MaxLineInBuffer = int.MaxValue;
            this._filename = filename;
            this._sheetname = sheetname;
            this._writer = new Excels.ExcelWriter();
        }

        public JSonToExcel()
        {

        }

        public override void Flush()
        {
            _writer.Save(this._filename);
        }


        protected override void CloseLine()
        {

            List<object> i = new List<object>();

            foreach (var item in this.CurrentLine.Select(c => c.Value).ToArray())
            {
                if (item is JToken t)
                {
                    switch (t.Type)
                    {
                        case JTokenType.Integer:
                            i.Add(t.Value<int>());
                            break;
                        case JTokenType.Float:
                            i.Add(t.Value<float>());
                            break;
                        case JTokenType.String:
                            i.Add(t.Value<string>());
                            break;
                        case JTokenType.Boolean:
                            i.Add(t.Value<bool>());
                            break;
                        case JTokenType.Null:
                            i.Add(string.Empty);
                            break;
                        case JTokenType.Date:
                            i.Add(t.Value<DateTime>());
                            break;
                        case JTokenType.Raw:
                        case JTokenType.Bytes:
                            i.Add(t.Value<object>());
                            break;
                        case JTokenType.Guid:
                            i.Add(t.Value<Guid>().ToString());
                            break;
                        case JTokenType.Uri:
                            i.Add(t.Value<string>());
                            break;
                        case JTokenType.TimeSpan:
                            i.Add(t.Value<TimeSpan>());
                            break;
                        default:
                            break;
                    }
                }
                else
                    i.Add(item);
            }

            var items = new Excels.ExcelRow(i.ToArray());
            _writer.Append(this._sheetname, items);

        }

        private readonly Excels.ExcelWriter _writer;
        private readonly string _filename;
        private readonly string _sheetname;

    }


}


