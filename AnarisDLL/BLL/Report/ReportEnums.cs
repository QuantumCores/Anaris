using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Report
{
    public class ReportEnums
    {

        public ReportEnums()
        {

        }

        public const string REPORT = "Report";
        public const string REPORTFORMAT = "ReportFormat";

        #region XMLRegions

        public const string X_TITLE = "Title";
        public const string X_CHAPTERTITLE = "ChapterTitle";
        public const string X_SUBCHAPTERTITLE = "SubChapterTitle";
        public const string X_SUBSUBCHAPTERTITLE = "SubSubChapterTitle";
        //html markup
        public const string X_P= "p";        
        public const string X_BR = "br";        
        public const string X_B = "b";
        public const string X_I = "i";
        public const string X_U = "u";
        public const string X_CENTER = "center";
        public const string X_IMG = "img";
        public const string X_TABLE = "table";
        public const string X_PL = "pl";
        public const string X_UL = "ul";
        public const string X_OL = "ol";
        public const string X_LI = "li";
        public const string X_TEXT = "Text";
        //other
        public const string X_SP = "sp"; //space
        public const string X_VD = "vd"; //vertical distance
        #endregion

        #region Chapters        
        //these are predefined chapetrs
        public const string C_TITLEPAGE = "TitlePage";
        public const string C_ACKNOWLEDGEMENT = "Acknowledgement";
        public const string C_TABLEOFCONTENT = "TableOfContent";
        public const string C_FACTORCHAPTER = "FactorChapter";
        public const string C_SCENARIOCHAPTER = "ScenarioChapter";
        public const string C_SUMMARY = "Summary";
        public const string C_BIBLIOGRAPHY = "Bibliography";
        //these are fully customisable
        public const string C_CHAPTER = "Chapter";
        public const string C_SUBCHAPTER = "Subchapter";
        public const string C_SUBSUBCHAPTER = "SubSubChapter";
        //zrobić jeszcze po chpterze dla poszczególnych czynnikow i scenariuszy? Raczej nie 
        //można np. <FactorChapter index="12DHC3IJ"></FactorChapter> i wiemy że to jest o Siłach fizycznych który ma inne fromatowanie niż pozostałe
        //pdobnie <ScenarioChapter index="12DHC3IJ"></ScenarioChapter>

        #endregion
        //1823
        #region Variables
        public const string V_REPORTTITLE = "Properties.projectName";
        public const string V_INSTITUTENAME = "Properties.Organization.Name";
        public const string V_INSTITUTECITY = "Properties.Organization.City";
        public const string V_INSTITUTEPOST = "Properties.Organization.Postal";
        public const string V_INSTITUTESTREET = "Properties.Organization.Street";
        public const string V_REPORTSCOPE = "Properties.Scope";

        //LIST AUTHORS

        public const string V_AUTHOR_FULLNAME = "Properties.Authors.[{0}].FullName";
        public const string V_AUTHOR_FIRSTNAME = "Properties.Authors.[{0}].FirstName";
        public const string V_AUTHOR_LASTNAME = "Properties.Authors.[{0}].LastName";
        public const string V_AUTHOR_EMAIL = "Properties.Authors.[{0}].Email";
        public const string V_AUTHOR_INFO = "Properties.Authors.[{0}].JobDescription";

        public const string V_CONTRIBUTOR_FULLNAME = "Properties.RiskTeam.[{0}].FullName";
        public const string V_CONTRIBUTOR_FIRSTNAME = "Properties.RiskTeam.[{0}].FirstName";
        public const string V_CONTRIBUTOR_LASTNAME = "Properties.RiskTeam.[{0}].LastName";
        public const string V_CONTRIBUTOR_EMAIL = "Properties.RiskTeam.[{0}].Email";
        public const string V_CONTRIBUTOR_INFO = "Properties.RiskTeam.[{0}].JobDescription";

        public const string L_AUTHORS = "Properties.Authors";
        public const string L_AUTHORS_FULLNAME = "Properties.Authors.[{0}].FullName";
        public const string L_AUTHORS_FIRSTNAME = "Properties.Authors.[{0}].FirstName";
        public const string L_AUTHORS_LASTNAME = "Properties.Authors.[{0}].LastName";
        public const string L_AUTHORS_EMAIL = "Properties.Authors.[{0}].Email";
        public const string L_AUTHORS_INFO = "Properties.Authors.[{0}].JobDescription";

        public const string L_CONTRIBUTORS = "Properties.RiskTeam";
        public const string L_CONTRIBUTORS_FULLNAME = "Properties.RiskTeam.[{0}].FullName";
        public const string L_CONTRIBUTORS_FIRSTNAME = "Properties.RiskTeam.[{0}].FirstName";
        public const string L_CONTRIBUTORS_LASTNAME = "Properties.RiskTeam.[{0}].LastName";
        public const string L_CONTRIBUTORS_EMAIL = "Properties.RiskTeam.[{0}].Email";
        public const string L_CONTRIBUTORS_INFO = "Properties.RiskTeam.[{0}].JobDescription";

        public const string V_DATENOW = "Properties.Today";

        public const string V_DB = "DataBase.riskManager.Risk.[{0}].DistinctiveRisk.[{1}].opisC";
        public const string V_FACTORNAME = "DataBase.riskManager.Risk.[{0}].name";
        public const string V_SCENARIONAME = "DataBase.riskManager.Risk.[{0}].DistinctiveRisk.[{1}].name";
        public const string V_SCENARIODESC = "DataBase.riskManager.Risk.[{0}].DistinctiveRisk.[{1}].opis";
        public const string V_ACOMPDESC = "DataBase.riskManager.Risk.[{0}].DistinctiveRisk.[{1}].opisA";
        public const string V_BCOMPDESC = "DataBase.riskManager.Risk.[{0}].DistinctiveRisk.[{1}].opisB";
        public const string V_CCOMPDESC = "DataBase.riskManager.Risk.[{0}].DistinctiveRisk.[{1}].opisC";

        public const string M_PUTTITLEPAGE = "";
        public const string M_PUTACKNOWLEDGEMENT = "Acknowledgement";
        public const string M_PUTTABLEOFCONTENT = "TableOfContent";
        public const string M_PUTFACTORCHAPTER = "FactorChapter";
        public const string M_PUTSCENARIOCHAPTER = "ScenarioChapter";
        public const string M_PUTSUMMARY = "Summary";
        public const string M_PUTBIBLIOGRAPHY = "Bibliography";
        //these are fully customisable
        public const string M_PUTCHAPTER = "Chapter";
        public const string M_PUTSUBCHAPTER = "Subchapter";
        public const string M_PUTSUBSUBCHAPTER = "SubSubChapter";

        //niektóre właściwości będą musiały być poprzez metody w geter żeby był automat! Chyba że predefiniowane pola np. tabela kategorii i już program wie co wpisać
        //varaible list bierzemy z asembley nazwy które mają pierwsza lietere V i dodajemy na początek XML V_ i mamy porównanie
        #endregion

        #region Elements
        public const string E_TABLE = "Table";
        public const string E_IMAGE = "Image";
        public const string E_Citation = "Citation";
        #endregion

        #region XmlAttributes
        public const string A_TEXT_COLOR = "color";
        public const string A_V_ARG = "arg";
        #endregion


        public List<string> Regions
        {
            get
            {
                Type type = this.GetType();
                List<string> tmp = type.GetMembers().Where(p => p.Name.StartsWith("X_")).Select(m => m.Name.Remove(0, 2)).ToList();
                return tmp;
            }
        }

        public List<string> Chapters
        {
            get
            {
                Type type = this.GetType();
                List<string> tmp = type.GetMembers().Where(p => p.Name.StartsWith("C_")).Select(m => m.Name.Remove(0, 2)).ToList();
                return tmp;
            }
        }

        public List<string> Variables
        {
            get
            {
                Type type = this.GetType();
                List<string> tmp = type.GetMembers().Where(p => p.Name.StartsWith("V_")).Select(m => m.Name.Remove(0, 2)).ToList();
                return tmp;
            }
        }

        public List<string> Lists
        {
            get
            {
                Type type = this.GetType();
                List<string> tmp = type.GetMembers().Where(p => p.Name.StartsWith("L_")).Select(m => m.Name.Remove(0, 2)).ToList();
                return tmp;
            }
        }

        public List<string> Methods
        {
            get
            {
                Type type = this.GetType();
                List<string> tmp = type.GetMembers().Where(p => p.Name.StartsWith("M_")).Select(m => m.Name.Remove(0, 2)).ToList();
                return tmp;
            }
        }

        public List<string> Elements
        {
            get
            {
                Type type = this.GetType();
                List<string> tmp = type.GetMembers().Where(p => p.Name.StartsWith("E_")).Select(m => m.Name.Remove(0, 2)).ToList();
                return tmp;
            }
        }

        public static string GetVariablePath(string name)
        {
            string path = string.Empty;
            ReportEnums enums = new ReportEnums();
            Type type = enums.GetType();
            MemberInfo member = type.GetMembers().Where(p => p.Name == name).FirstOrDefault();
            path = (string)((FieldInfo)member).GetValue(enums);

            return path;
        }

    }
}
