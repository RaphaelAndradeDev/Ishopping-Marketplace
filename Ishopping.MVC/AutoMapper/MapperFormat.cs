using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ishopping.AutoMapper
{    
    public class CpfFormat : IValueFormatter
    {
        public string FormatValue(ResolutionContext context)
        {
            string str = ((string)context.SourceValue);

            if (string.IsNullOrEmpty(str))
                return str;

            return Convert.ToUInt64(str).ToString(@"000\.000\.000\-00");
        }
    }

    public class CnpjFormat : IValueFormatter
    {
        public string FormatValue(ResolutionContext context)
        {
            string str = ((string)context.SourceValue);

            if (string.IsNullOrEmpty(str))
                return str;

            return Convert.ToUInt64(str).ToString(@"00\.000\.000\/0000\-00");
        }
    }

    public class CepFormat : IValueFormatter
    {
        public string FormatValue(ResolutionContext context)
        {
            string str = ((string)context.SourceValue);

            if (string.IsNullOrEmpty(str))
                return str;

            return Convert.ToUInt64(str).ToString(@"00000\-000");
        }
    }

    public class TelFormat : IValueFormatter
    {
        public string FormatValue(ResolutionContext context)
        {
            string str = ((string)context.SourceValue);

            if (string.IsNullOrEmpty(str))
                return str;

            return PhoneNumber(str);
        }

        public static string PhoneNumber(string value)
        {          
            value = new System.Text.RegularExpressions.Regex(@"\D")
                .Replace(value, string.Empty);
            value = value.TrimStart('0');

            switch (value.Length)
            {
                case 7:
                    value = Convert.ToInt64(value).ToString("###-####");
                    break;
                case 8:
                    value = Convert.ToInt64(value).ToString("####-####");
                    break;
                case 9:
                    value = Convert.ToInt64(value).ToString("#####-####");
                    break;
                case 10:
                    value = Convert.ToInt64(value).ToString("(##) ####-####");
                    break;
                case 11:
                    value = Convert.ToInt64(value).ToString("(##) #####-####");
                    break;
                default:
                    Convert.ToInt64(value)
                    .ToString("###-###-#### " + new String('#', (value.Length - 10)));
                    break;
            }
            return value;
        }        
    }

    public class ListFormat : IValueFormatter
    {
        public string FormatValue(ResolutionContext context)
        {
            string str = ((string)context.SourceValue);

            if (string.IsNullOrEmpty(str))
                return str;

            return str.Replace(";", "</li><li>");
        }
    }
}