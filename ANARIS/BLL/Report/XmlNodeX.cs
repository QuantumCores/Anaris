using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ANARIS.BLL.Report
{
    public class XmlNodeX
    {
        public XmlNode N { get; set; }
        public int Index { get; set; }
        

        public static List<XmlNodeX> NodesWithIndexes(XmlNode original)
        {
            int startIndex = 0;
            string originalText = original.InnerXml;
            List<XmlNodeX> newList = new List<XmlNodeX>();
            List<XmlNode> list = new List<XmlNode>();
            GetAllNodes(original, list);

            foreach (XmlNode node in list)
            {
                XmlNodeX nodeX = new XmlNodeX() { N = node };
                nodeX.Index = originalText.IndexOf(node.OuterXml, startIndex);
                startIndex = nodeX.Index + node.OuterXml.Length - 1; //minus one to be sure I don't miss anything
                newList.Add(nodeX);
            }

            return newList;
        }

        public static void GetAllNodes(XmlNode node, List<XmlNode> list)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                list.Add(child);
                GetAllNodes(child, list);
            }
        }
    }

    
}
