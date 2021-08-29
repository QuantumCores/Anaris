using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANARIS.BLL
{
    [Serializable]
    public class Organization
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public string Street { get; set; }

        public Organization()
        {

        }

        public override string ToString()
        {
            return string.Format("{0}" + Environment.NewLine + "{1}" + Environment.NewLine + "{2} {3}", Name , Street, Postal , City );            
        }

        public void Clone(Organization toCopy)
        {
            Name = toCopy.Name;
            City = toCopy.City;
            Postal = toCopy.Postal;
            Street = toCopy.Street;
        }
    }
}
