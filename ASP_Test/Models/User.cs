using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ASP_Test.Models
{
    public class User
    {
        public long ID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public User()
        {

        }

        public User(string fname, string lname,string email,string phone)
        {
            ID = BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0);
            FirstName = fname;
            LastName = lname;
            Email = email;
            PhoneNumber = phone;
        }

        public User(long id,string fname, string lname, string email, string phone)
        {
            ID = id;
            FirstName = fname;
            LastName = lname;
            Email = email;
            PhoneNumber = phone;
        }

    }
}