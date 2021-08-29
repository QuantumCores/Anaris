using AnarisDLL.BLL.Category;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Risk
{
    [Serializable]
    public class RiskCollection
    {
        public List<SingleRisk> Risks { get; set; }
        public static readonly int ScenarioNameLength = 5;

        public RiskCollection()
        {
            Risks = new List<SingleRisk>();
        }

        public void Initialize()
        {
            for (int i = 0; i <= 10; i++)
            {
                SingleRisk nowySi = new SingleRisk();

                if (i == 0) { nowySi.name = "Siły fizyczne"; nowySi.DistinctiveRisk = new ObservableCollection<ElementaryRisk>(); }
                if (i == 1) { nowySi.name = "Przestępstwa"; nowySi.DistinctiveRisk = new ObservableCollection<ElementaryRisk>(); }
                if (i == 2) { nowySi.name = "Ogień"; nowySi.DistinctiveRisk = new ObservableCollection<ElementaryRisk>(); }
                if (i == 3) { nowySi.name = "Woda"; nowySi.DistinctiveRisk = new ObservableCollection<ElementaryRisk>(); }
                if (i == 4) { nowySi.name = "Zagrożenia biologiczne"; nowySi.DistinctiveRisk = new ObservableCollection<ElementaryRisk>(); }
                if (i == 5) { nowySi.name = "Zanieczyszczenia"; nowySi.DistinctiveRisk = new ObservableCollection<ElementaryRisk>(); }
                if (i == 6) { nowySi.name = "Światło i promieniowanie UV"; nowySi.DistinctiveRisk = new ObservableCollection<ElementaryRisk>(); }
                if (i == 7) { nowySi.name = "Niewłaściwa temperatura"; nowySi.DistinctiveRisk = new ObservableCollection<ElementaryRisk>(); }
                if (i == 8) { nowySi.name = "Niewłaściwa wilgotność względna"; nowySi.DistinctiveRisk = new ObservableCollection<ElementaryRisk>(); }
                if (i == 9) { nowySi.name = "Rozproszenie"; nowySi.DistinctiveRisk = new ObservableCollection<ElementaryRisk>(); }
                if (i == 10) { nowySi.name = "Inne"; nowySi.DistinctiveRisk = new ObservableCollection<ElementaryRisk>(); }

                Risks.Add(nowySi);
            }
        }

        //public string GenerateNewName()
        //{
        //    string name = string.Empty;
        //    bool isOriginal = false;

        //    while (!isOriginal)
        //    {
        //        name = AnarisDLL.BLL.Helpers.RandomNameGenerator.Generate(RiskCollection.ScenarioNameLength);
        //        isOriginal = CheckIfNameIsOriginal(name);
        //    }

        //    return name;
        //}

        //private bool CheckIfNameIsOriginal(string name)
        //{
        //    foreach (SingleRisk risk in Risks)
        //    {
        //        foreach (ElementaryRisk scenario in risk.DistinctiveRisk)
        //        {
        //            if (scenario.Name == name)
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}


        public Dictionary<int, IList<ElementaryRisk>> ImportRisks(List<SingleRisk> iRisks)
        {
            Dictionary<int, IList<ElementaryRisk>> result = new Dictionary<int, IList<ElementaryRisk>>();

            for (int i = 0; i < Risks.Count; i++)
            {
                IList<ElementaryRisk> ToImport = new List<ElementaryRisk>();
                string[] Names = Risks[i].DistinctiveRisk.Select(d => d.Name).ToArray();

                for (int j = 0; j < iRisks[i].DistinctiveRisk.Count; j++)
                {
                    if (!Names.Contains(iRisks[i].DistinctiveRisk[j].Name))
                    {
                        //ToImport.Add(iRisks[i].DistinctiveRisk[j]);
                        Risks[i].DistinctiveRisk.Add(iRisks[i].DistinctiveRisk[j]);
                    }
                }

                result.Add(i, ToImport);

            }

            return result;
        }

        public void Clone(RiskCollection toCopy)
        {
            Risks.Clear();
            foreach (SingleRisk risk in toCopy.Risks)
            {
                SingleRisk newone = new SingleRisk();
                newone.Clone(risk);
                Risks.Add(newone);// tutaj zmienic kopiowqanie
            }
        }

        public RiskCollection CompareManagersData(DataBaseCategories Import)
        {
            RiskCollection delta = new RiskCollection();

            return delta;
        }
    }
}
