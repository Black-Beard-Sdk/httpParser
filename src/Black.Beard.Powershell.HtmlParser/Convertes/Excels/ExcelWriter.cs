using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Powershell.HtmlParser.Excels
{

    public class ExcelWriter
    {

        public ExcelWriter()
        {

        }


        public void Append(string sheetname, ExcelRow line)
        {

            Type type = line.GetType();

            if (!this._sheets.TryGetValue(type, out ExcelWriterWorksheet worksheet))
                this._sheets.Add(type, (worksheet = new ExcelWriterWorksheet(sheetname)));

            worksheet.Append(line);
            
            //worksheet.Cells[4, 0] = new Cell(32764.5, "#,##0.00");
            //worksheet.Cells[5, 1] = new Cell(DateTime.Now, @"YYYY-MM-DD");
            //worksheet.Cells.ColumnWidth[0, 1] = 3000;

        }

        private class ExcelWriterWorksheet
        {

            private Worksheet worksheet;

            public string Name { get; }


            public ExcelWriterWorksheet(string name)
            {
                this.Name = name;
                this._rows = new List<ExcelRow>();
            }

            internal void Append(ExcelRow row)
            {
                this._rows.Add(row);
            }

            internal void Append(params ExcelRow[] rows)
            {
                this._rows.AddRange(rows);
            }

            internal void Build()
            {

                worksheet = new Worksheet(this.Name);
                //worksheet.SheetType == SheetType.Worksheet;

                foreach (var item in this._rows)
                    this.Write(item);
            
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void Write(ExcelRow row)
            {
                int indexCol = 0;
                foreach (ExcelColumn col in row)
                {
                    worksheet.Cells[rowIndex, indexCol] = col.Cell();
                    worksheet.Cells.ColumnWidth[(ushort)indexCol, (ushort)indexCol] = 3000;
                    indexCol++;
                }
                rowIndex++;
            }

            public Worksheet Worksheet { get { return this.worksheet; } }

            private readonly List<ExcelRow> _rows;
            private int rowIndex = 0;

        }

        public void Save(string file)
        {

            Workbook workbook = new Workbook();

            foreach (var item in this._sheets)
            {
                item.Value.Build();
                workbook.Worksheets.Add(item.Value.Worksheet);
            }

            workbook.Save(file);

        }


        private Dictionary<Type, ExcelWriterWorksheet> _sheets = new Dictionary<Type, ExcelWriterWorksheet>();

    }



    /*
            // open xls file 
            Workbook book = Workbook.Load(file);
            Worksheet sheet = book.Worksheets[0];

            // traverse cells 
            foreach (Pair, Cell > cell in sheet.Cells) 
                dgvCells[cell.Left.Right, cell.Left.Left].Value = cell.Right.Value;

            // traverse rows by Index 
            for (int rowIndex = sheet.Cells.FirstRowIndex;
             rowIndex <= sheet.Cells.LastRowIndex;
             rowIndex++)
            {
                Row row = sheet.Cells.GetRow(rowIndex);
                for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
                {
                    Cell cell = row.GetCell(colIndex);
                }
            }
    */


}
