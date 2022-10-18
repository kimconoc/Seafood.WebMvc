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
        public UserData AuthenticateRequest()
        {
            var result = provider.GetAsync<UserData>(ApiUri.POST_AccountIsAuthori);
            if (result == null || result.Result == null || result.Result.Data == null)
            {
                return null;
            }

            return result.Result.Data;
        }
    }
}
