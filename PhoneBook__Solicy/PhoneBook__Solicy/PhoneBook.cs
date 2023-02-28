using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PhoneBook__Solicy
{
    public class PhoneBook
    {

        public static bool check = true;
        private static string path = Path.Combine(Path.GetFullPath(@"..\..\..\"), @"PhoneFiles\{0}.txt"); private readonly string[] text;
        public PhoneBook(string fileName)
        {
            path = string.Format(path, fileName);
            text = File.ReadAllLines(path);
        }
       

        public void Insertion()
        {
            Console.WriteLine("Please choose an ordering to sort: 'Ascending' or 'Descending'");
            string sortDirection = Console.ReadLine();
            Console.WriteLine("Please choose criteria: 'Name', 'Surname' or 'PhoneNumberCode'.");
            string criteria = Console.ReadLine();

            List<string> textforsort = new List<string>(text);


            if (sortDirection == "Ascending")
            {
                if (criteria == "Name")
                {
                    SortbyNameAsc(textforsort, "Ascending");
                }
                else if(criteria == "Surname")
                {
                    SortbySurnameAsc(textforsort, "Ascending");
                }
                else if (criteria == "PhoneNumberCode")
                {
                    SortByPhoneNumberAsc(textforsort, "Ascending");

                }
                else
                {
                    Console.WriteLine("You entered wrong criteria");
                }

            }
            else if(sortDirection == "Descending")
            {
                if (criteria == "Name")
                {
                    SortbyNameAsc(textforsort, "Descening");
                }
                else if (criteria == "Surname")
                {
                    SortbySurnameAsc(textforsort, "Descending");
                }
                else if(criteria == "PhoneNumberCode")
                {
                    SortByPhoneNumberAsc(textforsort, "Descending");

                }
                else
                {
                    Console.WriteLine("You entered wrong criteria");
                }
            }
            else
            {
                Console.WriteLine("You Entered wrong option");
            }

        }
        public void SortbyNameAsc(List<string> textforsort,string option)
        {
            if (option == "Ascending")
                textforsort = textforsort.OrderBy(x => x).ToList();
            else
                textforsort = textforsort.OrderByDescending(x => x).ToList();
            WriteFile(textforsort);
        }
        public void SortbySurnameAsc(List<string> textforsort,string option)
        {
            List<string> OnlyWithSurname = new List<string>();

            foreach (string item in textforsort)
            {
                string[] parts = item.Split(' ');
                if (parts.Length == 4)
                {
                    OnlyWithSurname.Add(parts[1]);
                }
            }
            if (option == "Ascending")
                OnlyWithSurname = OnlyWithSurname.OrderBy(x=>x).ToList();
            else
                OnlyWithSurname = OnlyWithSurname.OrderByDescending(x=>x).ToList();

            foreach (string item1 in OnlyWithSurname)
            {
                foreach (string item in textforsort)
                {
                    string[] parts = item.Split(' ');
                    if (parts.Length == 4 && parts[1]== item1)
                    {
                        Console.WriteLine(item);
                        break;
                    }
                }
            }
            foreach (string item in textforsort)
            {
                string[] parts = item.Split(' ');
                if (parts.Length == 3)
                {
                    Console.WriteLine(item);
                }
            }



        }

      


        public void SortByPhoneNumberAsc(List<string> textforsort,string option)
        {
            List<string> phonecode = new List<string>();
            foreach (string item in textforsort)
            {
                string[] parts = item.Split(' ');
                if (parts.Length == 4)
                {
                    phonecode.Add(parts[3].Substring(0, 3));
                }

                if(parts.Length == 3)
                {
                    phonecode.Add(parts[2].Substring(0, 3));
                }

            }


            if(option == "Ascending")
                phonecode = phonecode.OrderBy(x => x).ToList();
            else
                phonecode = phonecode.OrderByDescending(x => x).ToList();



            foreach (string item1 in phonecode)
            {
                foreach (string item in textforsort)
                {
                    string[] parts = item.Split(' ');
                    if (parts.Length == 4 && parts[3].Substring(0, 3) == item1)
                    {
                        Console.WriteLine(item);
                        break;
                    }
                    else if (parts.Length == 3 && parts[2].Substring(0, 3) == item1)
                    {
                        Console.WriteLine(item);
                        break;
                    }

                }
            }
        }




        public void WriteFile(List<string> text1)
        {
            foreach (string line in text1)
            {
                Console.WriteLine(line);
            }
        }

        public void PrintMassages()
        {
            int q = 0;
            foreach (string line in text)
            {
                q++;
                string[] parts = line.Split(' ');

                if (parts.Length == 3)
                {
                    if (parts[2].Length != 9)
                    {
                        Console.WriteLine($"Line {q}  phone number should be with 9 digits");
                        check = false;
                    }

                    if (parts[1] != "-" && parts[1] != ":")
                    {
                        Console.WriteLine($"Line {q} : Seperator should be ':' or '-'");
                        check = false;
                    }
                }
                else if(parts.Length == 4)
                {
                    if (parts[3].Length != 9)
                    {
                        Console.WriteLine($"Line {q}  phone number should be with 9 digits");
                        check = false;
                    }

                    if (parts[2] != "-" && parts[2] != ":")
                    {
                        Console.WriteLine($"Line {q} : Seperator should be ':' or '-'");
                        check = false;
                    }
                }
            }
        }


    }
}
