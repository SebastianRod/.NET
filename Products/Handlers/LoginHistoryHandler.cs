using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Products.Handlers
{
    public class LoginHistoryHandler
    {
        public List<LOGIN_LOG> GetLoginLogs()
        {
            using (PRODUCTS_DBEntities db = new PRODUCTS_DBEntities())
            {
                var logs = (from log in db.LOGIN_LOG.Include(item => item.USUARIO)
                            select log).ToList();
                return logs;
            }
        }

        public void CreateLoginEntry(USUARIO user)
        {
            using (PRODUCTS_DBEntities db = new PRODUCTS_DBEntities())
            {
                LOGIN_LOG log = new LOGIN_LOG
                {
                    FECHA_LOGIN = DateTime.Now,
                    USUARIO_ID_USUARIO = user.ID_USUARIO
                };

                db.LOGIN_LOG.Add(log);
                db.SaveChanges();
            }
        }
    }
}