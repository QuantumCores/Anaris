using AnarisDLL.BLL.Anaris;
using AnarisDLL.BLL.AnarisGrid;
using AnarisDLL.BLL.Helpers;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AnarisDLL.BLL.SaveAnaris
{
    public class SaveProject
    {
        public static string projectRelativePath = "DATA";
        public static string projectFileName = "data.xml";
        public static string projectInfoFileName = "info.txt";

        public static void Save(string filePath, Anaris.Anaris save)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            string coma = CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator;
            NumberFormatConverter.ConvertNumberFormat(save, coma);
            
            XmlSerializer serializer = new XmlSerializer(typeof(Anaris.Anaris));
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
        }

        

        public static void QuickSave(string filePath, Anaris.Anaris save)
        {

            using (Stream file = File.Open(filePath, FileMode.Create))
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(Anaris.Anaris));
                xmlser.Serialize(file, save);
                file.Close();
            }

        }
    }
}
