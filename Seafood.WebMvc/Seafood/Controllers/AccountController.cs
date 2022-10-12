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


namespace Seafood.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string ReturnUrl = "")
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Nhập thông tin đăng nhập";
                return View(model);
            }           
            var userBase = provider.PostAsync<User>(ApiUri.POST_AccountLogin, model);
            if(userBase == null || userBase.Result.Data == null)
            {
                ViewBag.Message = "Tài khoản đăng nhập không đúng";
                return View(model);
            }
            var user = userBase.Result.Data;
            // Lưu thông tin ticket
            var userData = StoreUserData(user);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(1500), false, JsonConvert.SerializeObject(userData), FormsAuthentication.FormsCookiePath);
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
            Response.Cookies.Add(cookie);
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
            FormsAuthentication.SignOut();
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            if(cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(cookie);
            }    
            return RedirectToAction("Seafood", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        #region private menthod
        private UserData StoreUserData(User user)
        {
            List<string> roles = new List<string>();
            if (!string.IsNullOrEmpty(user.Roles))
            {
                roles = user.Roles.Split(',').OfType<string>().ToList();
            }    
            var userData = new UserData
            {
                DisplayName = user.DisplayName,
                FullName = user.Fullname,
                Roles = roles,
                IsAdminUser = user.IsAdminUser
            };
            return userData;
        }
        #endregion private menthod
    }
}