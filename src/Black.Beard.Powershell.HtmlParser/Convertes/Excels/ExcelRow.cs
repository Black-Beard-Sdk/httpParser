using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bb.Powershell.HtmlParser.Excels
{


    public class ExcelRow : IEnumerable<ExcelColumn>
    {

        public ExcelRow(params object[] args)
        {
            this.columns = new List<ExcelColumn>();

            foreach (var item in args)
                AppendColumn(new ExcelColumn(item));
           
        }

        private void AppendColumn(ExcelColumn c)
        {
            this.columns.Add(c);
        }

        public IEnumerator<ExcelColumn> GetEnumerator()
        {
            return columns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return columns.GetEnumerator();
        }

        private List<ExcelColumn> columns;

    }

}