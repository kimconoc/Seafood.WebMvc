using Domain.Constant;
using Domain.Models.ResponseModel;
using Seafood.CustomAuthen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers
{
    [SessionAuthen]
    public class YourBasketController : BaseController
    {
        public ActionResult Basket()
        {
            var userData = GetCurrentUser();
            var uri = ApiUri.Get_GetBasketByUserId + string.Format($"?userId={userData.UserId}");
            var addresses = provider.GetAsync<List<Basket>>(uri);
            if (addresses == null || addresses.Result == null || addresses.Result.Data == null)
            {
                return View(new Addresse());
            }
            var result = addresses.Result.Data;
            return View(result);
        }
    }
}