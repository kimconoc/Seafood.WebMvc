using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers.AccountManager
{
    public class FavoriteProdController : BaseController
    {
        // GET: FavoriteProd
        public ActionResult Index()
        {
            return View();
        }
    }
}