using Domain.Constant;
using Domain.Models.ResponseModel;
using Seafood.MemCached;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.Controllers.AccountManager
{
    public class YourAccountController : BaseController
    {
        #region YourAccount
        public ActionResult YourAccount(string idItem)
        {
            ViewBag.IdItem = idItem;
            var userData = GetCurrentUser();
            var uri = ApiUri.Get_GetUserById + string.Format($"?userId={userData.UserId}");
            var userDetailt = provider.GetAsync<User>(uri);
            if (userDetailt == null || userDetailt.Result == null || userDetailt.Result.Data == null)
            {
                return View(new User());
            }
            var result = userDetailt.Result.Data;
            return View(result);
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
                    var userData = GetCurrentUser();
                    string filePath = string.Empty;
                    string path = string.Format("/FileUpload/seafood/avarta-user/" + userData.UserId.ToString() + "/");
                    filePath = Server.MapPath(path);
                    if (Directory.Exists(filePath))
                    {
                        var dir = new DirectoryInfo(filePath);
                        dir.Delete(true);
                    }
                    Directory.CreateDirectory(filePath);
                    filePath = filePath + Path.GetFileName(imgUpload.FileName);
                    path = path + Path.GetFileName(imgUpload.FileName);
                    imgUpload.SaveAs(filePath);
                    var uri = ApiUri.POST_UserUpdateAvarta + string.Format($"?userId={userData.UserId}&path={path}");
                    var updated = provider.GetAsync<bool>(uri);
                    if (updated == null || updated.Result == null || updated.Result.Data == false || !updated.Result.Success)
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
        public ActionResult UploadProfileUser(string displayName, string email, int sex, int year, int month, int day)
        {
            var userData = GetCurrentUser();
            var birthday = new DateTime(year, month, day);
            User user = new User()
            {
                Id = userData.UserId,
                DisplayName = displayName,
                Mobile = userData.Mobile,
                Email = email,
                Sex = sex,
                Birthday = birthday
            };
            var uri = ApiUri.POST_UserUploadProfile;
            var updated = provider.PostAsync<User>(uri, user);
            if (updated == null || updated.Result == null || updated.Result.Data == null || !updated.Result.Success)
            {
                return Json(Server_Error());
            }
            Authenticator.SetAuth(updated.Result.Data, HttpContext);
            return Json(Success_Request());
        }
        #endregion YourAccount
    }
}