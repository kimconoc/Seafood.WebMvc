using Domain.Constant;
using Service.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public class GetInfoLogin
    {
        private IProvider provider = new Provider();
        public dynamic AuthenticateRequest()
        {
            var result = provider.GetAsync<dynamic>(ApiUri.POST_AccountIsAuthori);
            if (result == null || result.Result == null || result.Result.Data == null)
            {
                return null;
            }
            return result.Result.Data;
        }
    }
}
