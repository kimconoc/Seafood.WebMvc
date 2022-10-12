using Domain.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers
{
    public class ProdDetailtController : BaseController
    {
        // GET: ProdDetailt
        public ActionResult Detailt(string idProd)
        {
            var prod = new ProdDetailt()
            {
                ReviewProd = 3.5
            };
            return View(prod);
        }
    }
}