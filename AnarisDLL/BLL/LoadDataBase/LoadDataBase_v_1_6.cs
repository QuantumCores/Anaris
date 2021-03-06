using AnarisDLL.BLL.Database;
using AnarisDLL.BLL.SaveDataBase;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AnarisDLL.BLL.LoadDataBase
{
    public class LoadDataBase_v_1_6
    {
        public static Database.Database Load(string filePath)
        {
            Database.Database file = Database.Database.Instance;

            using (ZipFile zip = new ZipFile(filePath))
            {
                ZipEntry dataEntry = zip.Entries.Where(e => e.FileName.Contains(SaveDataBase.SaveDataBase.DataFileName)).FirstOrDefault();
                using (MemoryStream ms = new MemoryStream())
                {
                    dataEntry.Extract(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    XmlSerializer bf = new XmlSerializer(typeof(Database.Database));
                    file = (Database.Database)bf.Deserialize(ms);
                }
            }

            return file;
        }

    }
}
