using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Speech.Synthesis;

namespace Bookstore
{
    class Employee
    {
        string emp_id;
        string emp_name;
        string emp_sex;
        string emp_birth;
        string emp_add;
        string emp_no;
        string emp_st;
        string value;
        string pilih;
        string path = "Employee.txt";

        //EMPLOYEE MENU
        public void EmployeeMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("|           EMPLOYEE MENU             |");
                Console.WriteLine("|-------------------------------------|");
                Console.WriteLine("|1. Read Employee                     |");
                Console.WriteLine("|2. Add New Employee                  |");
                Console.WriteLine("|3. Update Existing Employee          |");
                Console.WriteLine("|4. Search Employee                   |");
                Console.WriteLine("|5. Delete Employee                   |");
                Console.WriteLine("|6. EXIT                              |");
                Console.WriteLine("---------------------------------------\n");
                Console.Write("Enter Your Choice : ");
                pilih = Console.ReadLine();
                Console.WriteLine("\n");
                
                switch (pilih)
                {
                    case "1":
                        ReadEmployee();
                        break;
                    case "2":
                        AddEmployee();
                        break;
                    case "3":
                        ReadEmployee2();
                        UpdateEmployee();
                        break;
                    case "4":
                        SearchEmployee();
                        break;
                    case "5":
                        ReadEmployee2();
                        DeleteEmployee();
                        break;
                    case "6":
                        Console.WriteLine("Thank You So Much, Have A Nice Day!");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Wrong Input, Please input in 1 to 6 and digit only!");
                        Console.ReadLine();
                        break;

                }
            } while (pilih != "6");
        }

        //READ
        public void ReadEmployee()
        {
            string[] originalLines = File.ReadAllLines(path);
            foreach (string line in originalLines)
            {
                string[] infos = line.Split(';');
                Console.WriteLine(
                    "\t\tID_Employee    : " + infos[0] +
                    "\n\t\tName           : " + infos[1] +
                    "\n\t\tGender         : " + infos[2] +
                    "\n\t\tBirthdate      : " + infos[3] +
                    "\n\t\tAddress        : " + infos[4] +
                    "\n\t\tPhone Number   : " + infos[5] +
                    "\n\t\tPosition       : " + infos[6]);
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }

        //ADD
        public void AddEmployee()
        {
            Console.WriteLine("\nEnter ID_Employee: ");
            emp_id = Console.ReadLine();
            int emp_id_int = 0;
                //cannot input alphabet and cannot be empty
                while ((!int.TryParse(emp_id, out emp_id_int)) || (string.IsNullOrEmpty(emp_id)) )
                {
                    Console.Write("Please fill ID_Employee and input digit only!");
                    Console.ReadLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    emp_id = Console.ReadLine();
                }
            Console.WriteLine("\nEnter Name: ");
            emp_name = Console.ReadLine();
            //cannot be empty
                while (string.IsNullOrEmpty(emp_name))
                {
                    Console.WriteLine("Name can't be empty!");
                    Console.WriteLine("Enter Name: ");
                    emp_name = Console.ReadLine();
                }
            Console.WriteLine("\nEnter Gender(F/M): ");
            emp_sex = Console.ReadLine();
            //cannot be empty
            int emp_sex_int = 0;
                //cannot input alphabet and cannot be empty
                while ((int.TryParse(emp_sex, out emp_sex_int)) || (string.IsNullOrEmpty(emp_sex)) || (emp_sex != "M") || (emp_sex != "F"))
                {
                    Console.Write("Please input only M/F!");
                    Console.ReadLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    emp_sex = Console.ReadLine();
                }
            Console.WriteLine("\nEnter Birthdate: ");
            emp_birth = Console.ReadLine();
            //cannot be empty
                while (string.IsNullOrEmpty(emp_birth))
                {
                    Console.WriteLine("Birthdate can't be empty!");
                    Console.WriteLine("Enter Birthdate: ");
                    emp_birth = Console.ReadLine();
                }
            Console.WriteLine("\nEnter Address: ");
            emp_add = Console.ReadLine();
            //cannot be empty
                while (string.IsNullOrEmpty(emp_add))
                {
                    Console.WriteLine("Address can't be empty!");
                    Console.WriteLine("Enter Address: ");
                    emp_add = Console.ReadLine();
                }
            Console.WriteLine("\nEnter Phone Number(8-12 digit): ");
            emp_no = Console.ReadLine();
            //cannot be empty
                while (string.IsNullOrEmpty(emp_no))
                {
                    Console.WriteLine("Phone Number can't be empty!");
                    Console.WriteLine("Enter Phone Number: ");
                    emp_no = Console.ReadLine();
                }

                int empno;
                while (!int.TryParse(emp_no, out empno))
                {
                    Console.WriteLine("Please input only digit");
                    Console.WriteLine("\nEnter Phone Number: ");
                    emp_no = Console.ReadLine();
                }

                while (emp_no.Length > 12 || emp_no.Length < 8)
                {
                    Console.WriteLine("Please input only 8-12 digit");
                    // then add something like this
                    Console.Write("Enter Phone Number: ");
                    emp_no = Console.ReadLine();
                }
                Console.WriteLine("\nEnter Position: ");
                emp_st = Console.ReadLine();
                //cannot be empty
                    while (string.IsNullOrEmpty(emp_st))
                    {
                        Console.WriteLine("Position can't be empty!");
                        Console.WriteLine("\nEnter Position: ");
                        emp_st = Console.ReadLine();
                    }

                File.AppendAllText(path, "E" + emp_id + ";" + emp_name + ";" + emp_sex + ";" + emp_birth + ";" + emp_add + ";" + emp_no + ";" + emp_st + Environment.NewLine);
                Console.ReadLine();
        }

        //UPDATE
        public void UpdateEmployee()
        {
            string[] originalLines = File.ReadAllLines(path);
            List<string> updatedLines = new List<string>();
            
            Console.Write("Enter ID Employee: ");
            Console.Write("E");
            emp_id = Console.ReadLine();

            foreach (string line in originalLines)
            {
                string[] infos = line.Split(';');
                if (infos[0] == emp_id)
                {
                    Console.WriteLine(
                        "ID_Employee    : " + infos[0] +
                        "\nName           : " + infos[1] +
                        "\nGender         : " + infos[2] +
                        "\nBirthdate      : " + infos[3] +
                        "\nAddress        : " + infos[4] +
                        "\nPhone NUmber   : " + infos[5] +
                        "\nPosition       : " + infos[6]);
                    Console.WriteLine(
                        "\nWhat do you want to update?" + 
                        "\n1. Address\n2. Phone Number");
                    Console.Write("\nAnswer: ");
                    int pilih = Convert.ToInt32(Console.ReadLine());
                    switch (pilih)
                    {
                        case 1:
                            Console.Write("\nEnter New Address: ");
                            value = Console.ReadLine();
                            infos[4] = value;
                            break;
                        case 2:
                            Console.Write("\nEnter New Phone Number: ");
                            value = Console.ReadLine();
                            infos[5] = value;
                            break;
                    }
                }
                updatedLines.Add(string.Join(";", infos));
            }
            File.WriteAllLines(path, updatedLines);
            Console.ReadLine();
        }

        //SEARCH
        public void SearchEmployee()
        {
            string[] original = File.ReadAllLines(path);
            Console.Write("\nEnter Keyword (By ID_Employee) : ");
            emp_id = Console.ReadLine().ToUpper() ;

            foreach (string line in original)
            {
                string[] infos = line.Split(';');
                if (infos[0] == emp_id)
                {
                    Console.WriteLine(
                        "ID_Employee    : " + infos[0] +
                        "\nName           : " + infos[1] +
                        "\nGender         : " + infos[2] +
                        "\nBirthdate      : " + infos[3] +
                        "\nAddress        : " + infos[4] +
                        "\nPhone NUmber   : " + infos[5] +
                        "\nPosition       : " + infos[6]);
                }
            }
            Console.ReadLine();
        }

        //DELETE
        public void DeleteEmployee()
        {
            List<string> lines = File.ReadAllLines(path).ToList();
            Console.Write("\nEnter ID Employee : ");
            emp_id = Console.ReadLine().ToUpper();
            int i = 0;
            foreach(string line in lines)
            {
                string[] infos = line.Split(';');
                if(infos[0] == emp_id)
                {
                    lines.RemoveAt(i);
                    break;
                }
                i++;
            }
            File.WriteAllLines(path, lines.ToArray());
            Console.ReadLine();
        }

        public void ReadEmployee2()
        {
            string[] originalLines = File.ReadAllLines(path);
            foreach (string line in originalLines)
            {
                string[] infos = line.Split(';');
                Console.WriteLine(
                    "\t\tID_Employee    : " + infos[0] +
                    "\n\t\tName           : " + infos[1] +
                    "\n\t\tGender         : " + infos[2] +
                    "\n\t\tBirthdate      : " + infos[3] +
                    "\n\t\tAddress        : " + infos[4] +
                    "\n\t\tPhone Number   : " + infos[5] +
                    "\n\t\tStatus         : " + infos[6]);
                Console.WriteLine("\n");
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
