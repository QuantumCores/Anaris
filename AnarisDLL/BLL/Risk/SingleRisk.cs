using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Risk
{
    [Serializable]
    public class SingleRisk
    {
        public string name { get; set; }
        public ObservableCollection<ElementaryRisk> DistinctiveRisk { get; set; }
        public bool Print { get; set; }

        public SingleRisk()
        {
            DistinctiveRisk = new ObservableCollection<ElementaryRisk>();
        }

        public SingleRisk Clone(SingleRisk toCopy)
        {
            DistinctiveRisk.Clear();
            name = toCopy.name;
            Print = toCopy.Print;

            foreach (ElementaryRisk elem in toCopy.DistinctiveRisk)
            {
                ElementaryRisk newone = new ElementaryRisk();
                newone.Clone(elem);
                DistinctiveRisk.Add(elem);
            }

            return this;
        }

    }
}
