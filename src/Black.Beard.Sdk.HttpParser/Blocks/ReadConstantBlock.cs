namespace Bb.Sdk.HttpParser.Blocks
{


    public class ReadConstantBlock : SubsBlock
    {

        public object Value { get; internal set; }


        public override void Accept(IBlockVisitor visitor, Context context)
        {
            visitor.VisitConstant(this, context);
        }

    }


}
