using Domain.Constant;
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
                return RedirectToAction("Seafood", "Home");
            var uri = ApiUri.Get_GetProdDetailtById + string.Format($"?prodId={prodId}");
            var product = provider.GetAsync<ProdDetailt>(uri);
            if (product == null || product.Result == null || product.Result.Data == null)
            {
                return RedirectToAction("Seafood", "Home");
            }
            var result = product.Result.Data;
            return View(result);
        }
        [HttpPost]
        public ActionResult AddProductToBasket(Guid productId, string processingId)
        {
            var userData = GetCurrentUser();
            dynamic model = new
            {
                UserId = userData.UserId,
                ProductId = productId,
                ProdProcessingId = Guid.Parse(processingId),
            };
            var isAdd = provider.PostAsync<bool>(ApiUri.Post_AddProductToBasket, model);
            if (isAdd == null || isAdd.Result == null || !isAdd.Result.Success)
            {
                return Json(Server_Error());
            }
            return Json(Success_Request(isAdd.Result.Data));
        }
    }
}