namespace Bb.Sdk.HttpParser.Blocks
{

    public class ReadInnerTextBlock : SubsBlock
    {
        public bool Text { get; internal set; }
        public bool Html { get; internal set; }

        public override void Accept(IBlockVisitor visitor, Context context)
        {
            visitor.VisitReadInnerText(this, context);
        }

    }

}
