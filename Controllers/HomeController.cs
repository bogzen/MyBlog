using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";

            return View();
        }

        public ActionResult Destinations()
        {
            ViewBag.Message = "Destinations";

            return View();
        }

        public ActionResult Travel_tips()
        {
            ViewBag.Message = "Travel tips";

            return View();
        }
    }
}