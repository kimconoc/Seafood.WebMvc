using Domain.Constant;
using Domain.Helpers;
using Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ResponseModel
{
    public class ProdDetailt : ProductBase
    {
        public string Icon { get; set; }
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
        public string StrPrice
        {
            get
            {
                return Helper.FomatToTypeMoney(Price);
            }
        }
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
