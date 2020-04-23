using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Powershell.HtmlParser
{
    public class BaseJSonTo
    {

        protected class Column
        {
            public int Index { get; internal set; }

            public string Name { get; internal set; }
            
            public object Value { get; internal set; }
        
        }


        public virtual void Flush()
        {
        }


        public void Append(JObject obj)
        {

            this.CurrentLine = new List<Column>();

            AddLine();
            AppendObject(string.Empty, obj);
            CloseLine();

        }

        public void Append(JArray array)
        {
            this._countLineInBuffer = 0;
            this.CurrentLine = new List<Column>();
            foreach (var item in array)
            {

                AddLine();

                if (item is JObject o)
                {

                    AppendObject(string.Empty, o);

                }
                else
                {

                }

                CloseLine();
                this._countLineInBuffer++;
                if (this.MaxLineInBuffer < this._countLineInBuffer)
                {
                    csv.Flush();
                    this._countLineInBuffer = 0;
                }

            }
        }

        protected virtual void CloseLine()
        {

            string[] array = new string[IndexMax];

            foreach (var item in this.CurrentLine)
                array[item.Index] = item.Value?.ToString() ?? string.Empty;

            csv.AppendLine(array);

        }

        public int IndexMax { get => this._columns.Count; }

        private void AddLine()
        {
            this.CurrentLine.Clear();
        }

        private void AppendObject(string root, JObject o)
        {

            var properties = o.Properties();
            var count = properties.Count();
            string[] arr = new string[count];

            foreach (JProperty item in properties)
            {

                if (item.Type == JTokenType.Object)
                    AppendObject(item.Name + ".", item.Value as JObject);

                else if (item.Type == JTokenType.Array)
                {

                }
                else
                {
                    string name = string.IsNullOrEmpty(root) ? item.Name : string.Concat(root, item.Name);
                    int colIndex = EnsureColumnExist(root, name);
                    this.CurrentLine.Add(new Column { Index = colIndex, Name = name, Value = item.Value });
                }
            }

        }

        public virtual int EnsureColumnExist(string root, string columnName)
        {
            if (!_columns.TryGetValue(columnName, out int index))
            {
                _columns.Add(columnName, (index = _columns.Count));
                _orders.Add(columnName);
            }
            return index;

        }


        public virtual void ColumnAdded (string name, int index)
        {

        }

        public List<string> ColumnNames { get => _orders; }

        public int CountLineInBuffer { get => _countLineInBuffer; }

        public int MaxLineInBuffer { get; set; } = 5000;

        private int _countLineInBuffer;
        protected List<Column> CurrentLine;
        private WriteCsv csv;
        private Dictionary<string, int> _columns = new Dictionary<string, int>();
        private List<string> _orders = new List<string>();

    }


}


