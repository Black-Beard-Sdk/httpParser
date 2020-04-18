using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bb.Sdk.HttpParser.Blocks
{
    public class ExtractDatas
    {

        public ExtractDatas()
        {
            this._dic = new Dictionary<string, ExtractDataVisitor>();
        }

        public ExtractDatas AddFiles(string filenames)
        {

            var files = filenames.Split('\r');
            foreach (var item in files)
                AddFile(item.Trim());

            return this;
        }

        public ExtractDatas AddFiles(string[] filenames)
        {
            foreach (var item in filenames)
                AddFile(item);

            return this;
        }

        public ExtractDatas AddFile(string filename)
        {
            var name = Path.GetFileNameWithoutExtension(filename);
            AddFile(name, filename);
       
            return this;
        }

        public ExtractDatas AddFile(string name, string filename)
        {

            if (!File.Exists(filename))
                throw new FileLoadException(filename);

            StringBuilder sb = new StringBuilder(ContentHelper.LoadContentFromFile(filename));
            Add(name, sb, filename);
        
            return this;
        }

        public ExtractDatas Add(string name, StringBuilder sbPattern, string sourcename = null)
        {
            var visitor = ReaderHtmlParser.GetConfig(sbPattern, sourcename);
            _dic.Add(name, visitor);
            return this;
        }

        public ExtractDataVisitor Resolve(string templateName)
        {

            if (_dic.TryGetValue(templateName, out ExtractDataVisitor visitor))
                return visitor;

            throw new NotImplementedException();

        }

        private readonly Dictionary<string, ExtractDataVisitor> _dic;

    }

}
