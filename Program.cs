using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string first_name, last_name, address, city, state, zipCode, email;
            long ph_number;
            int option;
            AddressBook obj = new AddressBook();
            List<AddressBook> contact = new List<AddressBook>();
            do
            {
                Console.WriteLine("WELCOME TO THE ADDRESS BOOK");
                Console.WriteLine("Enter the Operation To be Performed:");
                Console.WriteLine("1.To Add a New Contact in Address_Book");
                Console.WriteLine("2.To Display the Contact present in Address Book");
                Console.WriteLine("3.To Edit the contac in Address Book");
                Console.WriteLine("4.To Exit from the Address Book");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter the details to Add in Address Book");
                        Console.Write("First Name: ");
                        first_name = Console.ReadLine();
                        Console.Write("Last Name: ");
                        last_name = Console.ReadLine();
                        Console.Write("Address: ");
                        address = Console.ReadLine();
                        Console.Write("City Name: ");
                        city = Console.ReadLine();
                        Console.Write("State Name: ");
                        state = Console.ReadLine();
                        Console.Write("zipCode: ");
                        zipCode = Console.ReadLine();
                        Console.Write("Email ID: ");
                        email = Console.ReadLine();
                        Console.Write("Phone Number: ");
                        ph_number = Convert.ToInt64(Console.ReadLine());
                        AddressBook obj1 = new AddressBook();
                        obj1.add(first_name, last_name, address, city, state, zipCode, ph_number, email);
                        contact.Add(obj1);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        obj.display(contact);
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter the existing Email ID of the contact to Edit:");
                        string emailToEdit = Console.ReadLine();
                        obj.edit(contact, emailToEdit);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;

                }
            } while (option != 4);
        }
        public class AddressBook
        {
            private string First_name;
            private string Last_name;
            private string Address;
            private string City;
            private string State;
            private string zipCode;
            private long ph_number;
            private string Email;

            public void add(string first_name, string last_name, string address, string city, string state, string zipCode, long ph_number, string email)
            {
                this.First_name = first_name;
                this.Last_name = last_name;
                this.Address = address;
                this.City = city;
                this.State = state;
                this.zipCode = zipCode;
                this.ph_number = ph_number;
                this.Email = email;
            }
            public void display(List<AddressBook> contact)
            {
                foreach (var con in contact)
                {

                    Console.WriteLine($"FirstName: {con.First_name}");
                    Console.WriteLine($"lastname: {con.Last_name}");
                    Console.WriteLine($"address: {con.Address}");
                    Console.WriteLine($"city: {con.City}");
                    Console.WriteLine($"state: {con.State}");
                    Console.WriteLine($"zip: {con.zipCode}");
                    Console.WriteLine($"email: {con.Email}");
                    Console.WriteLine($"Phone number: {con.ph_number}");
                    

                }
            }
            public void edit(List<AddressBook> contact, string email)
            {
                string field = "", new_value = "";
                int num = 0;
                foreach (var con in contact)
                {
                    if (con.Email == email)
                    {
                        Console.WriteLine("Enter the field name to be edited");
                        field = Console.ReadLine();
                        Console.Write($"Enter the new value of the {field}:");
                        if (field == "number")
                        {
                            num = Convert.ToInt32(Console.ReadLine());
                        }
                        else
                        {
                            new_value = Console.ReadLine();
                        }
                        switch (field)
                        {
                            case "firstname":
                                con.First_name = new_value;
                                break;
                            case "lastname":
                                con.Last_name = new_value;
                                break;
                            case "address":
                                con.Address = new_value;
                                break;
                            case "city":
                                con.City = new_value;
                                break;
                            case "state":
                                con.State = new_value;
                                break;
                            case "zip":
                                con.zipCode = new_value;
                                break;
                            case "phone Number":
                                con.ph_number = num;
                                break;
                            case "email":
                                con.Email = new_value;
                                break;
                        }
                    }
                }
                Console.WriteLine("Contact is not there in the AddressBook");
            }
        }
    }
}