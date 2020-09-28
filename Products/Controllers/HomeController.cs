using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Convert.ToString(Session["User"]) != "")
            {
                ViewBag.User = Session["User"];
                ViewBag.Role = Session["Role"];
                ViewBag.Age = Session["Age"];
                ViewBag.Gender = Session["Gender"];
                ViewBag.Nationality = Session["Nationality"];
            }
            else
            {
                return RedirectToAction("../Login/Login");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}