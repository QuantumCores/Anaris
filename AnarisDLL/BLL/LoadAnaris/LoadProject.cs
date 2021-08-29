using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.Helpers;
using AnarisDLL.BLL.SaveAnaris;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AnarisDLL.BLL.LoadAnaris
{
    public class LoadProject
    {
        private static readonly object fsLock = new object();
        private static FileStream fs;


        public static string GetTheAssemblyVersion(int fileOffset, string filePath)
        {
            string version = string.Empty;

            using (fs = new FileStream(filePath, FileMode.Open))
            {

                int bufferSize = 256;
                byte[] buffer = new byte[bufferSize];

                int arrayOffset = 0;

                lock (fsLock)
                {
                    fs.Seek(fileOffset, SeekOrigin.Begin);

                    int numBytesRead = fs.Read(buffer, arrayOffset, bufferSize);

                    //  Typically used if you're in a loop, reading blocks at a time
                    arrayOffset += numBytesRead;
                }

                string text = System.Text.Encoding.Default.GetString(buffer);
                if (text.Contains("data version"))
                {
                    //string pattern = "build:(\\d+.\\d+.\\d+.\\d+)";
                    string pattern = "data version=\"(\\d+.\\d+.\\d+.\\d+)\"";
                    Regex regex = new Regex(pattern);
                    Match match = regex.Match(text);
                    version = match.Groups[1].Value;
                }
                else if (text.Contains("<programVersion>0.15 Beta</programVersion>"))
                {
                    version = "1.0.0.0";
                }
                else
                {
                    using (ZipFile zip = new ZipFile(filePath))
                    {
                        ZipEntry entry = zip.Entries.Where(e => e.FileName == SaveProject.projectInfoFileName).FirstOrDefault();
                        using (MemoryStream ms = new MemoryStream())
                        {
                            entry.Extract(ms);
                            XmlDocument doc = new XmlDocument();
                            ms.Position = 0;
                            StreamReader sr = new StreamReader(ms);
                            string myStr = sr.ReadToEnd();
                            doc.LoadXml(myStr);
                            version = doc.GetElementsByTagName("Version")[0].InnerText;
                        }
                    }
                }
            }


            return version;
        }

        public static Anaris.Anaris Load(string version, string filePath)
        {

            Anaris.Anaris project = null;
            //if (version == "1.0.0.0")
            //{
            //    return LoadAnaris_v_1_0.Load(filePath);
            //}
            //else if (version == "1.5.0.0")
            //{
            //    project = LoadAnaris_v_1_5.Load(filePath);
            //}
            //else if (version == "1.6.0.0")
            //{
            //    project = LoadAnaris_v_1_6.Load(filePath);
            //}
            if (version == "1.7.0.0")
            {
                project = LoadAnaris_v_1_7.Load(filePath);
            }
            else if (version == "2.0.0.0")
            {
                project = LoadAnaris_v_2_0.Load(filePath);
            }
            else
            {
                return null;
            }

            string coma = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            NumberFormatConverter.ConvertNumberFormat(project, coma);

            return project;
        }

        public static Anaris.Anaris QuickLoad(string filePath)
        {
            Anaris.Anaris project = new Anaris.Anaris();

            using (Stream file = File.Open(filePath, FileMode.Open))
            {
                XmlSerializer bf = new XmlSerializer(typeof(Anaris.Anaris));
                project = (Anaris.Anaris)bf.Deserialize(file);
                file.Close();
            }



            return project;
        }

    }

}
