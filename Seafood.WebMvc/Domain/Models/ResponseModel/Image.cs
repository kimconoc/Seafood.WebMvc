using Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ResponseModel
{
    public class Image : VBaseModel
    {
        public Guid? ProductId { get; set; }
        public Guid? ShopSeefoodId { get; set; }
        public Guid? MoreImgId { get; set; }
        public string UrlPath { get; set; }
        public string Base64Str { get; set; }
        public bool IsImageMain { get; set; }
    }
}
