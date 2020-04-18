using System.Collections.Generic;

namespace Bb.Sdk.HttpParser.Blocks
{

    [System.Diagnostics.DebuggerDisplay("{ObjectKind} {Subs}")]
    public class OutputBlock : Block
    {

        public OutputBlock()
        {
            this.Subs = new List<Block>();
        }

        public List<Block> Subs { get; }
        public OutputKind ObjectKind { get; internal set; }
        public string PropertyName { get; internal set; }

        public override void Accept(IBlockVisitor visitor, Context context)
        {
            visitor.VisitObject(this, context);
        }

    }

    public enum OutputKind
    {
        Undefined,
        Array,
        Object,
        Property
    }


}
