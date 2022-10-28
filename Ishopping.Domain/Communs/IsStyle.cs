using Ishopping.Common.Resources;
using Ishopping.Common.Validation;

namespace Ishopping.Domain.Communs
{
    public static class IsStyle
    {
        public static string Rename(string style, string name, string replace)
        {
            AssertionConcern.AssertArgumentNotEmpty(style, Errors.IsNull);
            AssertionConcern.AssertArgumentNotEmpty(name, Errors.IsNull);
            AssertionConcern.AssertArgumentNotEmpty(replace, Errors.IsNull); 

            return style.Replace(name, replace);            
        }

        public static string Remove(string style, string name)
        {
            AssertionConcern.AssertArgumentNotEmpty(style, Errors.IsNull);
            AssertionConcern.AssertArgumentNotEmpty(name, Errors.IsNull);
       
            string str = style.Replace(name + ",", "").Replace("," + name, "").Replace(name, "");
            if (!string.IsNullOrEmpty(str))                 
                return str;

            return "SemEstilo";                                                            
        }
    }
}
