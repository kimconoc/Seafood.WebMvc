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

        #region YourAccount
        public ActionResult YourAccount(string idItem)
        {
            ViewBag.IdItem = idItem;
            return View();
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
            if (imgUpload.FileName.ToLower().Contains(".jpg") || imgUpload.FileName.ToLower().Contains(".png")
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
        #endregion YourAccount

        #region LoginBySMS
        public ActionResult LoginBySMS()
        {
            return View();
        }
        #endregion LoginBySMS

        #region ForgotPassword
        public ActionResult ForgotPassword()
        {
            return View();
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
                if (!isCreate.Data)
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
            catch (Exception ex)
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
        #endregion CreateAccount

        [HttpPost]
        public ActionResult CheckUserByPhoneNumber(string number)
        {
            if(string.IsNullOrEmpty(number) || !Helper.ValidPhoneNumer(number))
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
        public ActionResult UpdateCodeFirebase(string number,string code = "")
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

        #region private menthod
        #endregion private menthod
    }
}