using Domain.Constant;
using Domain.Models.ResponseModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var products = provider.GetAsync<List<Product>>(ApiUri.Get_ProductGetAllProd);
            if (products == null || products.Result.Data == null)
            {
                return View();
            }
            var result = products.Result.Data;
            return View(result);
        }
    }
}