using System.Text;

namespace Bb.Sdk.HttpParser.Blocks
{


    public abstract class Block
    {

        public int Order { get; internal set; }

        public abstract void Accept(IBlockVisitor visitor, Context context);
        
    }

}
