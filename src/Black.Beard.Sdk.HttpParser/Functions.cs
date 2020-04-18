using System.Text.RegularExpressions;

namespace Bb.Sdk.HttpParser
{

    public static class Functions
    {

        static Functions()
        {
            _reg = new Regex(@"-[A-Z]{2,2}\d+", RegexOptions.None);
        }

        public static string GetBourseReference(string test)
        {

            var e = _reg.Match(test);
            if (e.Success)
                return e.Value.Substring(1);

            return test;
        }

        private static readonly Regex _reg;


    }

}
