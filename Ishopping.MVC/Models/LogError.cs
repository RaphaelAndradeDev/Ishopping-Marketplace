using Ishopping.Common.ConfigGlobal;
using System;
using System.IO;

namespace Ishopping.Models
{
    public static class LogError
    {
        const string fileName = "LogError.txt";        

        public static void WhiteError(string path, string exception, string className, string method)
        {
            using (StreamWriter file = new StreamWriter(Path.Combine(path, fileName), true))
            {
                exception = "<h4 style='color:blue'>" + DateTime.Now + "&emsp;&emsp;" + Timezone.DateTimeNow() + "</h4>" + "<h5>" + " ClassName: " + className + " Method: " + method + "</h5><p>" + exception + "</p><hr /><br />";
                file.WriteLine(exception);
            }
        }

        public static void WhiteError(string path, string exception, string className, string method, string identity)
        {
            using (StreamWriter file = new StreamWriter(Path.Combine(path, fileName), true))
            {
                exception = "<h4 style='color:blue'>" + DateTime.Now + "&emsp;&emsp;" + Timezone.DateTimeNow() + "</h4>" + "<p>" + " ClassName: " + className + " Method: " + method + " Identity: " + identity + "</p><p>" + exception + "</p><hr /><br />";
                file.WriteLine(exception);
            }
        }

        public static void Clear(string path)
        {
            if (File.Exists(Path.Combine(path, fileName)))
            {
                File.WriteAllText(Path.Combine(path, fileName), string.Empty);
            }
        }

        public static string ReaderError(string path)
        {
            string text = string.Empty;
            if (File.Exists(Path.Combine(path, fileName)))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(Path.Combine(path, fileName)))
                    {
                        text = reader.ReadToEnd();
                    }
                    return text;
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
            }
            else
            {
                return " O arquivo " + path + " não foi localizado !";
            }
        }
    }
}