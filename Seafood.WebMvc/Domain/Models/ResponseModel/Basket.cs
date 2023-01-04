using Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ResponseModel
{
    public class Basket : VBaseModel
    {
        public string Imge { get; set; }
        public string ProductName { get; set; }
        public Guid ProductId { get; set; }
        public string ProductDescription { get; set; }
        public Guid ProdProcessingId { get; set; }
        public string ProdProcessingName { get; set; }
        public int Price { get; set; }
        public int PriceSale { get; set; }
    }
}
