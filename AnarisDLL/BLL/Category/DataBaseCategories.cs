using AnarisDLL.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnarisDLL.BLL.Category
{
    [Serializable]
    public class DataBaseCategories
    {
        public List<Category> List { get; set; }
        public static string Sufix { get { return "CAT_"; } }
        public static int NameLength { get { return 6; } }

        public DataBaseCategories()
        {
            List = new List<Category>();
        }
       

        internal void UpdateCategories(TreeView catTreeView, DataBaseCategories tmpCategories)
        {
            List.Clear();
            for (int i = 0; i < catTreeView.Nodes.Count; i++)
            {
                TreeNode node = catTreeView.Nodes[i];
                Category nowy = new Category();
                nowy.name = node.Name;
                nowy.text = node.Text;
                nowy.description = tmpCategories.List[i].description;

                if (node.Nodes != null)
                {
                    for (int j = 0; j < node.Nodes.Count; j++)
                    {
                        TreeNode subnode = node.Nodes[j];
                        SubCategory nowySub = new SubCategory();
                        nowySub.name = subnode.Name;
                        nowySub.text = subnode.Text;
                        nowySub.description = tmpCategories.List[i].subCategories[j].description;
                        nowy.subCategories.Add(nowySub);
                    }
                }
                List.Add(nowy);
            }
        }

        /// <summary>
        /// Maps category name with category text foreach column
        /// </summary>
        /// <param name="Categories"></param>
        /// <param name="columnMap"></param>
        /// <returns></returns>
        public static Dictionary<int, Dictionary<string, string>> MapCategories(DataBaseCategories Categories, Dictionary<string, int> columnMap)
        {
            Dictionary<int, Dictionary<string, string>> mapping = new Dictionary<int, Dictionary<string, string>>();

            foreach (Category cat in Categories.List)
            {
                Dictionary<string, string> sMap = GetSubCatMap(cat.subCategories);
                mapping.Add(columnMap[cat.name], sMap);
            }

            return mapping;
        }

        private static Dictionary<string, string> GetSubCatMap(IList<SubCategory> sCats)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (SubCategory cat in sCats)
            {
                dic.Add(cat.name, cat.text);
            }

            return dic;
        }

        /// <summary>
        /// Maps all values for each column (mColID, (iVal, mVal))
        /// </summary>
        /// <param name="iCategeries"></param>
        /// <param name="columnMap"></param>
        /// <returns></returns>
        public Dictionary<int, Dictionary<string, string>> MapValues(DataBaseCategories iCategeries, Dictionary<string, int> columnMap)
        {

            Dictionary<int, Dictionary<string, string>> mapping = new Dictionary<int, Dictionary<string, string>>();
            //string[] catNames = this.List.Select(c => c.text).ToArray();
            Dictionary<string, Category> catNames = this.List.ToDictionary(c => c.text, c => c);

            foreach (Category iCat in iCategeries.List)
            {
                if (catNames.ContainsKey(iCat.text))
                {
                    Dictionary<string, string> sMap = GetSubValMap(catNames[iCat.text].subCategories, iCat.subCategories);
                    mapping.Add(columnMap[catNames[iCat.text].name], sMap);
                }
            }

            return mapping;
        }


        /// <summary>
        /// Maps imported value with main value (iVal => mVal)
        /// </summary>
        /// <param name="subCategories"></param>
        /// <param name="iSubCategories"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetSubValMap(IList<SubCategory> subCategories, IList<SubCategory> iSubCategories)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            Dictionary<string, SubCategory> subNames = subCategories.ToDictionary(s => s.text, s => s);


            foreach (SubCategory iSub in iSubCategories)
            {
                if (subNames.ContainsKey(iSub.text))
                {
                    dic.Add(iSub.name, subNames[iSub.text].name);
                }

            }

            return dic;
        }

        public DataBaseCategories CompareManagersData(DataBaseCategories Import)
        {
            DataBaseCategories delta = new DataBaseCategories();

            return delta;
        }
    }
}
