using Products.Handlers;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class UserController : Controller
    {
        private readonly UserHandler userHandler = new UserHandler();
        // GET: User
        public new ActionResult User()
        {
            if (Convert.ToString(Session["User"]) != "")
            {
                List<USUARIO> users = userHandler.GetUSers();
                return View(users);
            }
            else
            {
                return RedirectToAction("../Login/Login");
            }
        }

        public ActionResult ShowCreateUser()
        {
            return PartialView("_CreateUser");
        }

        public ActionResult ShowEditUser(string userName)
        {
            USUARIO user = userHandler.GetUserByName(userName);
            return PartialView("_EditUser", user);
        }

        public JsonResult CreateUser(string userName, string userPwd, string userAge, string userGender, string userNationality, string userRol)
        {
            object result;
            USUARIO user = new USUARIO
            {
                NOMBRE_USUARIO = userName,
                PWD_USUARIO = userPwd,
                EDAD_USUARIO = Convert.ToInt32(userAge),
                GENERO_USUARIO = userGender,
                NACIONALIDAD_USUARIO = userNationality,
                ROL_ID_ROL = Convert.ToInt32(userRol)
            };

            try
            {
                bool valid = userHandler.CreateUser(user);

                if (valid)
                {
                    result = new
                    {
                        response = "OK",
                        description = "User created successfuly"
                    };
                }
                else
                {
                    result = new
                    {
                        response = "ERROR",
                        description = "An error have ocurred in the user creation."
                    };
                }
            }
            catch(Exception e)
            {
                result = new
                {
                    response = "ERROR",
                    description = e.Message
                };
            }

            return Json(result);
        }

        public JsonResult DeleteUser(string userName)
        {
            object result;

            try
            {
                bool deleted = userHandler.DeleteUser(userName);

                if (deleted)
                {
                    result = new
                    {
                        response = "OK",
                        description = "User deleted successfuly."
                    };
                }
                else
                {
                    result = new
                    {
                        response = "ERROR",
                        description = "An error have ocurred in the user creation."
                    };
                }
            }
            catch(Exception e)
            {
                result = new
                {
                    response = "ERROR",
                    description = e.Message
                };
            }

            return Json(result);
        }

        public JsonResult EditUser(string userName, string userPwd, string userAge, string userGender, string userNationality, string userRol)
        {
            object result;

            USUARIO user = new USUARIO
            {
                NOMBRE_USUARIO = userName,
                PWD_USUARIO = userPwd,
                EDAD_USUARIO = Convert.ToInt32(userAge),
                GENERO_USUARIO = userGender,
                NACIONALIDAD_USUARIO = userNationality,
                ROL_ID_ROL = Convert.ToInt32(userRol)
            };

            try
            {
                bool updated = userHandler.EditUser(user);

                if (updated)
                {
                    result = new
                    {
                        response = "OK",
                        description = "User {0} updated successfuly.", userName
                    };
                }
                else
                {
                    result = new
                    {
                        response = "ERROR",
                        description = "An error have ocurred in the user edition."
                    };
                }
            }
            catch (Exception e)
            {
                result = new
                {
                    response = "ERROR",
                    description = e.Message
                };
            }

            return Json(result);
        }
    }
}