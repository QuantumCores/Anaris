using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANARIS.BLL
{
    [Serializable]
    public class Author
    {
        public Author()
        {

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


        public void Clone(Author toCopy)
        {
            FirstName = toCopy.FirstName;
            LastName = toCopy.LastName;
            CellPhone = toCopy.CellPhone;
            WorkPhone = toCopy.WorkPhone;
            Fax = toCopy.Fax;
            Email = toCopy.Email;
            JobDescription = toCopy.JobDescription;
        }

        /// <summary>
        /// Clears unnecessary spaces in full name string
        /// </summary>
        /// <param name="authors"></param>
        /// <returns></returns>
        public static List<string> FormatAuthorsString(string authors)
        {
            string[] AuthorsList = authors.Split(';');

            for (int i = 0; i < AuthorsList.Count(); i++)
            {
                string help = AuthorsList[i];
                string author = ClearSpaces(help);

                string[] names = author.Split(' ');
                string newAuthor = "";
                for (int j = 0; j < names.Count() - 1; j++)
                {
                    if (names[j] != "")
                    {
                        string name = ClearSpaces(names[j]);
                        newAuthor += name + " ";
                    }
                }
                newAuthor += names[names.Count() - 1];
                AuthorsList[i] = newAuthor;
            }
            return AuthorsList.ToList();
        }

        /// <summary>
        /// Usuwa spaje z poczatku i konca stringa
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        private static string ClearSpaces(string author)
        {
            char znakk = author[author.Length - 1];
            char znako = author[0];
            while (znakk == (char)32)
            {
                string nowy = author.Substring(0, author.Length - 1);
                author = nowy;
                znakk = author[author.Length - 1];
            }

            while (znako == (char)32)
            {
                string nowy = author.Substring(1, author.Length - 1);
                author = nowy;
                znako = author[0];
            }
            return author;
        }

    }
}
