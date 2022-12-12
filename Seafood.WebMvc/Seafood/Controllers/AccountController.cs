using Domain.Constant;
using Domain.FileLog;
using Domain.Helpers;
using Domain.Models.ParameterModel;
using Domain.Models.ResponseModel;
using Seafood.MemCached;
using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Seafood.Controllers
{
    public class AccountController : BaseController
    {
        #region Login
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
        #endregion Login

        #region LoginBySMS
        public ActionResult LoginBySMS()
        {
            return View();
        }
        #endregion LoginBySMS

        #region ForgotPasswordFirebase
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckCodeFirebase(string number)
        {
            if (string.IsNullOrEmpty(number) || !Helper.ValidPhoneNumer(number))
            {
                return Json(Bad_Request("Số điện thoại không hợp lệ"));
            }
            var uri = ApiUri.Get_CheckCodeFirebase + string.Format($"?number={number}");
            var firebase = provider.GetAsync<bool>(uri);
            if (firebase == null || firebase.Result == null || !firebase.Result.Success)
            {
                return View(Server_Error());
            }
            return Json(Success_Request(firebase.Result.Data));
        }

        [HttpPost]
        public ActionResult UpdateCodeFirebase(string number, string code = "")
        {
            if (string.IsNullOrEmpty(number) || !Helper.ValidPhoneNumer(number))
            {
                return Json(Bad_Request("Số điện thoại không hợp lệ"));
            }
            var uri = ApiUri.Get_UpdateCodeFirebase + string.Format($"?number={number}&code={code}");
            var update = provider.GetAsync<bool>(uri);
            if (update == null || update.Result == null || !update.Result.Success)
            {
                return View(Server_Error());
            }
            return Json(Success_Request(update.Result.Data));
        }

        [HttpPost]
        public ActionResult ChangePwByCodeFirebase(string number, string code, string newPassword)
        {
            if (string.IsNullOrEmpty(number) || !Helper.ValidPhoneNumer(number) || string.IsNullOrEmpty(code) || string.IsNullOrEmpty(newPassword))
            {
                return Json(Bad_Request());
            }
            var uri = ApiUri.Get_ChangePwByCodeFirebase + string.Format($"?number={number}&code={code}&newPassword={newPassword}");
            var userBase = provider.GetAsync<User>(uri);
            if (userBase == null || userBase.Result == null || !userBase.Result.Success)
            {
                return View(Server_Error());
            }
            Authenticator.SetAuth(userBase.Result.Data, HttpContext);
            return Json(Success_Request(userBase.Result.Data));
        }
        #endregion ForgotPassword

        #region Logout
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
        #endregion Logout

        #region CreateAccount
        public ActionResult RegisterAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAccount(string numberPhone, string password)
        {
            try
            {
                if (!Helper.ValidPhoneNumer(numberPhone) || string.IsNullOrEmpty(password) )
                {
                    return Json(Bad_Request("Thông tin không hợp lệ"));
                }
               
                dynamic model = new
                {
                    NumberPhone = numberPhone,
                    Password = password,
                };
                var isCreate = provider.PostAsync<bool>(ApiUri.POST_AccountCreate, model).Result;
                if (!isCreate.Data)
                {
                    return Json(Bad_Request("Đăng ký thất bại"));
                }
                return Json(Success_Request(isCreate.Data));
            }
            catch (Exception ex)
            {
                FileHelper.GeneratorFileByDay(ex.ToString(), MethodBase.GetCurrentMethod().Name);
                return View(Server_Error());
            }
        }
        #endregion CreateAccount

        #region private menthod
        [HttpPost]
        public ActionResult CheckUserByPhoneNumber(string number)
        {
            if (string.IsNullOrEmpty(number) || !Helper.ValidPhoneNumer(number))
            {
                return Json(Bad_Request("Số điện thoại không hợp lệ"));
            }
            var uri = ApiUri.Get_CheckUserByPhoneNumber + string.Format($"?number={number}");
            var data = provider.GetAsync<string>(uri);
            if (data == null || data.Result == null || !data.Result.Success)
            {
                return View(Server_Error());
            }
            return Json(Success_Request(data.Result.Data?.Trim()));
        }
        #endregion private menthod
    }
}