using Domain.Models.ResponseModel;
using Newtonsoft.Json;
using Seafood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Seafood.MemCached
{
    public class Authenticator
    {
        public static string GetSigninToken()
        {
            return FormsAuthentication.FormsCookieName;
        }
        public static void SetAuth(User loginUser, HttpContextBase _curentHttpContext)
        {
            try
            {
                var user = new UserData
                {
                    UserId = loginUser.Id,
                    DisplayName = loginUser.DisplayName,
                    Avarta = loginUser.Avarta,
                    Birthday = loginUser.Birthday,
                    Sex = loginUser.Sex,
                    Mobile = loginUser.Mobile,
                    Email = loginUser.Email,
                };
                var loginToken = new FormsAuthenticationTicket(1, GetSigninToken(), DateTime.Now,DateTime.Now.AddMinutes(1), FormsAuthentication.SlidingExpiration, JsonConvert.SerializeObject(user), FormsAuthentication.FormsCookiePath);
                SetAuthCookie(_curentHttpContext, loginToken, GetSigninToken());

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private static void SetAuthCookie(HttpContextBase httpContext, FormsAuthenticationTicket authenticationTicket, string cookieName)
        {
            var encryptedTicket = FormsAuthentication.Encrypt(authenticationTicket);
            var cookie = new HttpCookie(cookieName, encryptedTicket);
            httpContext.Response.Cookies.Remove(cookie.Name);
            httpContext.Response.Cookies.Add(cookie);
        }
        public static UserData CurrentUser(HttpContextBase _curentHttpContext)
        {
            UserData user = null;
            var signinTokenCookie = _curentHttpContext.Request.Cookies[GetSigninToken()];
            if (signinTokenCookie != null && !string.IsNullOrEmpty(signinTokenCookie.Value))
            {
                try
                {
                    var token = FormsAuthentication.Decrypt(signinTokenCookie.Value);
                    user = JsonConvert.DeserializeObject<UserData>(token.UserData);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return user;
        }
        public static void LogOff(HttpContextBase httpContext)
        {
            var cookie = new HttpCookie(GetSigninToken());
            DateTime nowDateTime = DateTime.Now;
            cookie.Expires = nowDateTime.AddDays(-1);
            httpContext.Response.Cookies.Add(cookie);
            // Put user code to initialize the page here            
            FormsAuthentication.SignOut();
            HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            HttpContext.Current.Session.Abandon();
        }
    }
}