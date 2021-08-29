using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnarisDLL.BLL.Database;
using AnarisDLL.BLL.Report;
using AnarisDLL.BLL.Risk;

namespace AnarisDLL.BLL.Anaris
{
    [Serializable]
    public class Anaris
    {
        public ProjectProperties ProjectProperties { get; set; }
        public Database.Database DataBase { get; set; }
        public RiskCollection ScenarioManager { get; set; }
        public RAToSave RiskAnalysis { get; set; }
        public ReportSettings ReportSettings { get; set; }

        public static Anaris Instance { get; set; }

        public Anaris()
        {
            ProjectProperties = new ProjectProperties();
            DataBase = new Database.Database();
            ScenarioManager = new RiskCollection();
            RiskAnalysis = new RAToSave();
            ReportSettings = new ReportSettings();

        }

        public void Initialize(RiskCollection RiskList)
        {
            for (int i = 0; i <= RiskList.Risks.Count; i++)
            {
                RiskDgvList newRisAn = new RiskDgvList();
            }
        }

        public void SetColumnWidths(List<List<double>> gridWidths)
        {
            for (int g = 0; g < RiskAnalysis.RiskAnalysis.Count; g++)
            {
                List<double> widths = gridWidths[g];
                for (int j = 0; j < RiskAnalysis.RiskAnalysis[g].dgvList.Count; j++)
                {
                    AnarisGrid.Dgv dgv = RiskAnalysis.RiskAnalysis[g].dgvList[j];
                    
                    for (int i=0; i<dgv.columns.Count; i++)
                    {
                        dgv.columns[i].width = (int)widths[i];
                    }                   
                }
            }
        }

    }
}
