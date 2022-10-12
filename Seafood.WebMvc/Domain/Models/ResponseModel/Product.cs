using Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ResponseModel
{
    public class Product : VBaseModel
    {
        public string CategoryCode { get; set; }
        public string RegionCode { get; set; }
        public string Name { get; set; }
        public string DescPromotion { get; set; }
        public string Description { get; set; }
        public string FavouriteId
        {
            get
            {
                return Id.ToString() + "_Favourite";
            }
        }
        public string Favourite { get; set; }
        public double? ReviewProd { get; set; }
        public double? Price { get; set; }
        public string StrPrice 
        {
            get
            {
                if (Price != null)
                {
                    return FomatToTypeMoney(Price);
                }
                return string.Empty;
            }
        }
        public double? PriceSale { get; set; }
        public string StrPriceSale
        {
            get
            {
                if (PriceSale != null)
                {
                    return FomatToTypeMoney(PriceSale);
                }
                return string.Empty;
            }
        }
        public string Discount
        {
            get
            {
                if (PriceSale == null || PriceSale == 0 || PriceSale >= Price)
                {
                    return "Hàng mới";
                }
                else
                {
                    var conut = string.Format("{0:N2}",Decimal.Divide((Decimal)PriceSale, (Decimal)Price));
                    int discount = (int)((1 - double.Parse(conut)) * 100);
                    return string.Format($"Giảm giá {discount} %");
                }
            }
        }
        public double? Amount { get; set; }
        public string Note { get; set; }
        private string FomatToTypeMoney(double? Price)
        {
            var strPrice = Price.ToString();
            var result = string.Empty;
            if (strPrice.Length == 4)
            {
                result = strPrice.Substring(0, 1) + "." + strPrice.Substring(1);
            }
            else if (strPrice.Length == 5)
            {
                result = strPrice.Substring(0, 2) + "." + strPrice.Substring(2);
            }
            else if (strPrice.Length == 6)
            {
                result = strPrice.Substring(0, 3) + "." + strPrice.Substring(3);
            }
            else if (strPrice.Length == 7)
            {
                result = strPrice.Substring(0, 1) + "." + strPrice.Substring(1, 3) + "." + strPrice.Substring(4);
            }
            else if (strPrice.Length == 8)
            {
                result = strPrice.Substring(0, 2) + "." + strPrice.Substring(2, 3) + "." + strPrice.Substring(5);
            }
            return result;
        }
    }
}
