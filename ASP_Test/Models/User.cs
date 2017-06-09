using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Test.Models
{
    public class User
    {
        public long ID { get;private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Post UserPost { get; set; }

        public User()
        {

        }

        public User(string fname, string lname,string email,Post post)
        {
            ID = BitConverter.ToInt64(Guid.NewGuid().ToByteArray(), 0);
            FirstName = fname;
            LastName = lname;
            Email = email;
            UserPost = post;
        }


    }
}