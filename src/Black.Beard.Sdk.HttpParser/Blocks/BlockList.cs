using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bb.Sdk.HttpParser.Blocks
{
    public class BlockList : List<Block>
    {

        public BlockList()
        {
        }

        public void Accept(IBlockVisitor visitor, StringBuilder plain)
        {
            visitor.VisitList(this, plain);
        }


    }

}
