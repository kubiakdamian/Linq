using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Linq
{
    class DataReader
    {
        private String path;
        private XElement xelement;
        private IEnumerable<XElement> cds;
        public DataReader()
        {
            this.path = "../../cds.xml";
            xelement = XElement.Load(path);
            cds = xelement.Elements();
        }
        
        public void printData()
        {
            foreach (var cd in cds)
            {
                Console.WriteLine(cd);
            }
        }

        public void printSingleData(String name)
        {
            String dataName = name.ToUpper();
            int i = 0;
            foreach (var cd in cds)
            {
                try
                {
                    i++;
                    Console.WriteLine(i + ". " + name + ": " + cd.Element(dataName).Value);
                }
                catch
                {
                    Console.WriteLine("There is no field named: " + name);
                    break;
                }           
            }
        }

        public void printDoubleData(String first, String second)
        {
            String firstData = first.ToUpper();
            String secondData = second.ToUpper();
            int i = 0;
            foreach (var cd in cds)
            {
                try
                {
                    i++;
                    Console.WriteLine(i + ". " + firstData + ": " + cd.Element(firstData).Value);
                    Console.WriteLine("\t" + secondData + ": " + cd.Element(secondData).Value);
                }
                catch
                {
                    Console.WriteLine("Bad fields were given");
                    break;
                }
            }
        }

        public void printDataWithPrice()
        {
            var name = from nm in cds
                       where (string)nm.Element("PRICE") == "9.90"
                       select nm;

            Console.WriteLine("Details of CDs with proper price:");
            foreach (XElement xEle in name)
                Console.WriteLine(xEle);
        }
    }
}
