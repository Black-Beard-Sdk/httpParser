﻿namespace Bb.Sdk.HttpParser.Blocks
{

    public class ReadAttributeBlock : SubsBlock
    {
        public string Name { get; internal set; }

        public override void Accept(IBlockVisitor visitor, Context context)
        {
            visitor.VisitReadAttribute(this, context);
        }

    }


}
