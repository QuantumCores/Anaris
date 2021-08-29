using AnarisDLL.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Anaris
{
    public class ProjectProperties
    {
        public string ProjectName { get; set; }
        public string ProgramVersion { get; set; }
        public string FilePath { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public List<Author> Authors { get; set; }
        public List<Author> RiskTeam { get; set; }
        public List<Author> External { get; set; }
        public List<Author> Other { get; set; }
        public Organization Organization { get; set; }
        public string Scope { get; set; }
        public string ReportIntro { get; set; }
        public string Culture { get; set; }

        public string Today
        {
            get
            {
                DateTime now = DateTime.Now;
                return string.Format("{0} {1} {2}", now.Day, now.GetPolishMonthInBiernik(), now.Year);
            }
        }
        public string AuthorsAsString
        {
            get
            {
                return string.Join(", ", Authors.Select(a => a.FullName));
            }
        }

        public string ContributorsAsString
        {
            get
            {
                return string.Join(", ", RiskTeam.Select(a => a.FullName));
            }
        }

        public ProjectProperties()
        {
            Authors = new List<Author>();
            RiskTeam = new List<Author>();
            External = new List<Author>();
            Other = new List<Author>();
            Organization = new Organization();
        }

        internal void Clear()
        {
            ProjectName = "";
            ProgramVersion = "";
            FilePath = "";
            CreationTime = DateTime.Now;
            ModifiedTime = DateTime.Now;
            Authors.Clear();
            Organization = new Organization();
        }

        public ProjectProperties Clone(ProjectProperties toCopy)
        {
            ProjectName = toCopy.ProjectName;
            ProgramVersion = toCopy.ProgramVersion;
            FilePath = toCopy.FilePath;
            CreationTime = new DateTime(toCopy.CreationTime.Year, toCopy.CreationTime.Month, toCopy.CreationTime.Day, toCopy.CreationTime.Hour, toCopy.CreationTime.Minute, toCopy.CreationTime.Second);
            ModifiedTime = new DateTime(toCopy.ModifiedTime.Year, toCopy.ModifiedTime.Month, toCopy.ModifiedTime.Day, toCopy.ModifiedTime.Hour, toCopy.ModifiedTime.Minute, toCopy.ModifiedTime.Second);
            Scope = toCopy.Scope;
            Organization.Clone(toCopy.Organization);
            ReportIntro = toCopy.ReportIntro;

            Authors = toCopy.Authors.ToList();            
            RiskTeam = toCopy.RiskTeam.ToList();

            return this;
        }
    }
}
