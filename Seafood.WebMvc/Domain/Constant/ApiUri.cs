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
        public const string Get_CheckUserByPhoneNumber = "api/Account/CheckUserByPhoneNumber";
        public const string Get_CheckCodeFirebase = "api/Account/CheckCodeFirebase";
        public const string Get_UpdateCodeFirebase = "api/Account/UpdateCodeFirebase";
        public const string Get_ChangePwByCodeFirebase = "api/Account/ChangePwByCodeFirebase";

        public const string Get_ProductGetAllProd = "api/Product/GetAllProd";
        public const string Get_ProductGetProdByCode = "api/Product/GetProdByCode";
        public const string Get_ProductExecuteToFavourite = "api/Product/ExecuteToFavourite";
        public const string Get_GetProdDetailtById = "api/Product/GetProdDetailtById";

        public const string Get_GetUserById = "api/User/GetUserById";
        public const string POST_UserUpdateAvarta = "api/User/UpdateAvarta";
        public const string POST_UserUploadProfile = "api/User/UploadProfile";

        public const string Get_GetListAddressByUserId = "api/Address/GetListAddressByUserId";
        public const string Get_GetAddressByUserId = "api/Address/GetAddressByUserId";
        public const string Post_CreateAddressByUserId = "api/Address/CreateAddressByUserId";
        public const string Post_UpdateAddressByUserId = "api/Address/UpdateAddressByUserId";
        public const string Delete_DeleteAddressById = "api/Address/DeleteAddressById";

        public const string Post_CreateOrderUserId = "api/Order/CreateOrderByUserId";

        public const string Post_AddProductToBasket = "api/Basket/AddProductToBasket";
        public const string Get_GetBasketByUserId = "api/Basket/GetBasketByUserId";
        public const string Delete_DeleteBasketById = "api/Basket/DeleteBasketById";

        public const string Get_GetVoucherByUserId = "api/Voucher/GetVoucherByUserId";

        #region MasterData
        public const string Get_GetInfoShopSeeFood = "api/MasterData/GetInfoShopSeeFood";
        public const string Get_GetListSeafoodPromotion = "api/MasterData/GetListSeafoodPromotion";
        public const string Get_GetListRegion = "api/MasterData/GetListRegion";
        public const string Get_GetListPromotionByProdId = "api/MasterData/GetListPromotionByProdId";
        public const string Get_GetCountBasketByUserId = "api/MasterData/GetCountBasketByUserId";
        #endregion MasterData
    }
}
