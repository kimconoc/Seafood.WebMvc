using Domain.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ResponseModel
{
    public class Addresse : VBaseModel
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string CodeRegion { get; set; }
        public string NameRegion { get; set; }
        public string CodeDistrict { get; set; }
        public string NameDistrict { get; set; }
        public string CodeWard { get; set; }
        public string NameWard { get; set; }
        public int TypeAddress { get; set; }
        public bool IsAddressMain { get; set; }
        public string Address { get; set; }
        public string AddressRegion { get; set; }
        public string Note { get; set; }
    }
}
