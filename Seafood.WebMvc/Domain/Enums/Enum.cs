using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum HaNoiDistrictEnum
    {
        [Description("Thanh Xuân")]
        THANHXUAN = 0,
        [Description("Thanh Trì")]
        THANHTRI = 1,
    }
    public enum ThanhHoaDistrictEnum
    {
        [Description("Thành phố Thanh Hóa")]
        THANHPHO = 0,
        [Description("Hoằng Hóa")]
        HOANGHOA = 1,
    }

    public enum TypeAddressEnum
    {
        [Description("Nhà riêng/Chung cư")]
        NhaRieng = 0,
        [Description("Cơ quan/Công ty")]
        CoQuan = 1,
    }
}
