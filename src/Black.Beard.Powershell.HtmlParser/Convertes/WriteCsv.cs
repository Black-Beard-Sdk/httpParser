using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bb.Powershell.HtmlParser
{
    public class WriteCsv
    {

        public WriteCsv(string filename, bool writeHeaders)
        {
            this._filename = filename;
            this._output = new StringBuilder();
            this._headerWrited = false;
            this._writeHeaders = writeHeaders;
            this.ColumnNames = new List<string>(50);
        }

        

        public void AppendLine(string[] array)
        {

            string comma = this.CharColumnDelimiter.ToString();
            foreach (string item in array)
            {
                if (item != null)
                {
                    if (this.WithBlocDelimiter)
                    {
                        string i = item.Replace(this.BlocDelimiter.ToString(), this.EscapeChar + BlocDelimiter.ToString());
                        _output.Append(this.BlocDelimiter);
                        _output.Append(i);
                        _output.Append(this.BlocDelimiter);
                    }
                    else
                    {
                        string i = item.Replace(this.CharColumnDelimiter.ToString(), this.EscapeChar + CharColumnDelimiter.ToString());
                        _output.Append(i);
                    }
                }
                _output.Append(comma);
            }

            if (_output.Length > 0)
                _output.Remove(_output.Length - comma.Length, comma.Length);

            _output.AppendLine();

        }

        public void Flush()
        {

            if (_writeHeaders && !_headerWrited)
            {
                BuilderHeader();
                _headerWrited = true;
            }

            File.AppendAllText(this._filename, this._output.ToString());

            this._output.Clear();
        
        }

        public List<string> ColumnNames { get;set; }

        private void BuilderHeader()
        {
            StringBuilder sb = new StringBuilder();

            string comma = this.CharColumnDelimiter.ToString();
            foreach (var item in ColumnNames)
            {
                sb.Append(item);
                sb.Append(comma);
            }

            if (sb.Length > 0)
                sb.Remove(sb.Length - comma.Length, comma.Length);

            sb.AppendLine();

            _output.Insert(0, sb.ToString());

        }

        public bool WithBlocDelimiter { get; set; } = true;

        public char CharColumnDelimiter { get; set; } = ';';

        public char BlocDelimiter { get; set; } = '"';

        public char EscapeChar { get; set; } = '\\';

        private readonly string _filename;
        private readonly StringBuilder _output;
        private bool _headerWrited;
        private readonly bool _writeHeaders;
    }

}


