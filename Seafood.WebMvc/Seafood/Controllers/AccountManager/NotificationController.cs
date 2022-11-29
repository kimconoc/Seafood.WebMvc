using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers.AccountManager
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult YourNotification(string idItem)
        {
            ViewBag.IdItem = idItem;
            return View();
        }
    }
}