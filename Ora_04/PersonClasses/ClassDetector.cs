using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonClasses
{
    public static class ClassDetector
    {
        public static void ClassesToXML()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes().Where(x=> x.IsClass && x.GetInterface("IPerson") != null).OrderBy(x=>x.Name).ToArray();
            //Type[] types2 = Assembly.GetExecutingAssembly().GetTypes().Where(x=> x.IsClass && x.IsAssignableTo(typeof(IPerson))).OrderBy(x=>x.Name).ToArray();



            XDocument xdoc = new XDocument();
            xdoc.Add(new XElement("people", new XAttribute("count", types.Length)));
            foreach (var type in types)
            {
                xdoc.Root.Add(new XElement("class",
                    new XElement("name", type.Name),
                    new XElement("hash", type.GetHashCode()
                    )));
            }

            xdoc.Save("classes.xml");

           
        }
    }
}
