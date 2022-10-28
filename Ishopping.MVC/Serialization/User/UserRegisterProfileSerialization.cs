
namespace Ishopping.Mvc.Serialization.User
{
    public class UserRegisterProfileSerialization
    {
        // Ativo
        public bool Ativo { get; set; }  

        // ******** Identificação
        public int SiteNumber { get; set; }                     // identificação única        

        // Config
        public string Controller { get; set; }                  // Controler das views 
        
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
        
        public bool GoogleMaps { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
   
        public string GoogleFonts { get; set; }

        // **** Descrição sobre a pagina do usuario
        public string Message { get; set; }

        public string Adress{
            get{return Rua + " nº " + NumRua + ", " + Cidade + " " + Estado;}
        }
        public string Phone{
            get{return Telefone + ", " + Telefone2;}
        }

        public string Url { get { return this.Controller + "/index/" + this.SiteNumber.ToString(); } }

        public string _Latitude { get { return Latitude.ToString().Replace(",","."); } }
        public string _Longitude { get { return Longitude.ToString().Replace(",", "."); } }
    }
}
