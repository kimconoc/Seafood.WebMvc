using Domain.Constant;
using Domain.Models.ResponseModel;
using Service.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class GetInfoUserAndAuthen
    {
        private IProvider provider = new Provider();
        public bool AuthenticateRequest()
        {
            StaticSettings.ExecutedAuthen = true;
            var result = provider.GetAsync<User>(ApiUri.POST_AccountIsAuthori);
            if (result == null || result.Result == null || result.Result.Data == null)
            {
                return false;
            }
            StaticSettings.User = result.Result.Data;
            return true;
        }
    }
}
