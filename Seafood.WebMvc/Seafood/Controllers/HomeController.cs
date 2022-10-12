using Domain.Constant;
using Domain.Models.ResponseModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Seafood.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Seafood(string code)
        {
            if(string.IsNullOrEmpty(code))
            {
                var products = provider.GetAsync<List<Product>>(ApiUri.Get_ProductGetAllProd);
                if (products == null || products.Result.Data == null)
                {
                    return View();
                }
                var result = products.Result.Data;
                return View(result);
            }   
            else
            {
                var uri = ApiUri.Get_ProductGetProdByCode + string.Format($"?code={code}");
                var products = provider.GetAsync<List<Product>>(uri);
                if (products == null || products.Result.Data == null)
                {
                    return View();
                }
                var result = products.Result.Data;
                return View(result);
            }      
        }
    }
}