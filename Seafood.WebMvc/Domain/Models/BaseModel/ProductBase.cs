using Domain.Constant;
using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BaseModel
{
    public class ProductBase : VBaseModel
    {
        public string CategoryCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? ReviewProd { get; set; }
        public double? Price { get; set; }
        public double? PriceSale { get; set; }
        public double? Amount { get; set; }
        public string Note { get; set; }
        public string Discount
        {
            get
            {
                return CalculateDiscount(Price, PriceSale);
            }
        }

        protected string CalculateDiscount(double? Price, double? PriceSale)
        {
            if (PriceSale == null || Price == null || PriceSale == 0 || PriceSale >= Price)
            {
                return "Hàng mới";
            }
            else
            {
                var conut = string.Format("{0:N2}", Decimal.Divide((Decimal)PriceSale, (Decimal)Price));
                int discount = (int)((1 - double.Parse(conut)) * 100);
                return string.Format($"Giảm giá {discount} %");
            }
        }
    }
}
