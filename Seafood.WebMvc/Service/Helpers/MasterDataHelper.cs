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
    public class MasterDataHelper
    {
        private IProvider provider = new Provider();
        public List<ShopSeafood> GetInfoShopSeeFood(string region = "")
        {
            var uri = ApiUri.Get_GetInfoShopSeeFood + string.Format($"?region={region}");

            var shopSeafood = provider.GetAsync<List<ShopSeafood>>(uri);
            if (shopSeafood == null || shopSeafood.Result == null || shopSeafood.Result.Data == null)
            {
                return null;
            }

            return shopSeafood.Result.Data;
        }
    }
}
