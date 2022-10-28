using System.Configuration;

namespace Ishopping.Application.Constants
{
    public static class ConstantSlider
    {
        public static string SliderType(int type)
        {      
            string value;
            switch (type)
            {
                case 1:
                    value = ConfigurationManager.AppSettings["SliderTypeButton"];
                    break;
                case 2:
                    value = ConfigurationManager.AppSettings["SliderTypeText"];
                    break;
                case 3:
                    value = ConfigurationManager.AppSettings["SliderTypeVideo"];
                    break;
                case 4:
                    value = ConfigurationManager.AppSettings["SliderTypeImage"];
                    break;
                default:
                    value = ConfigurationManager.AppSettings["SliderTypeDefault"];
                    break;
            }     
            return value;           
        }
    }
}