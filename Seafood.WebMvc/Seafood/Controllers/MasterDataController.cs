using Domain.Constant;
using Domain.Extentions;
using Domain.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers
{
    public class MasterDataController : BaseController
    {
        public JsonResult GetListRegion(string txt = "",string codeRegion = "", string codeDistrict = "")
        {
            var lstResult = new List<Region>();
            var uri = ApiUri.Get_GetListRegion + string.Format($"?shopCode={codeRegion}&?codeDistrict={codeDistrict}");
            var result = provider.GetAsync<List<Region>>(uri);
            if (result != null || result.Result != null || result.Result.Data != null)
            {
                var lstData = result.Result.Data.Where(x => string.IsNullOrEmpty(txt) || x.NameRegion.ToLower().GetVnStringOnlyCharactersAndNumbers().Contains(txt.ToLower().GetVnStringOnlyCharactersAndNumbers())).ToList();
                foreach (var item in lstData)
                {
                    if (string.IsNullOrEmpty(codeRegion) && string.IsNullOrEmpty(codeDistrict))
                    {
                        if(!lstResult.Any(r => r.CodeRegion == item.CodeRegion))
                        {
                            lstResult.Add(item);
                        }    
                    }
                }               
            }

            return Json(lstResult, JsonRequestBehavior.AllowGet);
        }
    }
}