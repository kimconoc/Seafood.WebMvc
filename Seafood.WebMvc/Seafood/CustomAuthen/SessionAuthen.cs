using Seafood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seafood.CustomAuthen
{
    public class SessionAuthen: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool isAuthroized = base.AuthorizeCore(httpContext);
            if (!isAuthroized)
                return false;

            return IsTokenValid(httpContext);
        }

        private bool IsTokenValid(HttpContextBase httpContext)
        {
            UserData user = null;
            try
            {
                user = Seafood.MemCached.Authenticator.CurrentUser(httpContext);
                if(user != null)
                {
                    return true;
                }    
            }
            catch
            {

            }
            return false;
        }
    }
}