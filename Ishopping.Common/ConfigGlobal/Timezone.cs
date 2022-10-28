using System;
using System.Configuration;

namespace Ishopping.Common.ConfigGlobal
{
    public static class Timezone
    {        
        public static DateTime DateTimeNow()
        {       
            DateTime serverTime = DateTime.Now;
            string timezone = ConfigurationManager.AppSettings["timezone"];
            DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, timezone);
            return _localTime;
        }

        public static DateTime DateTimeNow(DateTime dateTime)
        {
            // Converte um time vindo do server. ex: dateTime = 12:00 >>  serverTime = dateTime - 6 horas; então retornará 18:00 no banco
            string timezone = ConfigurationManager.AppSettings["timezone"];
            DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, TimeZoneInfo.Local.Id, timezone);
            return _localTime;
        }

        public static DateTime ThisDateTime(DateTime dateTime)
        {
            // Converte um time para ser gravado no server. ex: dateTime = 18:00 >>  serverTime = dateTime - 6 horas; então será gravado 12:00 no banco
            string timezone = ConfigurationManager.AppSettings["timezone"];
            DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, timezone, TimeZoneInfo.Local.Id);               
            return _localTime;
        }
    }    
}
