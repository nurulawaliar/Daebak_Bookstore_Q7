using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    class BookstoreMenu
    {
        string pilih;

        public void Menu()
        {
            LoginAdmin();
            do
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("|     WELCOME TO DAEBAK BOOKSTORE     |");
                Console.WriteLine("|-------------------------------------|");
                Console.WriteLine("|1. BOOKS                             |");
                Console.WriteLine("|2. EMPLOYEE                          |");
                Console.WriteLine("|3. TRANSACTION                       |");
                Console.WriteLine("|4. TRANSACTION DETAIL                |");
                Console.WriteLine("|5. EXIT                              |");
                Console.WriteLine("---------------------------------------\n");
                Console.Write("Enter Your Choice : ");
                pilih = Console.ReadLine();
                Console.WriteLine("\n");
                switch (pilih)
                {
                    case "1":
                        Book bk = new Book();
                        bk.BookMenu();
                        Menu();
                        break;
                    case "2":
                        Employee emp = new Employee();
                        emp.EmployeeMenu();
                        Menu();
                        break;
                    case "3":
                        Transaction tr = new Transaction();
                        Menu();
                        break;
                    case "4":
                        Transaction_Detail td = new Transaction_Detail();
                        Menu();
                        break;
                    case "5":
                        Console.WriteLine("Thank You So Much, Have A Nice Day!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        Console.ReadLine();
                        break;

                }
            } while (pilih != "5");
        }

        public void LoginAdmin()
        {
            Console.WriteLine("Enter ID_Employee : ");
            string username = Console.ReadLine();
            while (username != "E01")
            {
                Console.WriteLine("Please input the right ID_Employee!");
                Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                username = Console.ReadLine();
            }

            Console.WriteLine("Enter Password : ");
            string password = Console.ReadLine();
            while (password != "admin")
            {
                Console.WriteLine("Please input the right Password!");
                Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                password = Console.ReadLine();
            }


        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
