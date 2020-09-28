using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.Handlers
{
    public class ProductHandler
    {
        public List<PRODUCTO> GetProducts()
        {
            using (PRODUCTS_DBEntities db = new PRODUCTS_DBEntities())
            {
                return db.PRODUCTOes.ToList();
            }
        }
    }
}