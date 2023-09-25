using Newtonsoft.Json;
using System.Xml.Linq;

namespace Ora_03
{
    class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //https://github.com/zane9907/HFT_Oktatas/

            DeserializeXml("ora.xml");
            List<Person> list = DeserializeJson("ora.json");

            //Method syntax
            var t1 = list.Select(x => x.Firstname).ToList();
            var t1tobb = list.Select(x => new
            {
                FIRSTNAME = x.Firstname,
                LASTNAME = x.Lastname,
            });

            //query syntax
            t1 = (from x in list
                 select x.Firstname).ToList();

            var t2 = list.Where(x => x.Country.Contains('N')).ToList();

            t2 = (from x in list
                  where x.Country.Contains('N')
                  select x).ToList();

            var t3 = list.OrderBy(x => x.Lastname).ToList();

            var t4 = list.FirstOrDefault(x => x.Country.Length == 5);
            //var t5 = list.SingleOrDefault(x=> x.Country.Contains('N'));

            var t6 = list.Distinct();

            var t7 = list.Count(x => x.Country.Contains('N'));

            var t8 = list.All(x => x.Country.Length == 5);
            var t9 = list.Any(x => x.Country.Length == 5);

            var t10 = list.GroupBy(x => x.Country).ToList();
            //var t10 = (from x in list
            //          group x by x.Country into g
            //          select new
            //          {
            //              Country = g
            //          }).ToList();

            ;
        }

        static List<Person> DeserializeJson(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Person>>(json);
        }

        static List<Person> DeserializeXml(string path)
        {
            XDocument xml = XDocument.Load(path);

            List<Person> people = new List<Person>();

            foreach (var item in xml.Root.Elements())
            {
                people.Add(
                        new Person()
                        {
                            Firstname = item.Element("firstname").Value,
                            Lastname = item.Element("lastname").Value,
                            City = item.Element("city").Value,
                            Country = item.Element("country").Value
                        });
            }

            return people;
        }
    }
}