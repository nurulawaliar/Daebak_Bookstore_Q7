using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    class Cashier
    {
        string pilih;
        public void CashierMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("|         WELCOME TO BOOKSTORE        |");
                Console.WriteLine("|-------------------------------------|");
                Console.WriteLine("|1. ADD NEW TRANSACTION               |");
                Console.WriteLine("|2. EXIT                              |");
                Console.WriteLine("---------------------------------------\n");
                Console.Write("Enter Your Choice : ");
                pilih = Console.ReadLine();
                Console.WriteLine("\n");
                switch (pilih)
                {
                    case "1":
                        Transaction tr = new Transaction();
                        break;
                    case "2":
                        Console.WriteLine("Thank You So Much, Have A Nice Day!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        Console.ReadLine();
                        break;

                }
            } while (pilih != "2");
        }
    }
}
