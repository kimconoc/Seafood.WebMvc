using Seafood.Model;
using Domain.Constant;
using Domain.FileLog;
using Domain.Models.ParameterModel;
using Domain.Models.ResponseModel;
using Newtonsoft.Json;
using Service.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Domain.Helpers;
using System.Drawing.Imaging;
using Seafood.Models;
using Seafood.MemCached;

namespace Seafood.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult YourAccount(string idItem)
        {
            ViewBag.IdItem = idItem;
            return View();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string ReturnUrl = "")
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Nhập thông tin đăng nhập";
                return View(model);
            }
            var userBase = provider.PostAsync<User>(ApiUri.POST_AccountLogin, model);
            if (userBase == null || userBase.Result == null || userBase.Result.Data == null)
            {
                ViewBag.Message = "Tài khoản đăng nhập không đúng";
                return View(model);
            }
            Authenticator.SetAuth(userBase.Result.Data, HttpContext);
            return RedirectToAction("Seafood", "Home");
        }

        public ActionResult Logout()
        {
            var isLogout = provider.GetAsync<bool>(ApiUri.POST_AccountLogout);
            if (isLogout == null || !isLogout.Result.Data)
            {
                ViewBag.Message = "Có lỗi xảy ra";
                return View();
            }
            if (!string.IsNullOrEmpty(Authenticator.GetSigninToken()) && Request.Cookies[Authenticator.GetSigninToken()] != null)
            {
                // Clear your data
            }    
            Authenticator.LogOff(HttpContext);
            return RedirectToAction("Seafood", "Home");
        }

        [HttpPost]
        public ActionResult CreateAccount(string jsonObject)
        {
            dynamic data = null;
            try
            {
                if (string.IsNullOrEmpty(jsonObject))
                {
                    data = new
                    {
                        IsCreate = false,
                        Message = "Dữ liệu trống"
                    };
                    return Json(data);
                }
                var obj = new JavaScriptSerializer().Deserialize<dynamic>(jsonObject);
                if (!Helper.ValidPhoneNumer(obj["r_numberPhone"]))
                {
                    data = new
                    {
                        IsCreate = false,
                        Message = "Số điện thoại không hợp lệ"
                    };
                    return Json(data);
                }
                dynamic model = new
                {
                    FirstName = obj["r_firstName"],
                    LastName = obj["r_lastName"],
                    Email = obj["r_email"],
                    NumberPhone = obj["r_numberPhone"],
                    Password = obj["r_password"],
                };
                var isCreate = provider.PostAsync<bool>(ApiUri.POST_AccountCreate, model).Result;
                if(!isCreate.Data)
                {
                    data = new
                    {
                        IsCreate = false,
                        Message = isCreate.Message.ViMessage
                    };
                    return Json(data);
                }
                data = new
                {
                    IsCreate = true,
                    Message = "Đăng ký tài khoản thành công"
                };
                return Json(data);
            }   
            catch(Exception ex)
            {
                FileHelper.GeneratorFileByDay(ex.ToString(), MethodBase.GetCurrentMethod().Name);
                data = new
                {
                    IsCreate = false,
                    Message = "Có lỗi trong quá trình xử lý"
                };
                return Json(data);
            }
        }

        [HttpPost]
        public ActionResult UploadAvartaUser(HttpPostedFileBase imgUpload)
        {
            // kiếm tra dung lượng ảnh
            //var kb_img = (imgUpload.ContentLength / 1024);

            if (imgUpload == null)
            {
                return Json(Success_Request());
            }    
            if(imgUpload.FileName.ToLower().Contains(".jpg") || imgUpload.FileName.ToLower().Contains(".png")
                || imgUpload.FileName.ToLower().Contains(".gif") || imgUpload.FileName.ToLower().Contains(".jpeg")
                || imgUpload.FileName.ToLower().Contains(".icon"))
            {
                try
                {
                    var updated = provider.PostAsync<HttpPostedFileBase>(ApiUri.POST_AccountUpdateAvarta, imgUpload);
                    if (updated == null || updated.Result == null || updated.Result.Data == null || !updated.Result.Success)
                    {
                        return Json(Server_Error());
                    }
                }
                catch
                {
                    return Json(Server_Error());
                }
            }
            else
            {
                return Json(Bad_Request());
            }
            return Json(Success_Request());
        }

        [HttpPost]
        public ActionResult UploadProfileUser(string displayName, string email, string sex, int year, int month, int day)
        {

            var birthday = new DateTime(year, month, day);
            return Json(Success_Request());
        }

        #region private menthod
        #endregion private menthod
    }
}