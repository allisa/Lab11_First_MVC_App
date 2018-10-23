using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11_First_MVC_App.Models
{
    public class TimePerson
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        /// <summary>
        /// method to take information from csv file and create a list type
        /// </summary>
        /// <param name="begYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        public static List<TimePerson> GetPersons(int begYear, int endYear)
        {
            //instantiate a new list
            List<TimePerson> people = new List<TimePerson>();
            //create path to csv file holding the time people information. then reads file
            string path = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            string[] myFile = File.ReadAllLines(newPath);

            //loop to go through my file and assign the fields from the csv to the columns we want to show 
            for (int i = 1; i < myFile.Length; i++)
            {
                string[] fields = myFile[i].Split(',');
                people.Add(new TimePerson
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }

            //linq query
            List<TimePerson> listofPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();
            return listofPeople;
        }
    }
}
