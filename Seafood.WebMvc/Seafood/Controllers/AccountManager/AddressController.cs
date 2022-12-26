using Domain.Constant;
using Domain.Helpers;
using Domain.Models.ResponseModel;
using Seafood.CustomAuthen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers.AccountManager
{
    [SessionAuthen]
    public class AddressController : BaseController
    {
        // GET: AddressList
        public ActionResult AddressList(string idItem = Constant.Id_So_Dia_Chi)
        {
            var userData = GetCurrentUser();
            var uri = ApiUri.Get_GetListAddressByUserId + string.Format($"?userId={userData.UserId}");
            var addresses = provider.GetAsync<List<Addresse>>(uri);
            if (addresses == null || addresses.Result == null || addresses.Result.Data == null)
            {
                return View(new Addresse());
            }
            var result = addresses.Result.Data;
            ViewBag.IdItem = idItem;
            return View(result);
        }
        public ActionResult AddressAdd()
        {
            ViewBag.IdItem = Constant.Id_So_Dia_Chi;
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewAddress(
            string fullName, string mobile, string codeRegion, string codeDistrict, string codeWard, int typeAddress,bool isAddressMain, string address)
        {
            if (string.IsNullOrEmpty(mobile) || !Helper.ValidPhoneNumer(mobile))
            {
                return Json(Bad_Request("Số điện thoại không hợp lệ"));
            }
            var userData = GetCurrentUser();
            dynamic model = new
            {
                UserId = userData.UserId,
                FullName = fullName,
                Mobile = mobile,
                CodeRegion = codeRegion,
                CodeDistrict = codeDistrict,
                CodeWard = codeWard,
                TypeAddress = typeAddress,
                IsAddressMain = isAddressMain,
                Address = address,
            };
            var isCreate = provider.PostAsync<bool>(ApiUri.Post_CreateAddressByUserId, model);
            if (isCreate == null || isCreate.Result == null || !isCreate.Result.Success)
            {
                return View(Server_Error());
            }
            return Json(Success_Request(isCreate.Result.Data));
        }
        public ActionResult AddressEdit()
        {
            ViewBag.IdItem = Constant.Id_So_Dia_Chi;
            return View();
        }
    }
}