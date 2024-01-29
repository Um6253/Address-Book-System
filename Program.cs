using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Address Book");
            Console.WriteLine("Enter your Details");
            Console.Write("Enter Your FirstName: ");
            string first_Name = Console.ReadLine();
            Console.Write("Enter Your LastName: ");
            string last_Name = Console.ReadLine();
            Console.Write("Enter Your Address: ");
            string address =Console.ReadLine();
            Console.Write("Enter Your city: ");
            string city =Console.ReadLine();
            Console.Write("Enter Your state: ");
            string state =Console.ReadLine();
            Console.Write("Enter Your zipCode");
            int zipCode =Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Your PhoneNumber ");
            long ph_Number = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Your Email ID: ");
            String email=Console.ReadLine();
            Console.ReadLine();
        }
        public class Address_Book
        { 
            public string First_Name;
            public string Last_Name;
            public string Address;
            public string City;
            public string State;
            public int ZipCode ;
            public long Ph_Number;
            public string Email;

            public void AddDetails(string first_Name, string last_Name, string address, string city, string state, int zipCode, int ph_Number, string email)
            {
                this.First_Name = first_Name;
                this.Last_Name = last_Name;
                this.Address = address;
                this.City = city;
                this.State = state;
                this.ZipCode = zipCode;
                this.Ph_Number = ph_Number;
                this.Email = email;
            }
        }

    }
}
