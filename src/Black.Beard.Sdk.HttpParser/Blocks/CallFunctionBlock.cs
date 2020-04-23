using System;
using System.Collections.Generic;

namespace Bb.Sdk.HttpParser.Blocks
{

    public class CallFunctionBlock : Block
    {

        public CallFunctionBlock()
        {
            Arguments = new List<object>();
        }

        public string Name { get; internal set; }
        public List<object> Arguments { get; }
        public Func<object, object> Method { get; internal set; }
        public CallFunctionBlock Sub { get; internal set; }

        public override void Accept(IBlockVisitor visitor, Context context)
        {
            visitor.VisitCallFunction(this, context);
        }

    }

}
