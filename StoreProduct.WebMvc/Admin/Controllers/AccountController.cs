using Admin.Model;
using Domain.Constant;
using Domain.Models.ParameterModel;
using Domain.Models.ResponseModel;
using Newtonsoft.Json;
using Service.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Admin.Controllers
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
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Login", "Account");
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
                        Message = "Thông tin nhập không đúng"
                    };
                    return Json(data);
                }
                return Json(false);
            }   
            catch
            {
                return Json(false);
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