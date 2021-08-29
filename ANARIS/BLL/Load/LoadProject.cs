using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ANARIS.BLL.Load
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

        public static ProjectToSave Load(string version, string filePath)
        {

            ProjectToSave project = new ProjectToSave();

            if (version == "1.0.0.0")
            {
                project = LoadAnaris_v_1_0.Load(filePath);
            }
            else if (version == "1.5.0.0")
            {
                project = LoadAnaris_v_1_5.Load(filePath);
            }
            else if (version == "1.6.0.0")
            {
                project = LoadAnaris_v_1_6.Load(filePath);
            }
            else if (version == "1.7.0.0")
            {
                project = LoadAnaris_v_1_7.Load(filePath);
            }

            return project;
        }

        public static ProjectToSave QuickLoad(string filePath)
        {
            ProjectToSave project = new ProjectToSave();

            using (Stream file = File.Open(filePath, FileMode.Open))
            {
                XmlSerializer bf = new XmlSerializer(typeof(ProjectToSave));
                project = (ProjectToSave)bf.Deserialize(file);
                file.Close();
            }

            return project;
        }

    }

}
