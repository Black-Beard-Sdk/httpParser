using System.Text;

namespace Bb.Sdk.HttpParser.Blocks
{
    public interface IBlockVisitor
    {
        void VisitList(BlockList b, StringBuilder plain);
        void VisitObject(OutputBlock b, Context context);
        void VisitSearch(BlockSearch b, Context context);
        void VisitSelect(SelectBlock b, Context context);
        void VisitCallFunction(CallFunctionBlock b, Context context);
        void VisitReadAttribute(ReadAttributeBlock b, Context context);
        void VisitReadInnerText(ReadInnerTextBlock b, Context context);
    }

}
