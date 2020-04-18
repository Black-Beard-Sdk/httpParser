namespace Bb.Sdk.HttpParser.Grammar
{
    public class ErrorModel
    {

        public ErrorModel(string message, int startIndex, int line)
        {
            this.Message = message;
            this.StartIndex = startIndex;
            this.Line = line;
        }

        public string Message { get; }
        public int StartIndex { get; }
        public int Line { get; }

    }

}
