using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ANARIS.BLL.Report
{
    public class ARTemplate
    {
        public XmlDocument ReportTemplate { get; set; }

        public ARTemplate(string filePath)
        {
            ReportTemplate = LoadTemplate( filePath);
        }

        public static XmlDocument LoadTemplate(string filePath)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(filePath);
            return xdoc;
        }

        public XmlNode LoadTemplate_TitlePage()
        {
            XmlNode chapter = ReportTemplate.GetElementsByTagName(ReportEnums.C_TITLEPAGE)[0];

            return chapter;
        }

        public XmlNode LoadTemplate_FactorChapter()
        {
            XmlNode chapter = ReportTemplate.GetElementsByTagName(ReportEnums.C_FACTORCHAPTER)[0];

            return chapter;
        }

    }
}
