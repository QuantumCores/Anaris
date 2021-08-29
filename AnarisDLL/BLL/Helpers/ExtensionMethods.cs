using AnarisDLL.BLL.Report;
using AnarisDLL.BLL.Anaris;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace AnarisDLL.BLL.Helpers
{
    public static class ExtensionMethods
    {

        public static string GetPolishMonthInBiernik(this DateTime date)
        {
            string month = string.Empty;
            switch (date.Month)
            {
                case 1:
                    month = "stycznia";
                    break;
                case 2:
                    month = "lutego";
                    break;
                case 3:
                    month = "marca";
                    break;
                case 4:
                    month = "kwietnia";
                    break;
                case 5:
                    month = "maja";
                    break;
                case 6:
                    month = "czerwca";
                    break;
                case 7:
                    month = "lipca";
                    break;
                case 8:
                    month = "sierpnia";
                    break;
                case 9:
                    month = "września";
                    break;
                case 10:
                    month = "paźdzernika";
                    break;
                case 11:
                    month = "listopada";
                    break;
                case 12:
                    month = "grudnia";
                    break;
                default:
                    month = "stycznia";
                    break;
            }

            return month;
        }
        #region XMmlDocument

        public static List<XmlNode> ChildNodesAsList(this XmlNode parentNode)
        {
            List<XmlNode> childNodes = new List<XmlNode>();
            XmlNodeList list = parentNode.ChildNodes;

            foreach (XmlNode node in list)
            {
                childNodes.Add(node);
            }

            return childNodes;
        }

        public static string InsertVariable(this XmlNode node, Anaris.Anaris save)
        {
            string nodeText = string.Empty;
            string path = ReportEnums.GetVariablePath(node.Name.ToUpper().Insert(0, "V_"));
            XmlAttribute attr = node.Attributes["arg"];
            List<int> args = new List<int>();
            if (attr != null)
            {
                string[] sArgs = Regex.Replace(attr.Value, @"(\r|\n)", "").Split(',');
                foreach (string val in sArgs)
                {
                    args.Add(int.Parse(val));
                }
            }

            switch (args.Count)
            {
                case 1:
                    path = string.Format(path, args[0]);
                    break;
                case 2:
                    path = string.Format(path, args[0], args[1]);
                    break;
                case 3:
                    path = string.Format(path, args[0], args[1], args[2]);
                    break;
                case 4:
                    path = string.Format(path, args[0], args[1], args[2], args[3]);
                    break;
                case 5:
                    path = string.Format(path, args[0], args[1], args[2], args[3], args[4]);
                    break;
            }

            //path = string.Format(path, args[0], args[1], args[2], args[3]);
            nodeText = (string)GetNestedObject(path.Split('.'), save, 0);
            if (string.IsNullOrEmpty(nodeText))
            {
                return " ";
            }
            else
            {
                return nodeText;
            }
            
        }

        public static string InsertListVariable(this XmlNode node, Anaris.Anaris save)
        {
            string nodeText = string.Empty;
            string path = ReportEnums.GetVariablePath(node.Name.ToUpper().Insert(0, "L_"));
            XmlAttribute attr = node.Attributes["arg"];
            List<int> args = new List<int>();
            if (attr != null)
            {
                string[] sArgs = Regex.Replace(attr.Value, @"(\r|\n)", "").Split(',');
                foreach (string val in sArgs)
                {
                    args.Add(int.Parse(val));
                }
            }

            switch (args.Count)
            {
                case 1:
                    path = string.Format(path, args[0]);
                    break;
                case 2:
                    path = string.Format(path, args[0], args[1]);
                    break;
                case 3:
                    path = string.Format(path, args[0], args[1], args[2]);
                    break;
                case 4:
                    path = string.Format(path, args[0], args[1], args[2], args[3]);
                    break;
                case 5:
                    path = string.Format(path, args[0], args[1], args[2], args[3], args[4]);
                    break;
            }

            //path = string.Format(path, args[0], args[1], args[2], args[3]);
            nodeText = (string)GetNestedObject(path.Split('.'), save, 0);
            if (string.IsNullOrEmpty(nodeText))
            {
                return " ";
            }
            else
            {
                return nodeText;
            }

        }

        

        #endregion

        public static object GetNestedObject(string[] path, object obj, int count)
        {
            if (obj == null) { return null; }
            if (count < path.Length)
            {
                string current = path[count];
                if (current.Contains('['))
                {
                    obj = GetObjectFromList(current, obj);
                }
                else
                {
                    obj = GetObject(current, obj);
                }
                count++;

                //object ret = GetNestedObject(path, obj, count);

                return GetNestedObject(path, obj, count);
            }
            else
            {
                return obj;
            }
        }

        private static object GetObject(string name, object obj)
        {
            Type type = obj.GetType();
            PropertyInfo info = type.GetProperty(name);
            if (info == null) { return null; }
            //Type propType = info.PropertyType;
            obj = info.GetValue(obj, null);

            return obj;
        }

        private static object GetObjectFromList(string sIndex, object obj)
        {
            int index = int.Parse(sIndex.Remove(sIndex.Length - 1, 1).Remove(0, 1));
            IList list = obj as IList;
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return list[index] as object;
            }
        }
    }
}
