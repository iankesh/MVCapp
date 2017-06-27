using ASP_Test.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.Serialization;
using ASP_Test.DAL;


namespace ASP_Test.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();


        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User userFromView)
        {
           
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditUser(User userFromView)
        {

            return RedirectToAction("Index");
        }

        public ActionResult EditUser(object id)
        {

            return View();
        }

        [HttpPost]
        public ActionResult RemoveUser(User userFromView)
        {
   ;
            return RedirectToAction("Index");
        }

        public ActionResult RemoveUser(object id)
        {
            
            return View();
        }
    }
}