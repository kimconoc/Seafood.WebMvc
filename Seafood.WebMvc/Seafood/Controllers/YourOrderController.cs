using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers
{
    public class YourOrderController : Controller
    {
        // GET: YourOrder
        public ActionResult Order()
        {
            return View();
        }
        // GET: OrderDetail
        public ActionResult OrderDetail()
        {
            return View();
        }
    }

}