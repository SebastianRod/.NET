using Products.Models;
using Products.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginHandler loginHandler = new LoginHandler();
        private readonly LoginHistoryHandler historyHandler = new LoginHistoryHandler();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ingresar(USUARIO user)
        {
            if (ModelState.IsValid)
            {
                if (loginHandler.LoginUser(user))
                {
                    historyHandler.CreateLoginEntry(user);
                    return RedirectToAction("../Home/Index");
                }
                else
                {
                    ViewBag.Mensaje = "Usuario y/o contraseña incorretos";
                }
            }
            return View("Login");
        }

        public ActionResult LogOut()
        {
            Session.Clear();

            return View("Login");
        }
    }
}