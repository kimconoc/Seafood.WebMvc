using Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ResponseModel
{
    public class Product : ProductBase
    {
        public string DescPromotion { get; set; }
        public string Favourite { get; set; }
        public string FavouriteId
        {
            get
            {
                return Id.ToString() + "_Favourite";
            }
        }
    }
}
