using AnarisDLL.BLL.SaveAnaris;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AnarisDLL.BLL.LoadAnaris
{
    public class LoadAnaris_v_2_0
    {
        public static Anaris.Anaris Load(string filePath)
        {
            Anaris.Anaris file = new Anaris.Anaris();

            using (ZipFile zip = new ZipFile(filePath))
            {
                ZipEntry dataEntry = zip.Entries.Where(e => e.FileName.Contains(SaveProject.projectFileName)).FirstOrDefault();
                using (MemoryStream ms = new MemoryStream())
                {
                    dataEntry.Extract(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    XmlSerializer bf = new XmlSerializer(typeof(Anaris.Anaris));
                    file = (Anaris.Anaris)bf.Deserialize(ms);
                }
            }

            file.ProjectProperties.FilePath = filePath;

            //Anaris.Anaris mapedProject = new Anaris.Anaris();

            //uncoment this when newer version of program is available
            //MapModelsProperties(file, mapedProject);
            //return mapedProject;

            return file;
        }
    }
}
