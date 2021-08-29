using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisDLL.BLL.Helpers
{
    public class RandomNameGenerator
    {
        //DateTime now = DateTime.UtcNow;
        //Random rnd = new Random(now.Hour * 60 * 60 + now.Minute * 60 + now.Second);
        //DateTime now = DateTime.UtcNow;
        public static Random rnd = new Random(DateTime.UtcNow.Minute * 60 + DateTime.UtcNow.Second);

        public static string Generate(int length)
        {
            int liczba;
            char znak;
            string nazwa = "";

            for (int i = 0; i < length; i++)
            {
                do { liczba = RandomNameGenerator.rnd.Next(48, 123); }
                while (liczba < 48 || (liczba > 57 && liczba < 65) || (liczba > 90 && liczba < 97));// || liczba > 122);

                znak = (char)liczba;
                nazwa += znak;
            }

            return nazwa;
        }

        public static string GenerateAndCheck<T>(IList<T> collection, int nameLength) where T : IIdentifier
        {
            bool isOriginal = false;
            string name = "";

            while (!isOriginal)
            {
                name = RandomNameGenerator.Generate(nameLength);
                isOriginal = CheckIfNameIsOriginal<T>(collection, name);
            }

            return name;
        }

        public static bool CheckIfNameIsOriginal<T>(IList<T> collection, string name) where T : IIdentifier
        {

            foreach (T thing in collection)
            {
                if (thing.Name == name)
                {
                    return false;
                }
            }

            return true;
        }

        public interface IIdentifier
        {
            string Name { get; set; }
        }

    }
}
