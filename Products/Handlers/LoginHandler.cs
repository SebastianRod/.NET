using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Handlers
{
    public class LoginHandler
    {
        public bool LoginUser(USUARIO user)
        {
            bool validUser = false;

            using (PRODUCTS_DBEntities db = new PRODUCTS_DBEntities())
            {
                var query = db.USUARIOs.Where(u => u.ID_USUARIO == user.ID_USUARIO && u.PWD_USUARIO == user.PWD_USUARIO).FirstOrDefault<USUARIO>();
                if (query != null)
                {
                    var context = HttpContext.Current;
                    context.Session["User"] = query.NOMBRE_USUARIO;
                    context.Session["Role"] = query.ROL.NOMBRE_ROL;
                    context.Session["Age"] = query.EDAD_USUARIO;
                    context.Session["Gender"] = query.GENERO_USUARIO;
                    context.Session["Nationality"] = query.NACIONALIDAD_USUARIO;
                    validUser = true;
                }
            }

            return validUser;
        }
    }
}