using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ASP_Test.Models
{
    public class Post
    {
        public string Title { get; set; }
        public string Date { get; set;}

        public Post()
        {

        }

        public Post(string title)
        {
            Title = title;
            Date  = DateTime.Now.ToShortDateString();
        }

    }
}