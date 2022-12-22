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
            var uri = ApiUri.Get_GetListRegion + string.Format($"?codeRegion={codeRegion}&codeDistrict={codeDistrict}");
            var result = provider.GetAsync<List<Region>>(uri);
            if (result != null || result.Result != null || result.Result.Data != null)
            {
                var lstData = result.Result.Data.Where(x => string.IsNullOrEmpty(txt) || x.NameRegion.ToLower().GetVnStringOnlyCharactersAndNumbers().Contains(txt.ToLower().GetVnStringOnlyCharactersAndNumbers())).ToList();
                foreach (var item in lstData)
                {
                    if (!lstResult.Any(r => r.CodeRegion == item.CodeRegion))
                    {
                        lstResult.Add(item);
                    }
                }               
            }

            return Json(lstResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListDistrict(string txt = "", string codeRegion = "", string codeDistrict = "")
        {
            if (string.IsNullOrEmpty(codeRegion))
                return Json(false);

            var lstResult = new List<Region>();
            var uri = ApiUri.Get_GetListRegion + string.Format($"?codeRegion={codeRegion}&codeDistrict={codeDistrict}");
            var result = provider.GetAsync<List<Region>>(uri);
            if (result != null || result.Result != null || result.Result.Data != null)
            {
                var lstData = result.Result.Data.Where(x => string.IsNullOrEmpty(txt) || x.NameDistrict.ToLower().GetVnStringOnlyCharactersAndNumbers().Contains(txt.ToLower().GetVnStringOnlyCharactersAndNumbers())).ToList();
                foreach (var item in lstData)
                {
                    if (!lstResult.Any(r => r.CodeDistrict == item.CodeDistrict))
                    {
                        lstResult.Add(item);
                    }
                }
            }

            return Json(lstResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListWard(string txt = "", string codeRegion = "", string codeDistrict = "")
        {
            if (string.IsNullOrEmpty(codeRegion) || string.IsNullOrEmpty(codeDistrict))
                return Json(false);

            var lstResult = new List<Region>();
            var uri = ApiUri.Get_GetListRegion + string.Format($"?codeRegion={codeRegion}&codeDistrict={codeDistrict}");
            var result = provider.GetAsync<List<Region>>(uri);
            if (result != null || result.Result != null || result.Result.Data != null)
            {
                var lstData = result.Result.Data.Where(x => string.IsNullOrEmpty(txt) || x.NameWard.ToLower().GetVnStringOnlyCharactersAndNumbers().Contains(txt.ToLower().GetVnStringOnlyCharactersAndNumbers())).ToList();
                foreach (var item in lstData)
                {
                    if (!lstResult.Any(r => r.CodeWard == item.CodeWard))
                    {
                        lstResult.Add(item);
                    }
                }
            }

            return Json(lstResult, JsonRequestBehavior.AllowGet);
        }
    }
}