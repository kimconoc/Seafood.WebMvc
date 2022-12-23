using Domain.Constant;
using Seafood.CustomAuthen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers.AccountManager
{
    [SessionAuthen]
    public class AddressController : Controller
    {
        // GET: AddressList
        public ActionResult AddressList(string idItem = Constant.Id_So_Dia_Chi)
        {
            ViewBag.IdItem = idItem;
            return View();
        }
        public ActionResult AddressAdd()
        {
            ViewBag.IdItem = Constant.Id_So_Dia_Chi;
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewAddress(
            string fullName, string mobile, string codeRegion, string codeDistrict, string codeWard, int typeAddress,string address)
        {
            return View();
        }
        public ActionResult AddressEdit()
        {
            ViewBag.IdItem = Constant.Id_So_Dia_Chi;
            return View();
        }
    }
}