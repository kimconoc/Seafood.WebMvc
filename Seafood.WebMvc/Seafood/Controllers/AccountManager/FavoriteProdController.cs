﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers.AccountManager
{
    public class FavoriteProdController : BaseController
    {
        // GET: FavoriteProd
        public ActionResult FavoriteProd(string idItem)
        {
            ViewBag.IdItem = idItem;
            return View();
        }
    }
}