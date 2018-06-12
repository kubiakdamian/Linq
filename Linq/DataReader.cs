using System;
using System.Collections.Generic;
using System.IO;
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
    }
}
