using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionCore
{
    public static class ValueTypeConverter
    {
        public static int ToTryInt(this object data)
        {
            if (data == null) return default;
            else return int.TryParse(data.ToString(), out int result) ? result : default;
        }
        public static int? ToInt(this object data)
        {
            if (data == null) return default;
            else return int.TryParse(data.ToString(), out int result) ? result : default;
        }
        public static DateTime ToTryDateTime(this object data)
        {
            if (data == null) return default;
            else return DateTime.TryParse(data.ToString(), out DateTime result) ? result : default;

        }
        public static DateTime? ToDateTime(this object data)
        {
            if (data == null) return default;
            else return DateTime.TryParse(data.ToString(), out DateTime result) ? result : default;
        }
        public static double? ToDouble(this object data)
        {
            if (data == null) return default;
            else return double.TryParse(data.ToString(), out double result) ? result : default;
        }
        public static double ToTryDouble(this object data)
        {
            if (data == null) return default;
            else return double.TryParse(data.ToString(), out double result) ? result : default;
        }
        public static decimal? ToDecimal(this object data)
        {
            if (data == null) return default;
            else return decimal.TryParse(data.ToString(), out decimal result) ? result : default;
        }
        public static decimal ToTryDecimal(this object data)
        {
            if (data == null) return default;
            else return decimal.TryParse(data.ToString(), out decimal result) ? result : default;
        }
        public static bool? ToBool(this object data)
        {
            if (data == null) return default;
            else return bool.TryParse(data.ToString(), out bool result) ? result : default;
        }
        public static bool ToTryBool(this object data)
        {
            if (data == null) return default;
            else return bool.TryParse(data.ToString(), out bool result) ? result : default;
        }
    }
}
