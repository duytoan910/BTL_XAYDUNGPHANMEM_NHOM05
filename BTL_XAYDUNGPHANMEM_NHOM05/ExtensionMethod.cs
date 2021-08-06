using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTL_XAYDUNGPHANMEM_NHOM05
{
    public static class ExtensionMethod
    {
        public static bool CheckPositiveNumber(this string number)
        {
            string rgs = @"^\d+$";

            return Regex.IsMatch(number, rgs);
        }

        public static bool CheckPhoneNumber(this string number)
        {
            string rgs = @"^[0-9\-\+]{9,15}$";

            return Regex.IsMatch(number, rgs);
        }
    }
}
