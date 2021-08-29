using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnarisEvo.Services
{
    class Test
    {
        public class CirclePerimeter    // klasa obwód ko³a
        {
            double sqr2 = Math.Sqrt(2);     // wartosc pierwiasta z 2
            double piValue = Math.PI;       // wartosc liczby PI
            int countTotal = 1;             // licznik kompletow zestawów
            string choice;                  // wybor usera czy cche wprowadzic kolejne zestawy danych
            int g = 0;                      // licznik zestawów

            public void calculatePerimeter()
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Podaj iloœæ zestawów w {0} pakiecie: ", countTotal);
                        string amountPackage = Console.ReadLine();
                        Console.WriteLine("Podaj {0} wartosci do zestawu: ", amountPackage);
                        short max = short.Parse(amountPackage);
                        double[] dataTable = new double[max];

                        for (short i = 0; i < max; i++)
                        {
                            string squareSide = Console.ReadLine();
                            dataTable[i] = double.Parse(squareSide);
                        }

                        foreach (double j in dataTable)
                        {
                            g++;
                            Console.WriteLine("Linia {0}\t{1}\t{2}\t\t{3}\n", g, j, Math.Round((sqr2 * j * piValue), 5), Math.Round((j * piValue), 5));
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine("Czy chesz wprowadziæ kolejne zestawy? Y/N?");
                    choice = Console.ReadLine();
                    countTotal++;
                } while (choice == "Y" || choice == "y");
            }
        }
    }

    public class CirclePerimeter    // klasa obwód ko³a  - dane wprowadzane z klawiatury
    {
        double piSqr2 = Math.Sqrt(2) * Math.PI;     // wartosc pierwiasta z 2
        const double piValue = Math.PI;       // wartosc liczby PI
        int countTotal = 1;             // licznik kompletow zestawów
        string choice;                  // wybor usera czy cche wprowadzic kolejne zestawy danych
        int g = 0;                      // licznik zestawów

        public void calculatePerimeter()
        {
            Stopwatch sw = new Stopwatch();
            do
            {
                try
                {
                    bool sukces = false;
                    short max;

                    do
                    {
                        Console.WriteLine("Podaj iloœæ zestawów w {0} pakiecie: ", countTotal);
                        string amountPackage = Console.ReadLine();
                        sukces = short.TryParse(amountPackage, out max);

                        if (sukces)
                        {
                            Console.WriteLine("Podaj {0} wartosci do zestawu nr {1}: ", amountPackage, countTotal);
                        }
                        else
                        {
                            Console.WriteLine("wprowadzonych danych nie da siê konwertowaæ na liczbê typu short\nwprowadŸ poprawn¹ wartoœæ");
                        }
                    }
                    while (!sukces);

                    double[] dataTable = new double[max];

                    for (short i = 0; i < max; i++)
                    {
                        do
                        {
                            string squareSide = Console.ReadLine();
                            sukces = (double.TryParse(squareSide, out dataTable[i]));
                            if (sukces)
                            {

                            }
                            else
                            {
                                Console.WriteLine("wprowadzonych danych nie da siê konwertowaæ na liczbê typu double\nwprowadŸ poprawn¹ wartoœæ");
                            }
                        }
                        while (!sukces);
                    }
                    sw.Start();

                    foreach (double j in dataTable)
                    {
                        g++;
                        Console.WriteLine("Linia_{0}\t\t{1}\t\t{2}\t\t{3}\n", g, j, Math.Round((piSqr2 * j), 5), Math.Round((j * piValue), 5));
                    }
                    g = 0;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                sw.Stop();

                Console.WriteLine("Elapsed={0}", sw.Elapsed);

                Console.WriteLine("Czy chesz wprowadziæ kolejne zestawy? Y/N?");
                choice = Console.ReadLine();
                countTotal++;

            } while (choice == "Y" || choice == "y");
        }
    }

    public class CirclePerimeterFile    // klasa obwód ko³a - dane wprowadzane z pliku
    {
        double piSqr2 = Math.Sqrt(2) * Math.PI;     // wartosc pierwiasta z 2
        const double piValue = Math.PI;       // wartosc liczby PI
        int countTotal = 1;             // licznik kompletow zestawów
        int g = 0;                      // licznik zestawów


        public void calculatePerimeter()
        {
            Stopwatch sw = new Stopwatch();
            bool sukces = true;
            short max;


            Console.WriteLine("Podaj nazwê pliku tekstowego razem z rozszerzeniem, w którym znajduj¹ siê dane do wczytania: ");
            string fileName = Console.ReadLine();

            try
            {
                File.Exists(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            StreamReader file = new StreamReader(fileName);                        

            if (sukces)
            {
                string amountPackage;
                sw.Start();                     // start licznika czasu pracy 

                while ((amountPackage = file.ReadLine()) != null)
                {
                    try
                    {
                        do
                        {

                            sukces = (short.TryParse(amountPackage, out max));
                            if (sukces)
                            {
                                Console.WriteLine("\nIloœæ zestawów w {0} pakiecie wynosi: {1} \n", countTotal, max);
                                countTotal++;
                            }
                            else
                            {
                                Console.WriteLine("wprowadzonych danych nie da siê konwertowaæ na liczbê typu short\nzosta³a pobrana kolejna wartoœc z pliku");
                                amountPackage = file.ReadLine();
                            }
                        }
                        while (!sukces);
                        sukces = false;

                        double[] dataTable = new double[max];
                        string squareSide;

                        for (short i = 0; i < max; i++)
                        {
                            do
                            {
                                squareSide = file.ReadLine();
                                sukces = double.TryParse(squareSide, out dataTable[i]);
                                if (sukces)
                                {

                                }
                                else
                                {
                                    Console.WriteLine("wprowadzonych danych nie da siê konwertowaæ na liczbê typu double\nzosta³a pobrana kolejna wartoœc z pliku");

                                    if (squareSide == null)
                                    {
                                        Console.WriteLine("W pliku zabraklo danych w zestawie nr {0}\n brakujace dane zastaly napisane zerami", countTotal - 1);
                                        break;
                                    }
                                    squareSide = file.ReadLine();
                                }
                            }
                            while ((!sukces) || squareSide == null);
                        }


                        foreach (double j in dataTable)
                        {
                            g++;
                            Console.WriteLine("Linia_{0}\t\t{1}\t\t{2}\t\t{3}\n", g, j, Math.Round((piSqr2 * j), 5), Math.Round((j * piValue), 5));
                            // Console.WriteLine("Linia_{0}\t\t{1}\t\t{2:N5}\t\t{3:N5}\n", g, j, (piSqr2 * j), (j * piValue));
                        }
                        g = 0;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                file.Close();
                sw.Stop();
                Console.WriteLine("Elapsed={0}", sw.Elapsed);
            }
        }
    }
}
