using System.Collections.Generic;
using System.Text;

namespace Bb.Sdk.HttpParser.Blocks
{
    [System.Diagnostics.DebuggerDisplay("[match] {Matching} -> {Subs}")]
    public class BlockSearch : Block
    {

        public BlockSearch()
        {
            this.Subs = new List<Block>();
            this.Matchings = new List<string>();
        }

        public int SearchInSub { get; set; }

        public List<string> Matchings { get; }
        
        public int Skip { get; internal set; }
        
        public int Limit { get; internal set; }
        
        public List<Block> Subs { get; }

        public override void Accept(IBlockVisitor visitor, Context context)
        {
            visitor.VisitSearch(this, context);
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.Append("SEARCH ");
            if (Matchings.Count == 1)
                sb.Append($"'{this.Matchings[0]}'");
            else
            {

                sb.Append(" (");
                string comma = "";
                foreach (var item in Matchings)
                {
                    sb.Append(comma);
                    sb.Append($" '{item}'");
                    comma = "| ";
                }

                sb.Append(")");

            }

            if (Skip > 0)
                sb.Append(" SKIP " + this.Skip.ToString());

            if (Limit > 0)
                sb.Append(" LIMIT " + this.Limit.ToString());

            if (Subs.Count == 1)
            {
                var s = Subs[0];
                if (s is OutputBlock)
                    sb.Append(" NEW OBJECT");
            }

            return sb.ToString();

        }


    }

}
