using Admin.Models.ParameterModel;
using Domain.Models.ResponseModel;
using Service.ServiceProvider;
using System;
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
            string url = "api/Account/Login";
            dynamic body = new
            {
                Username = "ducpv13",
                Password = "ad1234567"
            };
            
            var test = provider.PostAsync<User>(url, body).Result;
            var name = test;
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