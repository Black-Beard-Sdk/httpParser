using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Bb.Sdk.HttpParser
{
    public static class ContentHelper
    {

        /// <summary>
        /// Loads the content of the file.
        /// </summary>
        /// <param name="rootSource">The root source.</param>
        /// <returns></returns>
        public static string LoadContentFromFile(params string[] rootSource)
        {
            string _path = System.IO.Path.Combine(rootSource);
            return LoadContentFromFile(_path);
        }

        public static string LoadContentFromUrl(HttpWebRequest request)
        {

            string fileContents = string.Empty;
            System.Text.Encoding encoding = null;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                {

                    readStream = new StreamReader(receiveStream);

                    //Ude.CharsetDetector cdet = new Ude.CharsetDetector();
                    //cdet.Feed(readStream);
                    //cdet.DataEnd();
                    //if (cdet.Charset != null)
                    //    encoding = System.Text.Encoding.GetEncoding(cdet.Charset);
                    //else
                    //    encoding = System.Text.Encoding.UTF8;
                    //fs.Position = 0;

                }
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                string data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }



            if (fileContents.StartsWith("ï»¿"))
                fileContents = fileContents.Substring(3);

            if (encoding != System.Text.Encoding.UTF8)
            {
                var datas = System.Text.Encoding.UTF8.GetBytes(fileContents);
                fileContents = System.Text.Encoding.UTF8.GetString(datas);
            }

            return fileContents;

        }

        public static JToken LoadJson(string filename)
        {

            var plain = LoadContentFromFile(filename);
            var result = JToken.Parse(plain);
            return result;

        }

        public static void Save(this string plain, string filename)
        {

            FileInfo f = new FileInfo(filename);

            if (!f.Directory.Exists)
                f.Directory.Create();

            if (f.Exists)
                f.Delete();

            File.WriteAllText(f.FullName, plain);


        }

        public static void Save(this StringBuilder plain, string filename)
        {

            FileInfo f = new FileInfo(filename);

            if (!f.Directory.Exists)
                f.Directory.Create();

            if (f.Exists)
                f.Delete();

            File.WriteAllText(f.FullName, plain.ToString());

        }

        public static void Save(this JToken token, string filename)
        {

            FileInfo f = new FileInfo(filename);

            if (!f.Directory.Exists)
                f.Directory.Create();

            if (f.Exists)
                f.Delete();

            File.WriteAllText(f.FullName, token.ToString());


        }

        public static string LoadContentFromFile(string _path)
        {

            string fileContents = string.Empty;
            System.Text.Encoding encoding = null;
            FileInfo _file = new FileInfo(_path);

            using (FileStream fs = _file.OpenRead())
            {

                Ude.CharsetDetector cdet = new Ude.CharsetDetector();
                cdet.Feed(fs);
                cdet.DataEnd();
                if (cdet.Charset != null)
                    encoding = System.Text.Encoding.GetEncoding(cdet.Charset);
                else
                    encoding = System.Text.Encoding.UTF8;

                fs.Position = 0;

                byte[] ar = new byte[_file.Length];
                fs.Read(ar, 0, ar.Length);
                fileContents = encoding.GetString(ar);
            }

            if (fileContents.StartsWith("ï»¿"))
                fileContents = fileContents.Substring(3);

            if (encoding != System.Text.Encoding.UTF8)
            {
                var datas = System.Text.Encoding.UTF8.GetBytes(fileContents);
                fileContents = System.Text.Encoding.UTF8.GetString(datas);
            }

            return fileContents;

        }

        public static string SerializeContract(this string self)
        {

            if (string.IsNullOrEmpty(self))
                return string.Empty;

            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(self);
            var result = Convert.ToBase64String(bytes);
            return result;
        }

        public static string DeserializeContract(this string self)
        {

            if (string.IsNullOrEmpty(self))
                return string.Empty;

            byte[] bytes = Convert.FromBase64String(self); ;
            string result = System.Text.Encoding.UTF8.GetString(bytes);

            return result;

        }

    }

}
