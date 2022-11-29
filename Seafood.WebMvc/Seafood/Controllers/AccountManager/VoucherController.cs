using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers.AccountManager
{
    public class VoucherController : Controller
    {
        // GET: Voucher
        public ActionResult Voucher(string idItem)
        {
            ViewBag.IdItem = idItem;
            return View();
        }
    }
}