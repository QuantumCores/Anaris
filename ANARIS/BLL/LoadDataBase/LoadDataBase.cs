using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ANARIS.BLL.LoadDataBase
{
    public class LoadDataBase
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


                using (ZipFile zip = new ZipFile(filePath))
                {
                    ZipEntry entry = zip.Entries.Where(e => e.FileName == SaveDataBase.SaveDataBase.InfoFileName).FirstOrDefault();
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


            return version;
        }

        public static DBToSave Load(string version, string filePath)
        {

            DBToSave project = new DBToSave();


            if (version == "1.6.0.0")
            {
                project = LoadDataBase_v_1_6.Load(filePath);
            }
            else if (version == "1.7.0.0")
            {
                project = LoadDataBase_v_1_6.Load(filePath);
            }

            return project;
        }
    }
}
