using Products.Handlers;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductHandler productHandler = new ProductHandler();
        // GET: Product
        public ActionResult Product()
        {
            List<PRODUCTO> products = productHandler.GetProducts();
            return View(products);
        }
    }
}