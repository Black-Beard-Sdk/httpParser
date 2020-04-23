namespace Bb.Sdk.HttpParser.Blocks
{
    public class ReadVariableBlock : SubsBlock
    {

        public string Name { get; internal set; }


        public override void Accept(IBlockVisitor visitor, Context context)
        {
            visitor.VisitVariable(this, context);
        }

    }


}
