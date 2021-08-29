using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ANARIS.BLL.LoadDataBase
{
    public class LoadDataBase_v_1_6
    {
        public static DBToSave Load(string filePath)
        {
            DBToSave file = new DBToSave();

            using (ZipFile zip = new ZipFile(filePath))
            {
                ZipEntry dataEntry = zip.Entries.Where(e => e.FileName.Contains(SaveDataBase.SaveDataBase.DataFileName)).FirstOrDefault();
                using (MemoryStream ms = new MemoryStream())
                {
                    dataEntry.Extract(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    XmlSerializer bf = new XmlSerializer(typeof(DBToSave));
                    file = (DBToSave)bf.Deserialize(ms);
                }
            }

            return file;
        }

    }
}
