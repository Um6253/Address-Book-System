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
            Console.ReadLine();
        }
        public class Address_Book
        { 


        
            public string First_Name;
            public string Last_Name;
            public string Address;
            public string City;
            public string State;
            public int ZipCode;
            public int Ph_Number;
            public string Email;
            
        
        }

    }
}
