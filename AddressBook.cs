using Address_Book_System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Address_Book_System.Program;

namespace Address_Book_System
{
    class AddressBook
    {

        List<Contact> contacts = new List<Contact>();
        public void SortByName()
        {
            contacts = contacts.OrderBy(contact => contact.Fname).ToList();
        }
        public void SortByCity()
        {
            contacts = contacts.OrderBy(contact => contact.City).ToList();
        }
        public void SortByState()
        {
            contacts = contacts.OrderBy(contact => contact.State).ToList();
        }
        public void SortByZipCode()
        {
            contacts = contacts.OrderBy(contact => contact.ZipCode).ToList();
        }


        public void add_contact()
        {
            Console.Write("First name: ");
            string first_name = Console.ReadLine();
            string p1 = "^[A-Z][a-z]+[' ']*[A-Z]*[a-z]*$";
            while (!Regex.IsMatch(first_name, p1))
            {
                Console.Write("Please enter the proper First name : ");
                first_name = Console.ReadLine();
            }
            Console.Write("Lastname: ");
            string last_name = Console.ReadLine();
            string p2 = "^[A-Z][a-z]+$";
            while (!Regex.IsMatch(last_name, p2))
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
            Contact newc = new Contact
            {


                Fname = first_name,
                lastname = last_name,
                Addres = address,
                City = city,
                State = state,
                ZipCode = zip,
                PhoneNumber = phone_number,
                Email = email
            };
            contacts.Add(newc);
            //Contact newc = new Contact(first_name, last_name, address, city, state, zip, phone_number, email);

        }
        public void display()
        {
            for (int i = 0; i < contacts.Count; i++)
            {
                Console.WriteLine($"Contact  {i + 1}");
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
        public void displaybyNames()
        {
            SortByName();
            display();

        }
        public void displaybystate()
        {
            SortByState();
            display();

        }
        public void displaybycity()
        {
            SortByCity();
            display();
        }
        public void displaybyzipcode()
        {
            SortByZipCode();
            display();
        }
        public void edit()
        {
            Console.WriteLine("Enter the email ID of the contact to edit");
            string email = Console.ReadLine();
            Contact editContact = contacts.Find(contact => contact.Email == email);

            if (editContact != null)
            {
                Console.WriteLine();

                int flag = 0, n;
                do
                {
                    Console.WriteLine("Enter the option to edit : ");
                    Console.WriteLine("1. First Name\n2. Last Name\n3. Phone Number\n4. Email\n5. Address\n6. City\n7. State\n8. ZipCode\n9. Exit\n");
                    n = Convert.ToInt32(Console.ReadLine());

                    switch (n)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Enter New First Name : ");
                            editContact.Fname = Console.ReadLine();
                            string p1 = "^[A-Z][a-z]+[' ']*[A-Z]*[a-z]*$";
                            while (!Regex.IsMatch(editContact.Fname, p1))
                            {
                                Console.Write("Please enter the proper First name : ");
                                editContact.Fname = Console.ReadLine();
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Enter New Last Name : ");
                            editContact.lastname = Console.ReadLine();
                            string p2 = "^[A-Z][a-z]+$";
                            while (!Regex.IsMatch(editContact.lastname, p2))
                            {
                                Console.Write("Please enter the proper Last Name: ");
                                editContact.lastname = Console.ReadLine();
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Enter New Phone Number : ");
                            editContact.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                            string str = editContact.PhoneNumber.ToString();
                            string p5 = "^[7-9][0-9]{9}$";
                            while (!Regex.IsMatch(str, p5))
                            {
                                Console.Write("Please enter the proper Phone Number: ");
                                editContact.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                                str = editContact.PhoneNumber.ToString();
                            }
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Enter New Email : ");
                            editContact.Email = Console.ReadLine();
                            string p4 = "^[a-z]+[0-9]+[@][a-z]+[.][a-z]{1,3}$";
                            while (!Regex.IsMatch(editContact.Email, p4))
                            {
                                Console.Write("Please enter the proper Email ID: ");
                                editContact.Email = Console.ReadLine();
                            }
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Enter New Address : ");
                            editContact.Addres = Console.ReadLine();
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Enter New City : ");
                            editContact.City = Console.ReadLine();
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Enter New State : ");
                            editContact.State = Console.ReadLine();
                            break;
                        case 8:
                            Console.Clear();
                            Console.WriteLine("Enter New ZipCode : ");
                            editContact.ZipCode = (Console.ReadLine());
                            string p3 = "^[0-9]{6}$";
                            while (!Regex.IsMatch(editContact.ZipCode, p3))
                            {
                                Console.Write("Please enter the proper Zip Code: ");
                                editContact.ZipCode = Console.ReadLine();
                            }
                            break;
                        case 9:
                            Console.WriteLine(" Contact Edited..");
                            flag = 1;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }

                    Console.Clear();
                    Console.WriteLine(" Contact Edited..");
                    Console.WriteLine();
                } while (flag == 0);
            }
            else
            {
                Console.WriteLine($"The contact with the email '{email}' is not found in the contact list.");
                Thread.Sleep(2000);
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




        public void SaveToFile(Dictionary<string, AddressBook> dict)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\MANIKANTA\Desktop\LOCOBUZZ\Address Book System\AD'S\My File.txt"))
            {

                foreach (var contact in dict)

                {
                    writer.WriteLine($"Address Book of{contact.Key}");
                    foreach (var contact2 in contact.Value.Getall())
                    {
                        int count = 1;
                        writer.WriteLine($"contact:{count++}\nFirst Name: {contact2.Fname}\nLast Name: {contact2.lastname}\n" +
                            $"Address: {contact2.Addres}\nCity: {contact2.City}\nState:{contact2.State}" +
                            $"\nZipCode: {contact2.ZipCode}\nPhone Number: {contact2.PhoneNumber}\nEmail ID:{contact2.Email}\n");
                    }
                }
            }
        }

        public void LoadFromFile()
        {
            if (File.Exists(@"C:\Users\MANIKANTA\Desktop\LOCOBUZZ\Address Book System\AD'S\My File.txt"))
            {
                
               

                using (StreamReader reader = new StreamReader(@"C:\Users\MANIKANTA\Desktop\LOCOBUZZ\Address Book System\AD'S\My File.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] contactData = line.Split(',');
                        if (contactData.Length == 8)
                        {
                            Contact newContact = new Contact
                            {

                                Fname = contactData[0],
                                lastname = contactData[1],
                                Addres = contactData[2],
                                City = contactData[3],
                                State = contactData[4],
                                ZipCode = contactData[5],
                                PhoneNumber = long.Parse(contactData[6]),
                                Email = contactData[7]
                            };
                            

                        }
                            Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine($"File  not found.");
            }
        }
        public List<Contact> Getall() 
        {
            return contacts;
        }
    }
}
