using System;
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
                Console.WriteLine("4.Enter the of Name to view  person's city and state in AddressBook");
                Console.WriteLine("5.Enter the city of person to view person details in AddressBook");
                Console.WriteLine("6.Enter the State of person  to view person detail in AddressBook");
                Console.WriteLine("7.To exit from the AddressBook ");
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
                        Console.Clear();
                        Console.WriteLine("Enter the name to search");
                        string searchname = Console.ReadLine();
                        var nameResults = user.SearchPersonsInName(searchname);
                        DisplayPersonCityAndState(nameResults);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Enter the city to search: ");
                        string searchCity = Console.ReadLine();
                        var cityResults = user.SearchPersonsInCity(searchCity);
                        DisplaySearchResults(cityResults);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Enter the state to search: ");
                        string searchState = Console.ReadLine();
                        var stateResults = user.SearchPersonsInState(searchState);
                        DisplaySearchResults(stateResults);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;

                    case 7:

                        flag = false;
                        break;
                }
            } while (flag);
        }
        static void DisplayPersonCityAndState(List<Contact> results)
        {
            if (results.Any())
            {
                Console.WriteLine("Search Results:");
                foreach (var contact in results)
                {
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine($"State: {contact.State}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No matching contacts found.");
            }

        }
        static void DisplaySearchResults(List<Contact> results)
        {
            if (results.Any())
            {
                Console.WriteLine("Search Results:");
                foreach (var contact in results)
                {
                    Console.WriteLine($"First Name: {contact.Fname}");
                    Console.WriteLine($"Last Name: {contact.lastname}");
                    Console.WriteLine($"Address: {contact.Addres}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine($"State: {contact.State}");
                    Console.WriteLine($"Phone: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"Zipcode: {contact.ZipCode}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No matching contacts found.");
            }
        }

    }
}