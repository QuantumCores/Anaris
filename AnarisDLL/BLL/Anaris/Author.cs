using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Anaris
{
    [Serializable]
    public class Author
    {
        public Author()
        {
            Organization = new Organization();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public string CellPhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public Organization Organization { get; set; }
        public string JobDescription { get; set; }


        public Author Clone(Author toCopy)
        {
            FirstName = toCopy.FirstName;
            LastName = toCopy.LastName;
            CellPhone = toCopy.CellPhone;
            WorkPhone = toCopy.WorkPhone;
            Fax = toCopy.Fax;
            Email = toCopy.Email;
            JobDescription = toCopy.JobDescription;

            return this;
        }        

    }
}
