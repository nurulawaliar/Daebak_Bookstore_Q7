using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Speech.Synthesis;

namespace Bookstore
{
    class Program
    {
        static string pilih;
        static void Main(string[] args)
        {
            // Get the WindowWidth 
            Console.WriteLine("Current WindowWidth: {0}", Console.WindowWidth);

            // Set the WindowWidth 
            Console.WindowWidth = 40;

            // Get the WindowWidth 
            Console.Write("Current WindowWidth: {0}", Console.WindowWidth);
            do
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("|     WELCOME TO DAEBAK BOOKSTORE     |");
                Console.WriteLine("|-------------------------------------|");
                Console.WriteLine("|1. ADMIN                             |");
                Console.WriteLine("|2. CASHIER                           |");
                Console.WriteLine("|3. EXIT                              |");
                Console.WriteLine("---------------------------------------\n");
                Console.Write("Enter Your Choice : ");
                pilih = Console.ReadLine();
                Console.WriteLine("\n");
                switch (pilih)
                {
                    case "1":
                        BookstoreMenu mn = new BookstoreMenu();
                        mn.Menu();
                        break;
                    case "2":
                        Cashier ch = new Cashier();
                        ch.CashierMenu();
                        break;
                    case "3":
                        Console.WriteLine("Thank You So Much, Have A Nice Day!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        Console.ReadLine();
                        break;

                }
            } while (pilih != "3");
        }
    }
}