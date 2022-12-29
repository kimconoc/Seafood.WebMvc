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
        public List<ShopSeafood> GetInfoShopSeeFood(string region = "")
        {
            using (IProvider provider = new Provider())
            {
                var uri = ApiUri.Get_GetInfoShopSeeFood + string.Format($"?region={region}");

                var shopSeafood = provider.GetAsync<List<ShopSeafood>>(uri);
                if (shopSeafood == null || shopSeafood.Result == null || shopSeafood.Result.Data == null)
                {
                    return new List<ShopSeafood>();
                }

                return shopSeafood.Result.Data;
            }
            
        }

        public List<SeafoodPromotion> GetListSeafoodPromotion(string shopCode = "")
        {
            using (IProvider provider = new Provider())
            {
                var uri = ApiUri.Get_GetListSeafoodPromotion + string.Format($"?shopCode={shopCode}");

                var result = provider.GetAsync<List<SeafoodPromotion>>(uri);
                if (result == null || result.Result == null || result.Result.Data == null)
                {
                    return new List<SeafoodPromotion>();
                }
                return result.Result.Data;
            }
        }

        public List<Region> GetListRegion(string txt = "", string codeRegion = "", string codeDistrict = "")
        {
            using (IProvider provider = new Provider())
            {
                var uri = ApiUri.Get_GetListRegion + string.Format($"?txtSearch={txt}&codeRegion={codeRegion}&codeDistrict={codeDistrict}");

                var result = provider.GetAsync<List<Region>>(uri);
                if (result == null || result.Result == null || result.Result.Data == null)
                {
                    return new List<Region>();
                }
                return result.Result.Data;
            }
        }

        public int GetCountBasketByUserId(Guid userId)
        {
            int count = 0;
            if (userId == null)
                return count;
            using (IProvider provider = new Provider())
            {
                var uri = ApiUri.Get_GetCountBasketByUserId + string.Format($"?userId={userId}");
                var data = provider.GetAsync<int>(uri);
                if (data != null || data.Result != null || data.Result.Data > 0)
                {
                    count = data.Result.Data;
                }

                return count;
            }
        }
    }
}
