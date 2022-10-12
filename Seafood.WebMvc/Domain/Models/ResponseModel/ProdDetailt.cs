using Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ResponseModel
{
    public class ProdDetailt : VBaseModel
    {
        public string CategoryCode { get; set; }
        public string RegionDistrictCode { get; set; }
        public string RegionCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? ReviewProd { get; set; }
        public double? Price { get; set; }
        public double? PriceSale { get; set; }
        public double? Amount { get; set; }
        public List<Image> Images { get; set; }
        public List<ProdProcessing> ListProcessing { get; set; }
        public List<ProdPromotion> ListPromotion { get; set; }
        public List<ProdInfo> ListProdInfo { get; set; }
        public List<SeafoodPromotion> ListSeafoodPromotion { get; set; }
    }
    public class ProdProcessing : VBaseModel
    {
        public Guid? ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Note { get; set; }
    }
    public class ProdPromotion : VBaseModel
    {
        public Guid? ProductId { get; set; }
        public string Content { get; set; }
        public bool PromotionMain { get; set; }
        public string Note { get; set; }
    }
    public class ProdInfo : VBaseModel
    {
        public Guid? ProductId { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
    }
}
