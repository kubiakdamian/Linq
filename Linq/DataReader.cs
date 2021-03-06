﻿using System;
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
        
        public void printAllData()
        {
            Console.WriteLine("ALL DATA: \n");
            printData(cds);
        }

        public void printSortedData(String name)
        {
            String dataName = name.ToUpper();
            IEnumerable<XElement> sortedCds;

            try
            {
                sortedCds = cds.OrderBy(item => item.Element(dataName).Value);
                Console.WriteLine("SORTED DATA: \n");
                printData(sortedCds);
            }
            catch(Exception ex)
            {
                Console.WriteLine("There is no field named: " + name);
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
                    Console.WriteLine("There is no field named: " + name + "\n");
                    break;
                }           
            }
            Console.WriteLine("\n");
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
                    Console.WriteLine("\t" + secondData + ": " + cd.Element(secondData).Value + "\n");
                }
                catch
                {
                    Console.WriteLine("Bad fields were given\n");
                    break;
                }
            }
            Console.WriteLine("\n");
        }

        public void printDataWithPrice(String price)
        {   
            var cdsWithProperPrice = from nm in cds
                        where (string)nm.Element("PRICE") == price
                        select nm;

            Console.WriteLine("Details of CDs with price " + price + ":\n");
            printData(cdsWithProperPrice);  
        }

        private void printData(IEnumerable<XElement> cds)
        {
            foreach (var cd in cds)
            {
                Console.WriteLine("Title: " + cd.Element("TITLE").Value);
                Console.WriteLine("Artist: " + cd.Element("ARTIST").Value);
                Console.WriteLine("Country: " + cd.Element("COUNTRY").Value);
                Console.WriteLine("Company: " + cd.Element("COMPANY").Value);
                Console.WriteLine("Price: " + cd.Element("PRICE").Value);
                Console.WriteLine("Year: " + cd.Element("YEAR").Value + "\n\n");
            }
        }
    }
}
