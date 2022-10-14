using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extentions
{
    public static class StringExtension
    {
        /// <summary>
        /// Get description annotation of an enum value
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetDescription(this System.Enum enumValue)
        {
            Type type = enumValue.GetType();

            MemberInfo[] memberInfo = type.GetMember(enumValue.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return enumValue.ToString();
        }
    }
}
