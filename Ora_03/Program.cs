using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace XML_JSON_LINQ_02
{
    class Cd
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }

        public Cd()
        {

        }
    }

    class Country
    {
        public string Name { get; set; }
        public int CdCount { get; set; }
        public double AvgPrice { get; set; }
        public List<string> Artists { get; set; }

        public Country()
        {
            Artists = new List<string>();
        }
    }

    class Program
    {
        static List<Cd> DeserializeJSON(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Cd>>(json);
        }

        static List<Cd> DeserializeXML(string path)
        {
            List<Cd> result = new List<Cd>();

            XDocument xdoc = XDocument.Load(path);

            foreach (var item in xdoc.Root.Elements())
            {
                result.Add(new Cd()
                {
                    Title = item.Element("TITLE").Value,
                    Artist = item.Element("ARTIST").Value,
                    Country = item.Element("COUNTRY").Value,
                    Company = item.Element("COMPANY").Value,
                    Price = double.Parse(item.Element("PRICE").Value),
                    Year = int.Parse(item.Element("YEAR").Value)
                });
            }

            return result;
        }

        
        static void SerializeJson(List<Country> list)
        {
            string json = JsonConvert.SerializeObject(list,Formatting.Indented);
            File.WriteAllText("output.json", json);
        }


        static void SerializeXML(List<Country> list)
        {
            XDocument xdoc = new XDocument();

            xdoc.Add(new XElement("countries"));

            foreach (var country in list)
            {
                XElement xcountry = new XElement("country");
                xcountry.Add(new XElement("name", country.Name));
                xcountry.Add(new XElement("cdCount", country.CdCount));
                xcountry.Add(new XElement("avgPrice", country.AvgPrice));

                XElement xartists = new XElement("artists",new XAttribute("listCount", country.Artists.Count));
                

                foreach (var artist in country.Artists)
                {
                    xartists.Add(new XElement("artist", artist));
                }

                xcountry.Add(xartists);
                xdoc.Root.Add(xcountry);
            }

            xdoc.Save("output.xml");
        }


        static void Main(string[] args)
        {
            List<Cd> list = DeserializeJSON("cd_catalog.json");
            //List<Cd> xmlList = DeserializeXML("cd_catalog.xml");

            var t1 = list.Select(x => x.Title).ToList();
            var t1q = (from x in list
                      select x.Title).ToList();


            var t2 = list.Select(x => new
            {
                TTILE = x.Title,
                YEAR = x.Year
            }).OrderBy(x => x.YEAR).ToList();

            var t2q = (from x in list
                       orderby x.Year
                       select new
                       {
                           TTILE = x.Title,
                           YEAR = x.Year
                       }).ToList();



            var t3 = list.Where(x => x.Price > 10).ToList();

            var t3q = (from x in list
                       where x.Price > 10
                       select x).ToList();


            var t4 = list.Where(x => x.Year > 1995 && x.Country == "EU").Select(x => new
            {
                TITLE = x.Title,
                ARTIST = x.Artist,
                PRICE = x.Price
            }).ToList();


            var t4q = (from x in list
                       where x.Year > 1995 && x.Country == "EU"
                       select new
                       {
                           TITLE = x.Title,
                           ARTIST = x.Artist,
                           PRICE = x.Price
                       }).ToList();

            

            var t5 = list.Count(x => x.Country == "USA");

            var t5q = (from x in list
                       where x.Country == "USA"
                       select x).Count();


            var t6 = list.GroupBy(x => x.Country).Select(x => new
            {
                COUNTRYNAME = x.Key,
                COUNT = x.Count()
            });


            var t6q = (from x in list
                       group x by x.Country into g
                       select new
                       {
                           COUNTRYNAME = g.Key,
                           COUNT = g.Count()
                       }).ToList();


            var t7 = list.GroupBy(x => x.Year).Select(x => new
            {
                YEAR = x.Key,
                AVG = Math.Round(x.Average(y => y.Price), 2)
            }).ToList();


            var t7q = (from x in list
                       group x by x.Year into g
                       select new
                       {
                           YEAR = g.Key,
                           AVG = Math.Round(g.Average(y => y.Price), 2)
                       }).ToList();


            var t8 = list.GroupBy(x => x.Country).Select(x => new Country()
            {
                Name = x.Key,
                CdCount = x.Count(),
                AvgPrice = Math.Round(x.Average(y => y.Price), 2),
                Artists = x.Select(y=>y.Artist).ToList()
            }).ToList();


            var t8q = (from x in list
                       group x by x.Country into g
                       select new Country()
                       {
                           Name = g.Key,
                           CdCount = g.Count(),
                           AvgPrice = Math.Round(g.Average(y => y.Price), 2),
                           Artists = g.Select(y => y.Artist).ToList()
                       }).ToList();


            SerializeJson(t8);
            SerializeXML(t8);

            ;
            ;
        }
    }
}
