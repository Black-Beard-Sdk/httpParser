using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Bb.Sdk.HttpParser.Blocks;
using Bb.Sdk.HttpParser.Grammar;
using Bb.Sdk.HttpParser.Grammar.Generated;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bb.Sdk.HttpParser
{

    public class ReaderHtmlParser
    {

        private ReaderHtmlParser(TextWriter output, TextWriter outputError)
        {

            this.Output = output ?? Console.Out;
            this.OutputError = outputError ?? Console.Error;

        }

        public static ExtractDataVisitor GetConfig(StringBuilder source, string sourceFile = "", TextWriter output = null, TextWriter outputError = null)
        {
            var parser = ReaderHtmlParser.ParseString(source, sourceFile);
            var config = parser.Parse();
            ExtractDataVisitor visitor = new ExtractDataVisitor(config);
            return visitor;
        }

        public static ReaderHtmlParser ParseString(StringBuilder source, string sourceFile = "", TextWriter output = null, TextWriter outputError = null)
        {
            ICharStream stream = CharStreams.fromstring(source.ToString());

            var parser = new ReaderHtmlParser(output, outputError)
            {
                File = sourceFile ?? string.Empty,
                Content = source,
            };
            parser.ParseCharStream(stream);
            return parser;

        }

        public static ReaderHtmlParser ParsePath(string source, TextWriter output = null, TextWriter outputError = null)
        {

            var payload = LoadContent(source);
            ICharStream stream = CharStreams.fromstring(payload.ToString());

            var parser = new ReaderHtmlParser(output, outputError)
            {
                File = source,
                Content = payload,
            };
            parser.ParseCharStream(stream);
            return parser;

        }

        /// <summary>
        /// Loads the content of the file.
        /// </summary>
        /// <param name="rootSource">The root source.</param>
        /// <returns></returns>
        public static StringBuilder LoadContent(string rootSource)
        {
            StringBuilder result = new StringBuilder(ContentHelper.LoadContentFromFile(rootSource));
            return result;
        }

        public static bool Trace { get; set; }

        public HtmlPatternParser.ScriptContext Tree { get; private set; }

        public string File { get; set; }

        public StringBuilder Content { get; private set; }

        public TextWriter Output { get; private set; }

        public TextWriter OutputError { get; private set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Visit<Result>(IParseTreeVisitor<Result> visitor)
        {

            if (visitor is IFile f)
                f.Filename = this.File;

            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Trace.WriteLine(this.File);

            var i =  visitor.Visit(this.Tree);
            return i;
        }

        public IEnumerable<ErrorModel> Errors { get => this._errors; }

        public BlockList Parse()
        {
            this._errors.Clear();
            var visitor = new TranslateConfigVisitor();
            var result = (BlockList)Visit<object>(visitor);
            this._errors.AddRange(visitor.Errors);
            return result;
        }


        public bool InError { get => this._parser.ErrorListeners.Count > 0; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ParseCharStream(ICharStream stream)
        {

            var lexer = new HtmlPatternLexer(stream, this.Output, this.OutputError);
            var token = new CommonTokenStream(lexer);
            this._parser = new HtmlPatternParser(token)
            {
                BuildParseTree = true,
                //Trace = ScriptParser.Trace, // Ca plante sur un null, pourquoi ?
            };

            Tree = _parser.script();          

        }

        private HtmlPatternParser _parser;
        private List<ErrorModel> _errors = new List<ErrorModel>();

    }


    public interface IFile
    {

        string Filename { get; set; }

    }

}
