﻿using Domain.Constant;
using Domain.Models.ResponseModel;
using System;
using System.Collections.Generic;
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
            var user = GetCurrentUser();
            var uri = ApiUri.Get_GetUserById + string.Format($"?userId={user.UserId}");
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
    }
}