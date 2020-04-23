using System;
using ExcelLibrary.SpreadSheet;

namespace Bb.Powershell.HtmlParser.Excels
{

    public class ExcelColumn
    {

        public ExcelColumn(string value)
        {
            this.c = new Cell(value);
        }

        public ExcelColumn(object value)
        {
            this.c = new Cell(value);
        }

        public ExcelColumn(float value)
        {
            this.c = new Cell(value);
        }

        public ExcelColumn(TimeSpan value)
        {
            this.c = new Cell(value);
        }

        public ExcelColumn(DateTime value)
        {
            this.c = new Cell(value);
        }

        public ExcelColumn(short value)
        {
            this.c = new Cell(value);
        }

        internal Cell Cell()
        {
            return c;
        }

        public override string ToString()
        {
            return c.Value.ToString();
        }

        private readonly Cell c;

    }

}