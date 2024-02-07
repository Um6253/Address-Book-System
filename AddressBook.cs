﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Address_Book_System.Program;

namespace Address_Book_System
{
     class AddressBook
    {

        List<Contact> contacts = new List<Contact>();

        public void add_contact()
        {
            Console.Write("First name: ");
            string first_name = Console.ReadLine();
            string p1 = "^[A-Z][a-z]+[' ']*[A-Z]*[a-z]*$";
            while(!Regex.IsMatch(first_name, p1))
            {
                Console.Write("Please enter the proper First name : ");
                first_name = Console.ReadLine();
            }
            Console.Write("Lastname: ");
            string last_name = Console.ReadLine();
            string p2 = "^[A-Z][a-z]+$";
            while(!Regex.IsMatch(last_name, p2))
            {
                Console.Write("Please enter the proper Last Name: ");
                last_name = Console.ReadLine();
            }
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("State: ");
            string state = Console.ReadLine();
            Console.Write("Zipcode: ");
            string zip = Console.ReadLine();
            string p3 = "^[0-9]{6}$";
            while (!Regex.IsMatch(zip, p3))
            {
                Console.Write("Please enter the proper Zip Code: ");
                zip = Console.ReadLine();
            }
            Console.Write("Email: ");
            string email = Console.ReadLine();
            string p4 = "^[a-z]+[0-9]+[@][a-z]+[.][a-z]{1,3}$";
            while (!Regex.IsMatch(email, p4))
            {
                Console.Write("Please enter the proper Email ID: ");
                email = Console.ReadLine();
            }
            Console.Write("Phone number: ");
            long phone_number = Convert.ToInt64(Console.ReadLine());
            string str = phone_number.ToString();
            string p5 = "^[7-9][0-9]{9}$";
            while (!Regex.IsMatch(str, p5))
            {
                Console.Write("Please enter the proper Phone Number: ");
                phone_number = Convert.ToInt64(Console.ReadLine());
                str = phone_number.ToString();
            }
            Contact newc = new Contact(first_name, last_name, address, city, state, zip, phone_number, email);
            contacts.Add(newc);

        }
        public void display()
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"Contacts{i + 1}");
                Console.WriteLine();
                Console.WriteLine($"FirstName: {contacts[i].Fname}");
                Console.WriteLine($"lastname: {contacts[i].lastname}");
                Console.WriteLine($"address: {contacts[i].Addres}");
                Console.WriteLine($"city: {contacts[i].City}");
                Console.WriteLine($"state: {contacts[i].State}");
                Console.WriteLine($"zipcode: {contacts[i].ZipCode}");
                Console.WriteLine($"email: {contacts[i].Email}");
                Console.WriteLine($"Phone number: {contacts[i].PhoneNumber}");
                Console.WriteLine();

            }


        }
        public void edit()
        {
            Console.WriteLine("Enter the email ID of the contact to edit");
            string email = Console.ReadLine();
            string field = "", new_value = "";
            int num = 0;
            int flag = 0;
            foreach (var con in contacts)
            {
                if (con.Email == email)
                {
                    flag = 1;
                    Console.WriteLine("Enter the field name you want to edit");
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
                            con.Fname = new_value;
                            break;
                        case "lastname":
                            con.lastname = new_value;
                            break;
                        case "address":
                            con.Addres = new_value;
                            break;
                        case "city":
                            con.City = new_value;
                            break;
                        case "state":
                            con.State = new_value;
                            break;
                        case "zip":
                            con.ZipCode = new_value;
                            break;
                        case "phone Number":
                            con.PhoneNumber = num;
                            break;
                        case "email":
                            con.Email = new_value;
                            break;
                    }
                }

            }
            if (flag == 0)
            {
                Console.WriteLine("No Such Contact is found in the AddressBook");

            }

        }
        public void Delete()
        {
            int flag = 0;
            Console.WriteLine("Enter the mail id of the contact to edit");
            string email = Console.ReadLine();
            foreach (var con in contacts)
            {
                if (con.Email == email)
                {
                    flag = 1;
                    contacts.Remove(con);
                    Console.WriteLine("The Contact is Deleted from the Address Book");
                    break;
                }

            }
            if (flag == 0)
            {
                Console.WriteLine("Contact not found in the addressBook");
            }

        }
        public List<Contact> SearchByCity(string city)
        {
            return contacts.Where(contact => contact.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Contact> SearchByState(string state)
        {
            return contacts.Where(contact => contact.State.Equals(state, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Contact> SearchByName(string name)
        {
            return contacts.Where(contact => contact.Fname.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public int GetContactCountByCity(string city)
        {
            return contacts.Count(contact => contact.City.Equals(city, StringComparison.OrdinalIgnoreCase));
        }
        public int GetContactCountByState(string state)
        {
            return contacts.Count(contact => contact.State.Equals(state, StringComparison.OrdinalIgnoreCase));
        }
    }

}

