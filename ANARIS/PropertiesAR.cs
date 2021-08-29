using ANARIS.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANARIS
{
    public partial class PropertiesAR : Form, ANS_View
    {
        ANS_Controller _controller;
        ProjectProperties properties;
        ProjectProperties tmpProperties;

        public PropertiesAR(ProjectProperties _properties)
        {
            InitializeComponent();
            properties = _properties;
            tmpProperties = new ProjectProperties();
            tmpProperties.Clone(_properties);
            acReportTeam.lbl_authors.Text = "Autorzy raportu:";
            acRiskTeam.lbl_authors.Text = "Zespół oceniający ryzyko:";
            acReportTeam.BindDataSources(tmpProperties.Authors);
            acRiskTeam.BindDataSources(tmpProperties.RiskTeam);

        }

        public void setController(ANS_Controller cont)
        {
            _controller = cont;
        }

        private void PropertiesAR_Load(object sender, EventArgs e)
        {
            txt_projectName.Text = properties.projectName;
            txt_path.Text = properties.filePath;
            txt_createdOn.Text = properties.creationTime.ToString("yyyy-MM-dd HH:mm:ss");
            txt_scope.Text = properties.Scope;
            txt_OrgName.Text = properties.Organization.Name;
            txt_Postal.Text = properties.Organization.Postal;
            txt_Street.Text = properties.Organization.Street;
            txt_City.Text = properties.Organization.City;
            txt_modifiedOn.Text = properties.modifiedTime.ToString("yyyy-MM-dd HH:mm:ss");
            txt_ReportIntro.Text = properties.ReportIntro;

            acReportTeam.AddAuthors(properties.Authors);
            acRiskTeam.AddAuthors(properties.RiskTeam);           
            
        }
        

        private void btn_save_Click(object sender, EventArgs e)
        {
            properties.Clone(tmpProperties);
            properties.projectName = txt_projectName.Text;
            properties.filePath = txt_path.Text;
            properties.Scope = txt_scope.Text;
            properties.Organization.Name = txt_OrgName.Text;
            properties.Organization.Postal = txt_Postal.Text;
            properties.Organization.Street = txt_Street.Text;
            properties.Organization.City = txt_City.Text;
            properties.ReportIntro = txt_ReportIntro.Text;

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            
            tmpProperties.Clone(properties);
            txt_projectName.Text = properties.projectName;
            txt_path.Text = properties.filePath;
            txt_createdOn.Text = properties.creationTime.ToString("yyyy-MM-dd HH:mm:ss");
            txt_scope.Text = properties.Scope;
            txt_OrgName.Text = properties.Organization.Name;
            txt_Postal.Text = properties.Organization.Postal;
            txt_Street.Text = properties.Organization.Street;
            txt_City.Text = properties.Organization.City;
            txt_modifiedOn.Text = properties.modifiedTime.ToString("yyyy-MM-dd HH:mm:ss");
            txt_ReportIntro.Text = properties.ReportIntro;
            
            acReportTeam.AddAuthors(properties.Authors);
            acRiskTeam.AddAuthors(properties.RiskTeam);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.ShowHideARProperties();
        }
    }
}
