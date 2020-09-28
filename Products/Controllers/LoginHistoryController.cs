using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Products.Handlers;
using Products.Models;

namespace Products.Controllers
{
    public class LoginHistoryController : Controller
    {
        private readonly LoginHistoryHandler historyHandler = new LoginHistoryHandler();

        // GET: LoginHistory
        public ActionResult LoginHistory()
        {
            if (Convert.ToString(Session["User"]) != "")
            {
                try
                {
                    List<LOGIN_LOG> result = historyHandler.GetLoginLogs();
                    return View(result);
                }
                catch(Exception e)
                {
                    ViewBag.RESULT = "Error";
                    ViewBag.DESCRIPTION = e.Message;
                }
            }

            return View();
        }
    }
}