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
                    System.Threading.Thread.Sleep(1500);
                    Environment.Exit(0);
                    break;
                case 1:
                    data.printAllData();
                    break;
                case 2:
                    data.printSortedData(getElementValue());
                    break;
                case 3:
                    data.printSingleData(getElementValue());
                    break;
                case 4:
                    data.printDoubleData(getElementValue(), getElementValue());
                    break;
                case 5:
                    data.printDataWithPrice(getPrice());
                    break;
                default:
                    Console.WriteLine("Enter number from 0 to 5");
                    break;
            }
        }

        private static String getElementValue()
        {
            String elementName;
            Console.WriteLine("Enter element's name: ");
            elementName = Console.ReadLine();

            return elementName;
        }

        private static String getPrice()
        {
            String elementName;
            Console.WriteLine("Enter price: ");
            elementName = Console.ReadLine();

            return elementName;
        }
    }
}
