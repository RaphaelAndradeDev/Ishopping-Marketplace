using System;
using System.Configuration;

namespace Ishopping.Application.Constants
{
    public class Price
    {           
        public decimal Template ( int type )
        {
            decimal price;
            string value;
            switch (type)
            {
                case 1:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasic"];
                    break;
                case 2:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasicPro"];
                    break;
                case 3:
                    value = ConfigurationManager.AppSettings["TemplateTypeProfessional"];
                    break;
                case 4:
                    value = ConfigurationManager.AppSettings["TemplateTypePremium"];
                    break;
                default:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasic"];
                    break;
            }
            if (Decimal.TryParse(value, out price))
                return price;
            else
                return 0;
        }

        public decimal Exhibition(int type)
        {
            decimal price;
            string value;
            switch (type)
            {
                case 1:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasic"];
                    break;
                case 2:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasicPro"];
                    break;
                case 3:
                    value = ConfigurationManager.AppSettings["TemplateTypeProfessional"];
                    break;
                case 4:
                    value = ConfigurationManager.AppSettings["TemplateTypePremium"];
                    break;
                default:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasic"];
                    break;
            }
            if (Decimal.TryParse(value, out price))
                return price;
            else
                return 0;
        }

        public decimal Gallery(int type)
        {
            decimal price;
            string value;
            switch (type)
            {
                case 1:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasic"];
                    break;
                case 2:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasicPro"];
                    break;
                case 3:
                    value = ConfigurationManager.AppSettings["TemplateTypeProfessional"];
                    break;
                case 4:
                    value = ConfigurationManager.AppSettings["TemplateTypePremium"];
                    break;
                default:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasic"];
                    break;
            }
            if (Decimal.TryParse(value, out price))
                return price;
            else
                return 0;
        }

        public decimal Products(int type)
        {
            decimal price;
            string value;
            switch (type)
            {
                case 1:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasic"];
                    break;
                case 2:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasicPro"];
                    break;
                case 3:
                    value = ConfigurationManager.AppSettings["TemplateTypeProfessional"];
                    break;
                case 4:
                    value = ConfigurationManager.AppSettings["TemplateTypePremium"];
                    break;
                default:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasic"];
                    break;
            }
            if (Decimal.TryParse(value, out price))
                return price;
            else
                return 0;
        }

        public decimal DataBase(int type)
        {
            decimal price;
            string value;
            switch (type)
            {
                case 1:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasic"];
                    break;
                case 2:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasicPro"];
                    break;
                case 3:
                    value = ConfigurationManager.AppSettings["TemplateTypeProfessional"];
                    break;
                case 4:
                    value = ConfigurationManager.AppSettings["TemplateTypePremium"];
                    break;
                default:
                    value = ConfigurationManager.AppSettings["TemplateTypeBasic"];
                    break;
            }
            if (Decimal.TryParse(value, out price))
                return price;
            else
                return 0;
        }
    }
}