using Seafood.CustomAuthen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers.AccountManager
{
    [SessionAuthen]
    public class AddressController : Controller
    {
        // GET: AddressList
        public ActionResult AddressList(string idItem)
        {
            ViewBag.IdItem = idItem;
            return View();
        }
        public ActionResult AddressAdd()
        {
            return View();
        }
        public ActionResult AddressEdit()
        {
            return View();
        }
    }
}