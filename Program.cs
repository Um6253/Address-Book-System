﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Address_Book_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();


            //AddressBook obj = new AddressBook();

            bool flag = true;
            do
            {
                Console.WriteLine("WELCOME TO THE ADDRESS BOOK SYSTEM");
                Console.WriteLine();
                Console.WriteLine("Choose the Operation to be performed by the user");
                Console.WriteLine("1.To add new User ");
                Console.WriteLine("2.To perform operation in the AddressBook");
                Console.WriteLine("3.To display list of User's of AddressBook");
                Console.WriteLine("4.To exit from the AddressBook ");
                int option = Convert.ToInt16(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter the username");
                        string name = Console.ReadLine();
                        
                        user.add_user(name); 
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case 2:
                        int op;
                        Console.Clear();
                        Console.WriteLine("Enter the name of the User Name: ");
                        string fname = Console.ReadLine();
                        do
                        {
                            if (user.GetPersons().ContainsKey(fname))
                            {
                                AddressBook obj = user.GetPersons()[fname];
                                Console.WriteLine("Enter the operation to be performed");
                                Console.WriteLine("1.To Add new the contact in Address Book");
                                Console.WriteLine("2.To Display the contact in Address Book");
                                Console.WriteLine("3.TO Edit the contact in Address Book");
                                Console.WriteLine("4.TO Delete the contact from Address Book");
                                Console.WriteLine("5.TO Exit from the Address Book");
                                op = Convert.ToInt32(Console.ReadLine());
                                switch (op)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Enter the details to add in Address Book");
                                        obj.add_contact();
                                        Console.Clear();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        obj.display();
                                        Thread.Sleep(5000);
                                        Console.Clear();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        obj.edit();
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        obj.Delete();
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;

                                }
                            }
                            else
                            {
                                Console.WriteLine("User not found in AddressBook");
                                op = 5;
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;

                            }

                        } while (op != 5);

                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Display the User's name of AddressBook");
                        user.Display();
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    case 4:

                        flag = false;
                        break;
                }
            } while (flag);
        }
        
    }
}