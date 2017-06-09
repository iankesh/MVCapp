using ASP_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ASP_Test.Controllers
{
    public class HomeController : Controller
    {
        private List<User> users = new List<Models.User>() {
            new User("FirstName1","LastName1","example1@example.com",new Post("LOL")),
            new User("FirstName2","LastName2","example2@example.com",new Post("LOL")),
            new User("FirstName3","LastName3","example3@example.com",new Post("LOL")),
            new User("FirstName4","LastName4","example4@example.com",new Post("LOL")),
            new User("FirstName5","LastName5","example5@example.com",new Post("LOL")) };

        public ActionResult Index()
        {
            return View(users);
        }

        [HttpPost]
        public ActionResult UserData()
        {
            users.Add(new User(Request.Form["FirstName"], Request.Form["LastName"], Request.Form["Email"], new Post(Request.Form["Title"])));
            @ViewBag.Msg = "User added!";
            return PartialView(users);
        }

        

    }
}