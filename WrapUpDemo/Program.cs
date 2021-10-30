using System;
using System.Collections.Generic;
using System.IO;

namespace WrapUpDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //List<PersonModel> people = new List<PersonModel>
            //{ 
            // new PersonModel("Time","COrey","cbautista23343@gmail.com"),
            // new PersonModel("Charlie","corey","cbauti@gmail.com"),
            // new PersonModel("Welsye","COrey","dfakdfj@gmail.com")
            //};

            List<CarModel> cars = new List<CarModel>
            {

                new CarModel{Manufacturer="toyota",Model="Corrola"},
                 new CarModel{Manufacturer="Honda",Model="Accord"},
                  new CarModel{Manufacturer="Ford",Model="Mustang"}
            };

            cars.SaveToCsv(@"c:\Temp\carsto.csv");
            Console.ReadLine();
        }


    }


    public static class DataAccess 
    {
        public static void SaveToCsv<T>(this List<T> items, string filePath) where T:new()
        {
            List<string> rows = new List<string>();
            T entry = new T();
            var cols = entry.GetType().GetProperties();

            string row = "";

            foreach (var col in cols)
            {
                row += $",{col.Name}";
            }

            row = row.Substring(1);

            rows.Add(row);

            foreach (var item in items)
            {
                row = "";
                foreach (var col in cols)
                {
                    row += $",{col.GetValue(item,null)}";
                }
                row = row.Substring(1);
                rows.Add(row);

            }

            File.WriteAllLines(filePath, rows);
        }
    }
}
