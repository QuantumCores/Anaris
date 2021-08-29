using ANARIS.BLL.Report;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ANARIS.BLL.Load
{
    public class LoadAnaris_v_2_0
    {
        public static ProjectToSave Load(string filePath)
        {
            ProjectToSave file = new ProjectToSave();

            using (ZipFile zip = new ZipFile(filePath))
            {
                ZipEntry dataEntry = zip.Entries.Where(e => e.FileName.Contains(SaveProject.projectFileName)).FirstOrDefault();
                using (MemoryStream ms = new MemoryStream())
                {
                    dataEntry.Extract(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    XmlSerializer bf = new XmlSerializer(typeof(ProjectToSave));
                    file = (ProjectToSave)bf.Deserialize(ms);
                }
            }

            ReportFonts.LoadFonts(file.ReportSettings);


            //XDocument xmlFile = XDocument.Load(filePath);

            //string base64string = xmlFile.Element("data").Value;
            //string project = string.Empty;

            //byte[] b = Convert.FromBase64String(base64string);
            //using (var stream = new MemoryStream(b))
            //{
            //    var formatter = new BinaryFormatter();
            //    stream.Seek(0, SeekOrigin.Begin);
            //    file = (ProjectToSave)formatter.Deserialize(stream);
            //}

            return file;
        }
    }
}
