using Domain.Constant;
using Domain.Models.ResponseModel;
using Newtonsoft.Json;
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
        public ActionResult Basket(Guid? addressSeafoodId)
        {
            var userData = GetCurrentUser();
            var uri = ApiUri.Get_GetBasketByUserId + string.Format($"?userId={userData.UserId}");
            var baskets = provider.GetAsync<List<Basket>>(uri);
            if (baskets == null || baskets.Result == null || baskets.Result.Data == null)
            {
                return View(new List<Basket>());
            }
            var result = baskets.Result.Data;

            if(addressSeafoodId == null || addressSeafoodId ==  Guid.Empty)
            {
                var uriAddress = ApiUri.Get_GetListAddressByUserId + string.Format($"?userId={userData.UserId}");
                var addresses = provider.GetAsync<List<Addresse>>(uriAddress);
                if (addresses != null && addresses.Result != null && addresses.Result.Data != null)
                {
                    ViewBag.Address = addresses.Result.Data.FirstOrDefault(x => x.IsAddressMain);
                }
            }  
            else
            {

                var shopSeafoods= provider.GetAsync<List<ShopSeafood>>(ApiUri.Get_GetInfoShopSeeFood);
                if (shopSeafoods != null && shopSeafoods.Result != null && shopSeafoods.Result.Data != null)
                {
                    var shopSeafood = shopSeafoods.Result.Data.FirstOrDefault(x => x.Id == addressSeafoodId);
                    Addresse addresse = new Addresse()
                    {
                        Id = shopSeafood.Id,
                        FullName = shopSeafood.Name,
                        Mobile = shopSeafood.Mobile,
                        TypeAddress = shopSeafood.TypeAddress,
                        Address = shopSeafood.Address,
                        NameWard = shopSeafood.NameWard,
                        NameDistrict = shopSeafood.NameDistrict,
                        NameRegion = shopSeafood.NameRegion,
                    };
                    ViewBag.Address = addresse;
                }
            }    
            return View(result);
        }
        [HttpPost]
        public ActionResult ExecuteDeleteBasket(List<Guid> lstBasket)
        {
            var isDeleted = provider.PostAsync<bool>(ApiUri.Delete_DeleteBasketById, lstBasket);
            if (isDeleted == null || isDeleted.Result == null || !isDeleted.Result.Success)
            {
                return Json(Server_Error());
            }
            return Json(Success_Request(isDeleted.Result.Data));
        }
        [HttpPost]
        public ActionResult CreateOrderUserId(string jsonOrders)
        {
            if (string.IsNullOrEmpty(jsonOrders))
            {
                return Json(Bad_Request());
            }
            var orders = JsonConvert.DeserializeObject<List<Order>>(jsonOrders);

            if (orders == null || !orders.Any())
            {
                return Json(Bad_Request());
            }

            var iscreate = provider.PostAsync<bool>(ApiUri.Post_CreateOrderUserId, orders);
            if (iscreate == null || iscreate.Result == null || !iscreate.Result.Success)
            {
                return Json(Server_Error());
            }

            return Json(Success_Request(iscreate.Result.Data));
        }
    }
}