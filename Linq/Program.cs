using System;

namespace Linq
{
    class Program
    {
        private static DataReader data;
        static void Main(string[] args)
        {
            int chosenValue = -1;
            loadData();

            while(chosenValue != 0)
            {
                Menu.printMenu();
                Console.WriteLine("Enter choice: ");
                chosenValue = Convert.ToInt32(Console.ReadLine());
                takeAction(chosenValue);
            }
            
            Console.ReadLine();
        }

        private static void loadData()
        {
            try
            {
                data = new DataReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't read data");
                System.Threading.Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }

        private static void takeAction(int number)
        {
            switch (number)
            {
                case 0:
                    Console.WriteLine("Goodbye");
                    System.Threading.Thread.Sleep(3000);
                    Environment.Exit(0);
                    break;
                case 1:
                    data.printAllData();
                    break;
                case 2:
                    data.printSortedData("YEAR");
                    break;
                case 3:
                    data.printSingleData("artist");
                    break;
                case 4:
                    data.printDoubleData("artist", "title");
                    break;
                case 5:
                    data.printDataWithPrice("10.20");
                    break;
            }
        }
    }
}
