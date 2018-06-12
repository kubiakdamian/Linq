using System;

namespace Linq
{
    class Program
    {
        private static DataReader data;
        static void Main(string[] args)
        {
            try
            {
                data = new DataReader();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Couldn't read data");
                System.Threading.Thread.Sleep(5000);
                Environment.Exit(0);
            }
            

            data.printData();

            Console.ReadLine();
        }
    }
}
