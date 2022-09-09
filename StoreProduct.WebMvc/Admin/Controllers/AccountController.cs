using Admin.Common.Model;
using Admin.CustomAuthen;
using Admin.Models;
using Domain.Models.User;
using Newtonsoft.Json;
using Service;
using System;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Admin.Controllers
{
    public class AccountController : Controller
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
            string url = "api/Account/Login";
            dynamic body = new
            {
                Username = "ducpv13",
                Password = "ad"
            };
            Provider.GetAsync(url, body);
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
    }
}