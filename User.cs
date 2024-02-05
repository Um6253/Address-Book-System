using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    public class User
    {
        Dictionary<string, AddressBook> dict = new Dictionary<string, AddressBook>();

        public User()
        {
            dict = new Dictionary<string, AddressBook>();
        }
        public AddressBook GetAddressBook(string name)
        {
            return dict[name];
        }
        public void add_user(string name)
        {
            AddressBook book = new AddressBook();
            if (!dict.ContainsKey(name))
            {

                dict.Add(name, book);
                Console.WriteLine("User added successfully in the addressBook");
            }
            else
            {
                Console.WriteLine($"{name} already exist");
            }

        }

        public void switch_user(string name)
        {
            int flag = 0;
            AddressBook obj2 = new AddressBook();
            foreach (var book in dict)
            {
                if (book.Key == name)
                {
                    obj2 = dict[name];
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("User not found");
            }

        }
        public Dictionary<string, AddressBook> GetPersons()
        {
            return dict;
        }
        public void Display()
        {
            foreach (var book in dict)
            {
                Console.WriteLine(book.Key);
            }
        }
    }
}

