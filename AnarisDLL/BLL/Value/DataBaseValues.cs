using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Value
{
    [Serializable]
    public class DataBaseValues
    {
        public string ValuesDescription { get; set; }
        public List<SingleValue> valueList { get; set; }

        public DataBaseValues()
        {
            valueList = new List<SingleValue>();
        }

        public void Clone(DataBaseValues toClone)
        {
            ValuesDescription = toClone.ValuesDescription;
            valueList = toClone.valueList.ToList();
        }

        public bool IsNameUnique(string name)
        {
            foreach (SingleValue sv in valueList)
            {
                if (sv.name == name)
                    return false;
            }
            return true;
        }

        public bool IsTextUnique(string text)
        {
            foreach (SingleValue sv in valueList)
            {
                if (sv.text == text)
                    return false;
            }
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="iValues"></param>
        /// <param name="columnMap"></param>
        /// <param name="valueMap"></param>
        /// <returns></returns>
        public Dictionary<int, Dictionary<string, string>> MapDBValues(List<SingleValue> iValues, int valColIndex, Dictionary<int, Dictionary<string, string>> valueMap = null)
        {
            if (valueMap == null)
            {
                valueMap = new Dictionary<int, Dictionary<string, string>>();
            }

            Dictionary<string, string> sMap = GetSubValMap(valueList, iValues);
            valueMap.Add(valColIndex, sMap);

            return valueMap;
        }


        /// <summary>
        /// Maps imported value with main value (iVal => mVal)
        /// </summary>
        /// <param name="subValue"></param>
        /// <param name="iSubValue"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetSubValMap(List<SingleValue> subValue, List<SingleValue> iSubValue)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            Dictionary<string, SingleValue> subNames = subValue.ToDictionary(s => s.text, s => s);

            foreach (SingleValue iSub in iSubValue)
            {
                if (subNames.ContainsKey(iSub.text))
                {
                    dic.Add(iSub.name, subNames[iSub.text].name);
                }

            }

            return dic;
        }

        //public Dictionary<string, double> GetValuesDictionary()
        //{
        //    Dictionary<string, double> ValuesDictionary = new Dictionary<string, double>();

        //    foreach (SingleValue sv in valueList)
        //    {
        //        ValuesDictionary.Add(sv.name, sv.value);
        //    }

        //    return ValuesDictionary;
        //}
        
    }
}
