﻿using Domain.Constant;
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
        public ActionResult Detailt(string prodId)
        {
            if(prodId == null)
                return View();
            var uri = ApiUri.Get_GetProdDetailtById + string.Format($"?prodId={prodId}");
            var product = provider.GetAsync<ProdDetailt>(uri);
            if (product == null || product.Result == null || product.Result.Data == null)
            {
                return View();
            }
            var result = product.Result.Data;
            return View(result);
        }
    }
}