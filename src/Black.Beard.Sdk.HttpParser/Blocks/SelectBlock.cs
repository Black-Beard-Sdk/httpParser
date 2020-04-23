using Bb.Sdk.HttpParser.Blocks;
using System.Collections.Generic;

namespace Bb.Sdk.HttpParser.Blocks
{
    [System.Diagnostics.DebuggerDisplay("[select] Target {Subs}")]
    public class SelectBlock : Block
    {

        public SelectBlock()
        {
            Subs = new List<Block>();
        }

        public List<Block> Subs { get; }

        public string Label { get; internal set; }

        //public int Skip { get; internal set; }

        //public int Limit { get; internal set; }

        public TypeEnum Type { get; internal set; }

        public Block Function { get; internal set; }
        public bool IsVariable { get; internal set; }

        public override void Accept(IBlockVisitor visitor, Context context)
        {
            visitor.VisitSelect(this, context);
        }

    }

    public enum TypeEnum
    {
        String,
        Decimal,
        Integer,
        Date,
        Uuid,
        Boolean,
    }

}
