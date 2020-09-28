using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.Handlers
{
    public class UserHandler
    {
        public List<USUARIO> GetUSers()
        {
            using (PRODUCTS_DBEntities db = new PRODUCTS_DBEntities())
            {
                var users = db.USUARIOs.ToList<USUARIO>();
                return users;
            }
        }

        public USUARIO GetUserByName(string userName)
        {
            using (PRODUCTS_DBEntities db = new PRODUCTS_DBEntities())
            {
                return db.USUARIOs.Where(u => u.NOMBRE_USUARIO.Equals(userName)).FirstOrDefault();
            }
        }

        public bool CreateUser(USUARIO user)
        {
            bool result = false;

            using (PRODUCTS_DBEntities db = new PRODUCTS_DBEntities())
            {
                db.USUARIOs.Add(user);
                db.SaveChanges();
                result = true;
            }

            return result;
        }

        public bool DeleteUser(string userName)
        {
            bool result = false;

            using (PRODUCTS_DBEntities db = new PRODUCTS_DBEntities())
            {
                var user = db.USUARIOs.Where(u => u.NOMBRE_USUARIO.Equals(userName)).FirstOrDefault();
                db.USUARIOs.Remove(user);
                db.SaveChanges();

                result = true;
            }

            return result;
        }

        public bool EditUser(USUARIO user)
        {
            bool result = false;

            using (PRODUCTS_DBEntities db = new PRODUCTS_DBEntities())
            {
                var userResult = db.USUARIOs.Where(u => u.NOMBRE_USUARIO.Equals(user.NOMBRE_USUARIO)).FirstOrDefault();

                userResult.NOMBRE_USUARIO = user.NOMBRE_USUARIO;
                userResult.PWD_USUARIO = user.PWD_USUARIO;
                userResult.EDAD_USUARIO = user.EDAD_USUARIO;
                userResult.GENERO_USUARIO = user.GENERO_USUARIO;
                userResult.NACIONALIDAD_USUARIO = user.NACIONALIDAD_USUARIO;
                userResult.ROL_ID_ROL = user.ROL_ID_ROL;

                db.SaveChanges();

                result = true;
            }

            return result;
        }
    }
}