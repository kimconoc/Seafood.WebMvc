using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public class Helper
    {
        public static string FomatToTypeMoney(double? Price)
        {
            var strPrice = Price.ToString();
            var result = string.Empty;
            if (strPrice.Length == 4)
            {
                result = strPrice.Substring(0, 1) + "." + strPrice.Substring(1);
            }
            else if (strPrice.Length == 5)
            {
                result = strPrice.Substring(0, 2) + "." + strPrice.Substring(2);
            }
            else if (strPrice.Length == 6)
            {
                result = strPrice.Substring(0, 3) + "." + strPrice.Substring(3);
            }
            else if (strPrice.Length == 7)
            {
                result = strPrice.Substring(0, 1) + "." + strPrice.Substring(1, 4) + "." + strPrice.Substring(4);
            }
            else if (strPrice.Length == 8)
            {
                result = strPrice.Substring(0, 2) + "." + strPrice.Substring(2, 5) + "." + strPrice.Substring(5);
            }
            else if (strPrice.Length == 9)
            {
                result = strPrice.Substring(0, 3) + "." + strPrice.Substring(3, 6) + "." + strPrice.Substring(6);
            }
            return result + " đ";
        }
        public static bool ValidPhoneNumer(string phoneNumber, string lengthAndPrefixPhoneNumber = "10-09,086,088,089,020,032,033,034,035,036,037,038,039,070,079,077,076,078,083,084,085,081,082,056,058,059")
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return false;
            // Chuẩn hóa số điện thoại
            phoneNumber = phoneNumber.Replace("+", string.Empty);
            if (phoneNumber.StartsWith("84"))
                phoneNumber = "0" + phoneNumber.Substring(2, phoneNumber.Length - 2);

            Regex rx = new Regex("^[0-9]+$");

            // Nhập chưa ký tự
            if (!rx.IsMatch(phoneNumber))
            {
                return false;
            }

            //Chỉ lấy lại kí tự số
            phoneNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

            // Nhập linh tinh là biến
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            //Danh sach do dai sdt va dau so tuong ung
            var lstlengthAndPrefixNumberStr = lengthAndPrefixPhoneNumber.Split(';');

            var lstValid = lstlengthAndPrefixNumberStr.Select(item => item.Split('-')).
                ToDictionary(lf => int.Parse(lf[0]), lf => lf[1].Split(',').ToList());

            //So dien thoai co do dai tuong ung va dau so tuong ung voi do dai
            if (lstValid.Where(valid => phoneNumber.Length == valid.Key).
                Any(valid => valid.Value.Any(pre => phoneNumber.IndexOf(pre, StringComparison.Ordinal) == 0)))
            {
                return true;
            }

            return false;
        }
    }
}
