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
            var baskets = provider.GetAsync<List<Basket>>(uri);
            if (baskets == null || baskets.Result == null || baskets.Result.Data == null)
            {
                return View(new List<Basket>());
            }
            var result = baskets.Result.Data;

            var uriAddress = ApiUri.Get_GetListAddressByUserId + string.Format($"?userId={userData.UserId}");
            var addresses = provider.GetAsync<List<Addresse>>(uriAddress);
            if (addresses != null && addresses.Result != null && addresses.Result.Data != null)
            {
                ViewBag.Address = addresses.Result.Data.FirstOrDefault(x => x.IsAddressMain);
            }
            return View(result);
        }

        public ActionResult ExecuteDeleteBasket(List<Guid> lstBasket)
        {
            return Json(true);
        }
    }
}