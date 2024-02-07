using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Address_Book_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            bool flag = true;
            do
            {
                Console.WriteLine("WELCOME TO THE ADDRESS BOOK SYSTEM");
                Console.WriteLine();
                Console.WriteLine("Choose the Operation to be performed by the User");
                Console.WriteLine("1.Add new User ");
                Console.WriteLine("2.Perform Operation in the AddressBook");
                Console.WriteLine("3.Display list of User's in AddressBook");
                Console.WriteLine("4.Search Contact in AddressBook");
                Console.WriteLine("5.To exit from the AddressBook ");
                Console.WriteLine();
                Console.Write("Enter Option:");
                int option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter the User Name: ");
                        string name = Console.ReadLine();
                        user.add_user(name);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case 2:
                        int op;
                        Console.Clear();
                        Console.Write("Enter the User Name in Which the Operations must be performed : ");
                        string fname = Console.ReadLine();
                        do
                        {
                            if (user.GetPersons().ContainsKey(fname))
                            {
                                AddressBook obj = user.GetPersons()[fname];
                                Console.WriteLine("Enter the Operation to be performed");
                                Console.WriteLine();
                                Console.WriteLine("1.Add a new contact in Address Book");
                                Console.WriteLine("2.Display the contacts in Address Book");
                                Console.WriteLine("3.Edit the contact in Address Book");
                                Console.WriteLine("4.Delete the contact from Address Book");
                                Console.WriteLine("5.Exit from the Address Book");
                                Console.WriteLine();
                                Console.Write("Enter Option :");
                                op = Convert.ToInt32(Console.ReadLine());
                                switch (op)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Enter the Details to add in Address Book : ");
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
                                Console.WriteLine("User Does not exits in AddressBook");
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
                        Console.WriteLine("Display the User's of AddressBook");
                        user.Display();
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Choose the search Factor :");
                        Console.WriteLine();
                        Console.WriteLine("1.Get City and State by Name in AddressBook");
                        Console.WriteLine("2.Get Contact details by City Name in AddressBook");
                        Console.WriteLine("3.Get Contact details by State Name in AddressBook");
                        Console.WriteLine();
                        Console.Write("Enter Option :");
                        
                        
                            op = Convert.ToInt32(Console.ReadLine());
                           
                        
                                switch (op)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.Write("Enter the Name : ");
                                        string searchname = Console.ReadLine();
                                        var nameResults = user.SearchPersonsInName(searchname);
                                        DisplayPersonCityAndState(nameResults);
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.Write("Enter the City : ");
                                        string searchCity = Console.ReadLine();
                                        var cityResults = user.SearchPersonsInCity(searchCity);
                                        DisplaySearchResults(cityResults);
                                        Console.WriteLine($"The Number of contacts in {searchCity}: {user.GetContactCountByState(searchCity)}");
                                        Thread.Sleep(80000);
                                        Console.Clear();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        Console.Write("Enter the State : ");
                                        string searchState = Console.ReadLine();
                                        var stateResults = user.SearchPersonsInState(searchState);
                                        DisplaySearchResults(stateResults);
                                        Console.WriteLine($"The Number of contacts in {searchState}: {user.GetContactCountByState(searchState)}");
                                        Thread.Sleep(80000);
                                        Console.Clear();
                                        break;
                                }
                                break;
                       // Catch Console.WriteLine("Please Enter a proper option ")

                    case 5:

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
                Console.WriteLine("No matching Contacts found.");
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