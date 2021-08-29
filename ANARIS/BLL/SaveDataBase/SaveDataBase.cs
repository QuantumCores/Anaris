using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ANARIS.BLL.SaveDataBase
{
    public class SaveDataBase
    {
        public static string DataPath = "DATA";
        public static string DataFileName = "dataBase.xml";
        public static string InfoFileName = "info.txt";

        public static void Save(string filePath, DBToSave save, string version)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DBToSave));
            string data = string.Empty;

            using (StringWriter stringWriter = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                serializer.Serialize(writer, save);
                data = stringWriter.ToString();
            }

            XmlDocument xmlData = new XmlDocument();
            xmlData.LoadXml(data);

            using (ZipFile zip = new ZipFile())
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    xmlData.Save(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    zip.AddEntry(Path.Combine(SaveDataBase.DataPath, SaveDataBase.DataFileName), stream);
                    //zip.AddFile(@"C:\Users\Primus\Desktop\Sample.pdf","");
                    zip.Save(filePath);
                }

                XmlDocument doc = CreateInfoFile( version);
                zip.AddEntry("info.txt", doc.OuterXml);
                zip.Save(filePath);
            }

        }

        private static XmlDocument CreateInfoFile(string version)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode infoNode = doc.CreateElement("Info");
            XmlNode versionNode = doc.CreateElement("Version");
            versionNode.AppendChild(doc.CreateTextNode(version));
            infoNode.AppendChild(versionNode);
            doc.AppendChild(infoNode);

            return doc;

        }

    }
}
