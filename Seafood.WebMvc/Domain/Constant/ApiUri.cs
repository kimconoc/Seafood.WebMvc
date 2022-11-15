using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constant
{
    public class ApiUri
    {
        public const string POST_AccountIsAuthori = "api/Account/IsAuthori";
        public const string POST_AccountLogout = "api/Account/Logout";
        public const string POST_AccountLogin = "api/Account/Login";
        public const string POST_AccountCreate = "api/Account/Create";
        public const string POST_AccountUpdateAvarta = "api/Account/UpdateAvarta";
        public const string Get_CheckUserByPhoneNumber = "api/Account/CheckUserByPhoneNumber";
        public const string Get_CheckCodeFirebase = "api/Account/CheckCodeFirebase";
        public const string Get_UpdateCodeFirebase = "api/Account/UpdateCodeFirebase";

        public const string Get_ProductGetAllProd = "api/Product/GetAllProd";
        public const string Get_ProductGetProdByCode = "api/Product/GetProdByCode";
        public const string Get_ProductExecuteToFavourite = "api/Product/ExecuteToFavourite";
        public const string Get_GetProdDetailtById = "api/Product/GetProdDetailtById";

        #region MasterData
        public const string Get_GetInfoShopSeeFood = "api/MasterData/GetInfoShopSeeFood";
        public const string Get_GetListSeafoodPromotion = "api/MasterData/GetListSeafoodPromotion";
        public const string Get_GetListRegion = "api/MasterData/GetListRegion";
        #endregion MasterData
    }
}
