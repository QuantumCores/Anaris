using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANARIS
{
    //klasa dziedziczy po Form i ANS_View
    public partial class MainWindow : Form, ANS_View
    {
        public ANS_Controller _controller;

        public MainWindow(string programVersion)
        {
            InitializeComponent();
            riskTableMnu.Checked = false;
            valueTableMnu.Checked = false;
            categoryTableMnu.Checked = false;
            riskTableMnu.Enabled = false;
            valueTableMnu.Enabled = false;
            categoryTableMnu.Enabled = false;
            mnuSave.Enabled = false;
            mnuSaveAR.Enabled = false;
            newRAmnu.Enabled = true;
            newRAmnu.Enabled = true;
            //propertiesDBMnu.Enabled = false;
            propertiesARMnu.Enabled = false;
            btnMergeAR.Enabled = false;
            reportFormBtn.Enabled = false;
            btn_generateReport.Enabled = false;
            btn_exportDB.Enabled = false;
            btn_mergeDB.Enabled = false;

            reportFormBtn.Enabled = false;
            tornadoChartBtn.Enabled = false;
            ValuePieChartBtn.Enabled = false;
            btnTabNiepewnosci.Enabled = false;

            mnuUndo.Enabled = false;
            mnuCut.Enabled = false;
            mnuCopy.Enabled = false;
            mnuPaste.Enabled = false;

            this.KeyPreview = true;
            //this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);

            this.Text = "AnaRis - " + programVersion;
        }

        public void setController(ANS_Controller cont)
        {
            _controller = cont;
        }


        #region MainWindow Menu Handlers
        private void mnuQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy napewno chcesz zamknąć program?", "Wyjdź", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                Application.Exit();

            }
        }

        /*private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)//potrzeba dopisać w configu metodę
        {            
            if (MessageBox.Show("Czy napewno chcesz zamknąć program?", "Wyjdź", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                Application.Exit();

            }
        }*/

        private void mnuCut_Click(object sender, EventArgs e)
        {

        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {

        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {

        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {

        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            string openedFileName = "";

            openFD.InitialDirectory = "C:";
            openFD.Title = "Otwórz bazę danych Anaris";
            openFD.FileName = "";
            openFD.Filter = "Anaris Pliki|*.anrb|Word Documents|*.doc";


            if (openFD.ShowDialog() != DialogResult.Cancel)
            {
                _controller.DBLoadStatus = 1;
                _controller.openDataBaseProject(this);
                _controller.filePath = openFD.FileName;
                EnebleDBMenuTools();
                _controller.initializeCategoryManager(this);
                _controller.LoadDataBase(openFD.FileName, 0);
                _controller.initializeValueManager(this);

                _controller.setNewCategories();
                _controller.initializeRiskManager(this);
                _controller.initializeValuePieChart(this);
                mnuOpen.Enabled = false;
                newDBmnu.Enabled = false;
                _controller.DBLoadStatus = 0;
            }
        }

        private void mnuOpenAR_Click(object sender, EventArgs e)
        {
            string openedFileName = "";

            openFD.InitialDirectory = "C:";
            openFD.Title = "Otwórz analizę ryzyka Anaris";
            openFD.FileName = "";
            openFD.Filter = "Anaris Pliki|*.anrs|Word Documents|*.doc";


            if (openFD.ShowDialog() != DialogResult.Cancel)
            {
                _controller.ARLoadStatus = 1;
                _controller.filePath = openFD.FileName;
                _controller.openAnarisProject(this);
                EnebleARMenuTools();
                _controller.initializeCategoryManager(this);
                _controller.LoadAnarisProject(openFD.FileName);
                _controller.initializeValueManager(this);

                _controller.setNewCategories();
                _controller.initializeRiskManager(this);
                _controller.initializeTornadoChart(this);
                _controller.initializeThresholdChart(this);
                _controller.initializeReportForm(this);
                _controller.initializeValuePieChart(this);
                _controller.initializePropertiesAR(this);
                mnuOpenAR.Enabled = false;
                newRAmnu.Enabled = false;
                propertiesARMnu.Enabled = true;
                _controller.ARLoadStatus = 0;
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            string savedFileName = "";

            saveFD.InitialDirectory = (_controller.filePath == "") ? "C:" : _controller.filePath;
            saveFD.Title = "Zapisz projekt jako";
            saveFD.FileName = "";

            saveFD.Filter = "Anaris Pliki|*.anrb| Wszystkie Pliki|*.*";

            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                _controller.SaveDataBase(saveFD.FileName);
            }

        }

        private void mnuSaveAR_Click(object sender, EventArgs e)
        {
            saveFD.InitialDirectory = (_controller.filePath == "") ? "C:" : _controller.filePath;
            //saveFD.InitialDirectory = "C:";
            saveFD.Title = "Zapisz projekt jako";
            saveFD.FileName = "";

            saveFD.Filter = "Anaris Pliki|*.anrs| Wszystkie Pliki|*.*";

            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                _controller.SaveARProject(saveFD.FileName);
            }
        }

        private void newDBmnu_Click(object sender, EventArgs e)
        {
            NewDBDialog getNewProjectInitialData = new NewDBDialog();
            getNewProjectInitialData.setController(_controller);
            getNewProjectInitialData.ShowDialog();

            if (getNewProjectInitialData.DialogResult == DialogResult.OK)
            {
                _controller.newDataBaseProject(this);
                //_controller.setNewValues();
                _controller.initializeRiskManager(this);
                _controller.initializeValueManager(this);
                _controller.initializeCategoryManager(this);

                dbBasicInfo dbBI = new dbBasicInfo();
                dbBI.dbFileName = getNewProjectInitialData.projectFileName;
                //List<string> nowa = dbBI.formatAuthorsString(getNewProjectInitialData.projectAuthorName);
                //dbBI.dbAuthorsList.AddRange(nowa);
                dbBI.dbDirrectory = getNewProjectInitialData.projectDirrectory;
                _controller.filePath = Path.Combine(getNewProjectInitialData.projectDirrectory, getNewProjectInitialData.projectFileName + ".anrb");
                dbBI.dbOrganisationName = getNewProjectInitialData.projectOrganisationName;
                dbBI.dbMuseumName = getNewProjectInitialData.projMuseumName;
                dbBI.dbMuseumAdres = getNewProjectInitialData.projMuseumAdres;
                _controller.dbBasicInfo.setBasicInfo(dbBI);

                _controller.initializeValuePieChart(this);

                this.EnebleDBMenuTools();
                mnuOpen.Enabled = false;
                newDBmnu.Enabled = false;
            }
        }


        private void newRAmnu_Click(object sender, EventArgs e)
        {
            NewARDialog newProject = new NewARDialog();
            newProject.ShowDialog();

            if (newProject.DialogResult == DialogResult.OK)
            {
                _controller.arBasicInfo = newProject.properties;
                _controller.filePath = Path.Combine(newProject.properties.filePath, newProject.properties.projectName + ".anrs");
                Console.WriteLine("Window before starting managers");
                _controller.newAnarisProject(this);

                _controller.initializeRiskManager(this);
                _controller.initializeValuePieChart(this);
                _controller.initializeValueManager(this);
                _controller.initializeCategoryManager(this);
                _controller.initializeTornadoChart(this);
                _controller.initializeThresholdChart(this);
                _controller.initializePropertiesAR(this);
                _controller.initializeARData();
                Console.WriteLine("Window all managers started");
                this.EnebleARMenuTools();
            }

        }


        //Aktywujemy menu potrzebne do projektu
        private void EnebleDBMenuTools()
        {
            riskTableMnu.Enabled = true;
            valueTableMnu.Enabled = true;
            categoryTableMnu.Enabled = true;
            mnuSave.Enabled = true;
            newRAmnu.Enabled = false;
            //propertiesDBMnu.Enabled = true;
            ValuePieChartBtn.Enabled = true;
            mnuOpenAR.Enabled = false;
            riskTableMnu.Enabled = false;
            btnMergeAR.Enabled = false;
            reportFormBtn.Enabled = false;
            btn_generateReport.Enabled = false;
            btn_mergeDB.Enabled = true;
        }

        private void EnebleARMenuTools()
        {
            newDBmnu.Enabled = false;
            riskTableMnu.Enabled = true;
            valueTableMnu.Enabled = true;
            categoryTableMnu.Enabled = true;
            mnuSaveAR.Enabled = true;
            mnuOpenAR.Enabled = false;
            mnuOpen.Enabled = false;
            newRAmnu.Enabled = false;
            reportFormBtn.Enabled = true;
            btn_generateReport.Enabled = true;
            btn_exportDB.Enabled = true;

            propertiesARMnu.Enabled = true;
            reportFormBtn.Enabled = true;
            tornadoChartBtn.Enabled = true;
            ValuePieChartBtn.Enabled = true;
            btnTabNiepewnosci.Enabled = true;
        }

        private void riskTableMnu_Click(object sender, EventArgs e)
        {
            _controller.ShowHideRiskManager();
        }

        private void valueTableMnu_Click(object sender, EventArgs e)
        {
            //valueTableMnu.Checked = !valueTableMnu.Checked;
            _controller.ShowHideValueManager();
        }

        private void categoryTableMnu_Click(object sender, EventArgs e)
        {
            //categoryTableMnu.Checked = !categoryTableMnu.Checked;
            _controller.ShowHideCategoryManager();
        }

        #endregion

        #region Database Project Events

        public void dataBaseProjectClosed()
        {
            mnuSave.Enabled = false;
            mnuOpen.Enabled = true;
            riskTableMnu.Enabled = false;
            valueTableMnu.Enabled = false;
            categoryTableMnu.Enabled = false;
            riskTableMnu.Checked = false;
            valueTableMnu.Checked = false;
            categoryTableMnu.Checked = false;
            newDBmnu.Enabled = true;
            newRAmnu.Enabled = true;
            mnuOpenAR.Enabled = true;
            ValuePieChartBtn.Enabled = false;
            btnMergeAR.Enabled = false;
            btn_exportDB.Enabled = false;
            btn_mergeDB.Enabled = false;
            //propertiesDBMnu.Enabled = false;

        }

        #endregion


        public void anarisProjectClosed()
        {
            mnuSave.Enabled = false;
            mnuOpen.Enabled = true;
            riskTableMnu.Enabled = false;
            valueTableMnu.Enabled = false;
            categoryTableMnu.Enabled = false;
            riskTableMnu.Checked = false;
            valueTableMnu.Checked = false;
            categoryTableMnu.Checked = false;
            newDBmnu.Enabled = true;
            newRAmnu.Enabled = true;
            mnuSaveAR.Enabled = false;
            mnuOpenAR.Enabled = true;
            btn_generateReport.Enabled = false;
            //propertiesDBMnu.Enabled = false;

            propertiesARMnu.Enabled = false;
            reportFormBtn.Enabled = false;
            tornadoChartBtn.Enabled = false;
            ValuePieChartBtn.Enabled = false;
            btnTabNiepewnosci.Enabled = false;
            btnMergeAR.Enabled = false;
        }

        public void showErrorMessage(string msg)
        {
            MessageBox.Show(msg);

        }

        private void logsBtn_Click(object sender, EventArgs e)
        {
            _controller.logWindow.Show();

        }

        private void tornadoChartBtn_Click(object sender, EventArgs e)
        {
            _controller.ShowHideTornadoChart();
        }

        private void wykresNiepewnościToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.ShowHideThresholdChart();
        }

        private void ValuePieChartBtn_Click(object sender, EventArgs e)
        {
            _controller.ShowHideValuePieChart();
        }

        private void reportFormBtn_Click(object sender, EventArgs e)
        {
            _controller.ShowHideReportForm();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.S && !e.Alt)
            {
                if (_controller.anarisProject == null && _controller.newDataBase != null)
                {
                    _controller.SaveDataBase(_controller.filePath);
                    MessageBox.Show("Zapisano bazę danych.");
                    //System.Threading.Thread.Sleep(500);
                }
                else if (_controller.anarisProject != null && _controller.newDataBase == null)
                {
                    _controller.SaveARProject(_controller.filePath);
                    MessageBox.Show("Zapisano analizę ryzyka.");
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas próby zapisu. Nie Wiadomo czy program ma zapisać bazę danych czy analizę ryzyka.");
                }


            }
        }

        private void propertiesARMnu_Click(object sender, EventArgs e)
        {
            _controller.ShowHideARProperties();
        }

        private void generujRaportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.generateReport();
        }

        private void btn_exportDB_Click(object sender, EventArgs e)
        {
            saveFD.InitialDirectory = "C:";
            saveFD.Title = "Zapisz projekt jako";
            saveFD.FileName = "";

            saveFD.Filter = "Anaris Pliki|*.anrb| Wszystkie Pliki|*.*";

            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                _controller.SaveDataBase(saveFD.FileName);
            }
        }

        private void btn_mergeDB_Click(object sender, EventArgs e)
        {
            MergeDB merge = new MergeDB();
            bool importAll = false;
            string path = string.Empty;


            if (merge.ShowDialog() == DialogResult.OK)
            {
                path = merge.txt_dir.Text;
                importAll = merge.rd_all.Checked;
                //_controller.MergeDataBases(@"C:\Users\Primus\Desktop\Anaris\ImportDB.anrb", importAll);
                _controller.MergeDataBases(path, importAll);
            }



        }

        private void btnMergeAR_Click(object sender, EventArgs e)
        {
            _controller.MergeAnarisProjects(@"C:\Users\Primus\Desktop\Anaris\ImportAR.anrs", false);

        }
    }
}
