using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ANARIS.BLL
{
    public class SaveProject
    {
        public static string projectRelativePath = "DATA";
        public static string projectFileName = "data.xml";
        public static string projectInfoFileName = "info.txt";

        public static void Save(string filePath, ProjectToSave save, string version)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProjectToSave));
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
                    zip.AddEntry(Path.Combine(SaveProject.projectRelativePath, SaveProject.projectFileName), stream);
                    //zip.AddFile(@"C:\Users\Primus\Desktop\Sample.pdf","");
                    zip.Save(filePath);
                }

                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);

                XmlNode infoNode = doc.CreateElement("Info");
                XmlNode versionNode = doc.CreateElement("Version");
                versionNode.AppendChild(doc.CreateTextNode(version));
                infoNode.AppendChild(versionNode);
                doc.AppendChild(infoNode);
                string tmp = doc.OuterXml;
                zip.AddEntry("info.txt", tmp);
                zip.Save(filePath);
            }

            //XDocument xmlDocument = XDocument.Parse(xmlString);

            //using (var stream = new MemoryStream())
            //{
            //    var formatter = new BinaryFormatter();
            //    formatter.Serialize(stream, save);
            //    stream.Flush();
            //    stream.Position = 0;
            //    base64string = Convert.ToBase64String(stream.ToArray());
            //}


            //if (File.Exists(filePath))
            //{
            //    File.Delete(filePath);
            //}
            //File.AppendAllText(filePath, data);
        }


        public static void QuickSave(string filePath, ProjectToSave save)
        {

            using (Stream file = File.Open(filePath, FileMode.Create))
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(ProjectToSave));
                xmlser.Serialize(file, save);
                file.Close();
            }

        }
    }
}
