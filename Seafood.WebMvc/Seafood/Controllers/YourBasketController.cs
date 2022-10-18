using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers
{
    public class YourBasketController : Controller
    {
        // GET: ProdDetailt
        public ActionResult Basket(Guid userId)
        {
            return View();
        }
    }
}