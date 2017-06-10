using ASP_Test.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.Serialization;


namespace ASP_Test.Controllers
{
    public class HomeController : Controller
    {
        private List<User> _users = new List<User>();

        [XmlArray("UsersList")]
        public List<User> Users {
            get { return _users; }
            set
            {
                if (value != null) _users = value;
            }
        }

        private void Serializable(string xmlFileName, List<User> userList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            using (FileStream fs = new FileStream(xmlFileName, FileMode.OpenOrCreate))
            {
                
                serializer.Serialize(fs, userList);
            }
        }

        private void Deserializable(string xmlFileName,List<User> userList)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<User>));
            TextReader reader = new StreamReader(xmlFileName);
            var enumerablelList = deserializer.Deserialize(reader) as List<User>;
            if (enumerablelList != null)
                foreach (var usr in enumerablelList)
                {
                    userList.Add(new User(usr.FirstName, usr.LastName, usr.Email));
                    userList[userList.Count - 1].ID = usr.ID;
                    
                }

            reader.Close();

        }

        public ActionResult Index()
        {
            Deserializable(Server.MapPath("~/App_Data/UsersInfo.xml"), Users);
            return View(Users);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User userFromView)
        {
            Deserializable(Server.MapPath("~/App_Data/UsersInfo.xml"), Users);
            Users.Add(new User(userFromView.FirstName,userFromView.LastName,userFromView.Email));
            Serializable(Server.MapPath("~/App_Data/UsersInfo.xml"), Users);
            return View("Index",Users);
        }

        [HttpPost]
        public ActionResult EditUser(User userFromView)
        {
            Deserializable(Server.MapPath("~/App_Data/UsersInfo.xml"), Users);
            var usr = Users.Find(u => u.ID == userFromView.ID);
            usr.FirstName = userFromView.FirstName;
            usr.LastName = userFromView.LastName;
            usr.Email = userFromView.Email;
            Serializable(Server.MapPath("~/App_Data/UsersInfo.xml"), Users);
            return View("Index", Users);
        }

        public ActionResult EditUser(object id)
        {
            Deserializable(Server.MapPath("~/App_Data/UsersInfo.xml"), Users);
            User usr = Users.Find(u => u.ID == Convert.ToInt64(id));
            return View(usr);
        }

        [HttpPost]
        public ActionResult RemoveUser(User userFromView)
        {
            Deserializable(Server.MapPath("~/App_Data/UsersInfo.xml"), Users);
            var usr = Users.FirstOrDefault(u => u.ID == userFromView.ID);
            Users.Remove(usr);
            System.IO.File.WriteAllText(Server.MapPath("~/App_Data/UsersInfo.xml"), String.Empty);
            Serializable(Server.MapPath("~/App_Data/UsersInfo.xml"), Users);
            return View("Index", Users);
        }

        public ActionResult RemoveUser(object id)
        {
            Deserializable(Server.MapPath("~/App_Data/UsersInfo.xml"), Users);
            User usr = Users.Find(u => u.ID == Convert.ToInt64(id));
            return View(usr);
        }
    }
}