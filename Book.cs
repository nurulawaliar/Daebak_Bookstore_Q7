using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Bookstore
{
    class Book
    {
        string bkcode;
        string bktitle;
        string bkcategory;
        string bkpublisher;
        string bkauthor;
        string bkpages;
        string bklang;
        string bkdate;
        string bkprice;
        string bkstock;
        string bkStockAdd;
        string pilihan;
        string newdatabook;
        int newdatabookint;
        string path = "Book.txt";

        //Book Menu
        public void BookMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("|             BOOK MENU               |");
                Console.WriteLine("|-------------------------------------|");
                Console.WriteLine("|1. Book Data                         |");
                Console.WriteLine("|2. Add New Book                      |");
                Console.WriteLine("|3. Add New Purchase Book             |");
                Console.WriteLine("|4. Update Book                       |");
                Console.WriteLine("|5. Search Book                       |");
                Console.WriteLine("|6. Delete Book                       |");
                Console.WriteLine("|7. Exit                              |");
                Console.WriteLine("---------------------------------------\n");
                Console.Write("\nEnter Your Choice : ");
                pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        ReadBook();
                        break;
                    case "2":
                        AddBook();
                        break;
                    case "3":
                        PurchaseBook();
                        break;
                    case "4":
                        ReadBook2();
                        UpdateBook();
                        break;
                    case "5":
                        SearchBook();
                        break;
                    case "6":
                        ReadBook2();
                        DeleteBook();
                        break;
                    case "7":
                        Console.WriteLine("Thank You So Much, Have A Nice Day!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Your Input is Invalid, Please Recheck and Reinput");
                        break;
                }
            } while (pilihan != "7");
        }

        //ADD NEW BOOK
        public void AddBook()
        {
            int bkstockint;
            bkstockint = 0;
            Console.WriteLine("Book Code : ");
            Console.Write("B");
            bkcode = Console.ReadLine();
            int bkcodeint;
            while (!int.TryParse(bkcode, out bkcodeint))
            {
                Console.Write("This is not a number!");
                Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
                //Console.Write("Enter The Book Code :");
                bkcode = Console.ReadLine();

            }
            string bkcodeending = "B" + bkcode;
            Console.WriteLine("Book Title : ");
            bktitle = Console.ReadLine();
            while (string.IsNullOrEmpty(bktitle))
            {
                Console.WriteLine("Book Title Can't be Empty or null, please recheck the Input");
                Console.WriteLine("Book Title : ");
                bktitle = Console.ReadLine();
            }
            Console.WriteLine("Category : ");
            bkcategory = Console.ReadLine();
            Console.WriteLine("Publisher : ");
            bkpublisher = Console.ReadLine();
            while (string.IsNullOrEmpty(bkpublisher))
            {
                Console.WriteLine("Book Publisher Can't be Empty or null, please recheck the Input");
                Console.WriteLine("Book Publisher : ");
                bkpublisher = Console.ReadLine();
            }
            Console.WriteLine("Author : ");
            bkauthor = Console.ReadLine();
            while (string.IsNullOrEmpty(bkauthor))
            {
                Console.WriteLine("Book Author Can't be Empty or null, please recheck the Input");
                Console.WriteLine("Book Author : ");
                bkauthor = Console.ReadLine();
            }
            Console.WriteLine("Pages Total : ");
            bkpages = Console.ReadLine();
            int bkpagesint;
            while (!int.TryParse(bkpages, out bkpagesint))
            {
                Console.WriteLine("This is not a number!");
                Console.Write("Enter The Book Total :");
                bkpages = Console.ReadLine();
            }
            Console.WriteLine("Language : ");
            bklang = Console.ReadLine();
            while (string.IsNullOrEmpty(bklang))
            {
                Console.WriteLine("Book Language Can't be Empty or null, please recheck the Input");
                Console.WriteLine("Book Language : ");
                bklang = Console.ReadLine();
            }
            Console.WriteLine("Book Publish date : ");
            bkdate = Console.ReadLine();
            Console.WriteLine("Book Price : ");
            bkprice = Console.ReadLine();
            int bkpriceint;
            while (!int.TryParse(bkprice, out bkpriceint))
            {
                Console.WriteLine("This is not a number!");
                Console.Write("Enter The Book Price :");
                bkprice = Console.ReadLine();
            }
            //Console.WriteLine(bkpriceint);
            File.AppendAllText(path, bkcodeending + ";" + bktitle + ";" + bkcategory + ";" + bkpublisher + ";" + bkauthor + ";" + bkpages + ";" + bklang + ";" + bkdate + ";" + bkprice + ";" + bkstockint + Environment.NewLine);
            Console.ReadLine();
        }

        //ENTER THE BOOK TOTAL
        public void PurchaseBook()
        {
            int bkStockNew;
            int bkStockOld;
            string[] originallines = File.ReadAllLines(path);
            List<string> updatedlines = new List<string>();

            Console.Write("Input The Book Code : ");
            bkcode = Console.ReadLine();

            foreach (string line in originallines)
            {
                string[] infos = line.Split(';');
                if (infos[0] == bkcode)
                {
                    Console.WriteLine(
                    "Book ID \t: " + infos[0] +
                    "\nBook Title \t: " + infos[1] +
                    "\nBook Category \t: " + infos[2] +
                    "\nBook Publisher \t: " + infos[3] +
                    "\nBook Author \t: " + infos[4] +
                    "\nPages \t\t: " + infos[5] +
                    "\nLanguage \t: " + infos[6] +
                    "\nBook Date \t: " + infos[7] +
                    "\nBook Price \t: " + infos[8] +
                    "\nStock \t\t: " + infos[9]);
                    Console.Write("\nEnter The Total : ");
                    bkStockAdd = Console.ReadLine();
                    int bkstockck;
                    while (!int.TryParse(bkStockAdd, out bkstockck))
                    {
                        Console.WriteLine("This is not a number!");
                        Console.Write("Enter The New Price :");
                        bkStockAdd = Console.ReadLine();
                    }
                    bkStockOld = Convert.ToInt32(infos[9]);
                    int bkStockAddint = Convert.ToInt32(bkStockAdd);
                    bkStockNew = bkStockOld + bkStockAddint;
                    infos[9] = Convert.ToString(bkStockNew);
                }
                updatedlines.Add(string.Join(";", infos));
            }
            File.WriteAllLines(path, updatedlines);
            Console.ReadLine();
        }

        //UPDATE BOOK
        public void UpdateBook()
        {
            string[] originallines = File.ReadAllLines(path);
            List<string> updatedlines = new List<string>();
            Console.Write("Input The Book Code : ");
            bkcode = Console.ReadLine();
            foreach (string line in originallines)
            {
                string[] infos = line.Split(';');
                if (infos[0] == bkcode)
                {
                    Console.WriteLine(
                    "Book ID \t: " + infos[0] + Environment.NewLine +
                    "Book Title \t: " + infos[1] + Environment.NewLine +
                    "Book Category \t: " + infos[2] + Environment.NewLine +
                    "Book Publisher \t: " + infos[3] + Environment.NewLine +
                    "Book Author \t: " + infos[4] + Environment.NewLine +
                    "Pages \t\t: " + infos[5] + Environment.NewLine +
                    "Language \t: " + infos[6] + Environment.NewLine +
                    "Book Date \t: " + infos[7] + Environment.NewLine +
                    "Book Price \t: " + infos[8] + Environment.NewLine +
                    "Stock \t\t: " + infos[9] + Environment.NewLine);
                    Console.WriteLine("What Do you want to update ?");
                    Console.WriteLine("1. Book Title");
                    Console.WriteLine("2. Book Categori");
                    Console.WriteLine("3. Book Publisher");
                    Console.WriteLine("4. Book Author");
                    Console.WriteLine("5. Book Pages");
                    Console.WriteLine("6. Book language");
                    Console.WriteLine("7. Book Publish Date");
                    Console.WriteLine("8. Book Price");
                    Console.WriteLine("9. Stock");
                    Console.Write("Answer : ");
                    pilihan = Console.ReadLine();
                    switch (pilihan)
                    {
                        case "1":
                            Console.WriteLine("Enter the New Title : ");
                            newdatabook = Console.ReadLine();
                            infos[1] = newdatabook;
                            break;
                        case "2":
                            Console.WriteLine("Enter the New Category : ");
                            newdatabook = Console.ReadLine();
                            infos[2] = newdatabook;
                            break;
                        case "3":
                            Console.WriteLine("Enter the New Publisher : ");
                            newdatabook = Console.ReadLine();
                            infos[3] = newdatabook;
                            break;
                        case "4":
                            Console.WriteLine("Enter the New Author : ");
                            newdatabook = Console.ReadLine();
                            infos[4] = newdatabook;
                            break;
                        case "5":
                            Console.WriteLine("Enter the New Pages : ");
                            newdatabook = Console.ReadLine();
                            infos[5] = newdatabook;
                            break;
                        case "6":
                            Console.WriteLine("Enter the New Language : ");
                            newdatabook = Console.ReadLine();
                            infos[6] = newdatabook;
                            break;
                        case "7":
                            Console.WriteLine("Enter the New Publish Date : ");
                            newdatabook = Console.ReadLine();
                            infos[7] = newdatabook;
                            break;
                        case "8":
                            Console.WriteLine("Enter the New Price : ");
                            newdatabook = Console.ReadLine();
                            int bkpriceint;
                            while (!int.TryParse(newdatabook, out bkpriceint))
                            {
                                Console.WriteLine("This is not a number!");
                                Console.Write("Enter The New Price :");
                                newdatabook = Console.ReadLine();
                            }
                            infos[8] = newdatabook;
                            break;
                        case "9":
                            Console.WriteLine("Enter the New Stock : ");
                            newdatabook = Console.ReadLine();
                            int bkstockint;
                            while (!int.TryParse(newdatabook, out bkstockint))
                            {
                                Console.WriteLine("This is not a number!");
                                Console.Write("Enter The New Stock :");
                                newdatabook = Console.ReadLine();
                            }
                            infos[9] = newdatabook;
                            break;
                        default:
                            Console.WriteLine("Yang Anda Masukan Salah !");
                            break;
                    }
                }
                updatedlines.Add(string.Join(";", infos));
            }
            File.WriteAllLines(path, updatedlines);
            Console.ReadLine();
        }


        //READ BOOK
        public void ReadBook()
        {
            Console.WriteLine("\n\nDaftar Buku :\n");
            string[] originallines = File.ReadAllLines(path);
            foreach (var line in originallines)
            {
                string[] infos = line.Split(';');
                Console.WriteLine(
                    "Book ID \t: " + infos[0] +
                    "\nBook Title \t: " + infos[1] +
                    "\nBook Category \t: " + infos[2] +
                    "\nBook Publisher \t: " + infos[3] +
                    "\nBook Author \t: " + infos[4] +
                    "\nPages \t\t: " + infos[5] +
                    "\nLanguage \t: " + infos[6] +
                    "\nBook Date \t: " + infos[7] +
                    "\nBook Price \t: " + infos[8] +
                    "\nStock \t\t: " + infos[9] + "\n");
            }
            Console.ReadLine();
        }

        //delete
        public void DeleteBook()
        {
            List<string> lines = File.ReadAllLines(path).ToList();
            Console.Write("Enter The Book Code : ");
            bkcode = Console.ReadLine();
            int i = 0;
            foreach (var line in lines)
            {
                string[] infos = line.Split(';');
                if (infos[0] == bkcode)
                {
                    //Console.WriteLine(infos[0]);
                    lines.RemoveAt(i);
                    break;
                }
                i++;
            }
            File.WriteAllLines(path, lines.ToArray());
            Console.ReadLine();
        }

        public void SearchBook()
        {
            string[] original = File.ReadAllLines(path);
            Console.Write("\nEnter Keyword (By ID_Employee) : ");
            bkcode = Console.ReadLine();

            foreach (string line in original)
            {
                string[] infos = line.Split(';');
                if (infos[0] == bkcode)
                {
                    Console.WriteLine(
                    "Book ID \t: " + infos[0] + Environment.NewLine +
                    "Book Title \t: " + infos[1] + Environment.NewLine +
                    "Book Category \t: " + infos[2] + Environment.NewLine +
                    "Book Publisher \t: " + infos[3] + Environment.NewLine +
                    "Book Author \t: " + infos[4] + Environment.NewLine +
                    "Pages \t\t: " + infos[5] + Environment.NewLine +
                    "Language \t: " + infos[6] + Environment.NewLine +
                    "Book Date \t: " + infos[7] + Environment.NewLine +
                    "Book Price \t: " + infos[8] + Environment.NewLine +
                    "Stock \t\t: " + infos[9] + Environment.NewLine);
                }
            }
            Console.ReadLine();
        }

        public void ReadBook2()
        {
            Console.WriteLine("\n\nDaftar Buku :\n");
            string[] originallines = File.ReadAllLines(path);
            foreach (var line in originallines)
            {
                string[] infos = line.Split(';');
                Console.WriteLine(
                    "Book ID \t: " + infos[0] +
                    "\nBook Title \t: " + infos[1] +
                    "\nBook Category \t: " + infos[2] +
                    "\nBook Publisher \t: " + infos[3] +
                    "\nBook Author \t: " + infos[4] +
                    "\nPages \t\t: " + infos[5] +
                    "\nLanguage \t: " + infos[6] +
                    "\nBook Date \t: " + infos[7] +
                    "\nBook Price \t: " + infos[8] +
                    "\nStock \t\t: " + infos[9] + "\n");
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine(new string(' ',Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }


    }
}
