namespace Bb.Sdk.HttpParser.Blocks
{

    public class ReadInnerTextBlock : Block
    {
       
        public override void Accept(IBlockVisitor visitor, Context context)
        {
            visitor.VisitReadInnerText(this, context);
        }

        public CallFunctionBlock Sub { get; internal set; }

    }

}
