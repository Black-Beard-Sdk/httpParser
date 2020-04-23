namespace Bb.Powershell.HtmlParser
{

    public class JSonToCsv : BaseJSonTo
    {

        public JSonToCsv(string filename, bool writeHeaders = true) :
            this(new WriteCsv(filename, writeHeaders))
        {

        }

        public JSonToCsv(WriteCsv writer)
        {
            this.csv = writer;
        }


        public override void Flush()
        {
            this.csv.Flush();
        }

        protected override void CloseLine()
        {

            string[] array = new string[IndexMax];

            foreach (var item in this.CurrentLine)
                array[item.Index] = item.Value.ToString();

            csv.AppendLine(array);

        }

        public override int EnsureColumnExist(string root, string columnName)
        {
            return base.EnsureColumnExist(root, columnName);
        }

        public override void ColumnAdded(string name, int index)
        {
            this.csv.ColumnNames.Add(name);
        }

        private WriteCsv csv;

    }


}


