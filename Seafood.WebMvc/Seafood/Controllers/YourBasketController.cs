using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers
{
    public class YourBasketController : Controller
    {
        public ActionResult Basket()
        {
            return View();
        }
    }
}