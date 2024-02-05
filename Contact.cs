using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    class Contact
    {
        private string first_name;
        private string last_name;
        private string address;
        private string city;
        private string state;
        private string zipcode;
        private long phone_number;
        private string email;

        public string Fname
        {
            get { return first_name; }
            set { first_name = value; }
        }
        public string lastname
        {
            get { return last_name; }
            set { last_name = value; }
        }
        public string Addres
        {
            get { return address; }
            set { address = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public string ZipCode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }
        public long PhoneNumber
        {
            get { return phone_number; }
            set { phone_number = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public Contact(string first_name, string last_name, string address, string city, string state, string zip, long phone_number, string email)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipcode = zip;
            this.phone_number = phone_number;
            this.email = email;
        }
    }
}
