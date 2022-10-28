using Ishopping.Domain.ApplicationClass;
using System;
using System.Globalization;

namespace Ishopping.MVC.ViewModels.User
{
    public class UserRegisterProfileViewModel
    {

        CultureInfo culture = new CultureInfo("en-US");
    

        // ******** Identificação       
        public int SiteNumber { get; set; }                     // identificação única
        public string SiteName { get; set; }

        // Config
        public string Controller { get; set; }                  // Controler das views 


        // ******* Layout
        public int Group { get; set; }
        public int TemplateCod { get; set; }
        public int ViewStart { get; set; }                   // ViewCod, página inicial do usuário, somente tipo home

        // ****** Serialize
        public bool Serialize { get; set; }


        // ******* Application Menu
        public string AppMenu { get; set; }                  // Usado para configurar o menu da aplicação 


        // ********  Usado para buscas            
        public string Semantica1 { get; set; }
        public string Semantica2 { get; set; }
        public string Semantica3 { get; set; }
        public string Semantica4 { get; set; }


        // ********  Dados da empresa
        public string Empresa { get; set; }
        public string Cnpj { get; set; }


        // **********   Endereço         
        public string Rua { get; set; }
        public string NumRua { get; set; }
        public string Distrito { get; set; }    
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Pais { get; set; }
        public string Telefone { get; set; }
        public string Telefone2 { get; set; }
        public string WhatsApp { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Message { get; set; }

        public bool GoogleMaps { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LatitudeA { get { return Latitude.ToString().Replace(",", "."); } set { Latitude = double.Parse(value, culture); } }
        public string LongitudeA { get { return Longitude.ToString().Replace(",", "."); } set { Longitude = double.Parse(value, culture); } }


        // ********* Comuns
        public string GoogleFonts { get; private set; }

        public string Adress{
            get{return Rua + " nº " + NumRua + ", " + Cidade + " " + Estado;}
        }

        public string StreetAdress
        {
            get { return Rua + " nº " + NumRua; }
        }

        public string CityAdress
        {
            get { return Cidade + " " + Estado; }
        }

        public string Phone{
            get{return Telefone + ", " + Telefone2;}
        }

        public GroupPlan GroupPlan { get; set; }
       
    }
}
