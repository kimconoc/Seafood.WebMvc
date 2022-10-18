using Domain.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constant
{
    public class StaticSettings
    {
        public static User User { get; set; }
        public static bool ExecutedAuthen { get; set; }
        public static void ClearStaticSettings()
        {
            User = null;
            ExecutedAuthen = false;
        }
    }
}
