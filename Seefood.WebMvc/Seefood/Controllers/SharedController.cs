using Domain.Constant;
using Domain.FileLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Seefood.Controllers
{
    public class SharedController : BaseController
    {
        [HttpPost]
        public ActionResult ExecuteToFavourite(string id,string className)
        {
            try
            {
                id = new JavaScriptSerializer().Deserialize<string>(id);
                className = new JavaScriptSerializer().Deserialize<string>(className);
                int indexOf = id.IndexOf("_");
                var prodId = id.Substring(0, indexOf);
                var uri = ApiUri.Get_ProductExecuteToFavourite + string.Format($"?prodId={prodId}&className={className}");
                provider.GetAsync<bool>(uri);
            }
            catch(Exception ex)
            {
                FileHelper.GeneratorFileByDay(ex.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            return default;
        }
    }
}