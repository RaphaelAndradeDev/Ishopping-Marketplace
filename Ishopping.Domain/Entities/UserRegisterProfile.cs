using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Ishopping.Domain.Entities
{
    public class UserRegisterProfile
    {
        // Bloqueio      
        public bool HasInsufficientValue { get; private set; }
        public bool HasRestriction { get; private set; }
        public bool IsTimeOver { get; private set; }


        // ******** Identificação
        public Guid Id { get; private set; }
        public string IdUser { get; private set; }
        public int SiteNumber { get; private set; }                     // identificação única
        public string SiteName { get; private set; }
       
        // Config
        public string Controller { get; private set; }                  // Controler das views 

        // ******* Plan
        public int Plan { get; private set; }                           // AdminFinancialPlan.Cod
   
        // ******* Layout
        public int TemplateCod { get; private set; }
        public int ViewStart { get; private set; }                   // ViewCod, página inicial do usuário, somente tipo home

        // ****** Serialize
        public bool Serialize { get; private set; }


        // ******* Application Menu
        public string AppMenu { get; private set; }                  // Usado para configurar o menu da aplicação 
              

        // ********  Dados da empresa
        public string Empresa { get; private set; }
        public string Cnpj { get; private set; }


        // **********   Endereço         
        public string Rua { get; private set; }
        public string NumRua { get; private set; }
        public string Distrito { get; private set; }      
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }
        public string Pais { get; private set; }
        public string Telefone { get; private set; }
        public string Telefone2 { get; private set; }
        public string WhatsApp { get; private set; }
        public string Skype { get; private set; }                       // Ainda não usado
        public string Email { get; private set; }
        public string Website { get; private set; }


        // ********  Usado para buscas            
        public string Semantica1 { get; private set; }
        public string Semantica2 { get; private set; }
        public string Semantica3 { get; private set; }
        public string Semantica4 { get; private set; }
        
        // ********* Geolocalização
        public bool GoogleMaps { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }   

        // ********* Comuns
        public string GoogleFonts { get; private set; }

        // ***** Quantidade por serviços      
        public int EmailQuantity { get; private set; }

        // **** Descrição sobre a pagina do usuario
        public string Message { get; private set; }


        // Ctor
        protected UserRegisterProfile() { }

        public UserRegisterProfile(string userId, bool ativo, int templateCod, int viewStart, int siteNumber, bool googleMaps, double latitude, double longitude,
            string siteName, string semantica1, string rua, string numero, string distrito, string cidade, string estado, string telefone,
            string semantica2 = "", string semantica3 = "", string semantica4 = "", string empresa = "", string cnpj = "",
            string cep = "", string pais = "Brasil", string telefone2 = "", string whatsApp = "", string email = "", string webSite = "", string message = ""
            )
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(templateCod, viewStart, latitude, longitude, siteName, semantica1, rua, numero, distrito, cidade, estado, telefone, 
                semantica2, semantica3, semantica4, empresa, cnpj, whatsApp, cep, pais, telefone2, email, webSite, message);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.HasInsufficientValue = ativo;
            this.TemplateCod = templateCod;
            this.ViewStart = viewStart;
            this.AppMenu = "naoconfigurado";
            this.GoogleMaps = googleMaps;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.SiteName = siteName;
            this.Semantica1 = semantica1;
            this.Rua = rua;
            this.NumRua = numero;
            this.Distrito = distrito;
            this.Cidade = cidade;
            this.Estado = estado;
            this.Telefone = telefone;

            // não obrigatorio
            this.Semantica2 = semantica2;
            this.Semantica3 = semantica3;
            this.Semantica4 = semantica4;    
            this.Empresa = empresa;
            this.Cnpj = cnpj;         
            this.WhatsApp = whatsApp;
            this.CEP = cep; 
            this.Pais = pais;
            this.Telefone2 = telefone2;
            this.Email = email;
            this.Website = webSite;
            this.Message = message;
        }

        // Methods
        public void Chage(
            string siteName, string semantica1, string semantica2, string semantica3, string semantica4, string rua, string numero,
            string distrito, string cidade, string estado, string cep, string telefone, string telefone2, string whatsApp, string empresa, 
            string cnpj, string email, string webSite, double latitude, double longitude, string pais = "Brasil", string message = "")
        {
            Validate(latitude, longitude, siteName, semantica1, rua, numero, distrito, cidade, estado, telefone,
               semantica2, semantica3, semantica4, empresa, cnpj, whatsApp, cep, pais, telefone2, email, webSite, message);
                                         
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.SiteName = siteName;
            this.Semantica1 = semantica1;
            this.Rua = rua;
            this.NumRua = numero;
            this.Distrito = distrito;
            this.Cidade = cidade;
            this.Estado = estado;
            this.Telefone = telefone;

            // não obrigatorio
            this.Semantica2 = semantica2;
            this.Semantica3 = semantica3;
            this.Semantica4 = semantica4;     
            this.Empresa = empresa;
            this.Cnpj = cnpj;
            this.WhatsApp = whatsApp;
            this.CEP = cep; 
            this.Pais = pais;
            this.Telefone2 = telefone2;
            this.Email = email;
            this.Website = webSite;
            this.Message = message;
        }

        public void ChangeAppMenu(string appMenu)
        {
            this.AppMenu = appMenu;
        }

        public void ChangePlan(int plan)
        {
            ValidatePlan(plan);
            this.Plan = plan;
        }

        public void ChangeLayout(int templateCod, int viewStart)
        {
            this.TemplateCod = templateCod;
            this.ViewStart = viewStart;
        }        

        public void SetBlockForInsufficientValue(bool hasInsufficientValue)
        {
            this.HasInsufficientValue = hasInsufficientValue;
        }

        public void SetBlockForHasRestriction(bool hasRestriction)
        {
            this.HasRestriction = hasRestriction;
        }

        public void SetIsTimeOver(bool isTimeOver)
        {
            this.IsTimeOver = isTimeOver;
        }

        public bool IsBlock()
        {
            return this.HasInsufficientValue || this.HasRestriction || this.IsTimeOver;
        }

        public void SetController(string controller)
        {
            this.Controller = controller;
        }

        public void SetSerialize(bool serialize)
        {
            this.Serialize = serialize;
        }

        public void WriteMessage(string message)
        {
            this.Message = message;
        }

        public bool ExistItem(string item)
        {
            if (string.IsNullOrEmpty(item))
                return false;

            else if (item == "ever")
                return true;

            var itens = this.AppMenu.Split(',');
            return itens.Any(x => x == item);
        }

        public void SetGoogleFonts(string googleFonts)
        {
            this.GoogleFonts = googleFonts;
        }        

        // validate
        public void ValidateAppMenu(string appMenu)
        {
            AssertionConcern.AssertArgumentNotNull(appMenu, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(appMenu, 1024, Errors.MaxLength);
        }

        public void ValidateLayout(int templateCod, int viewStart)
        {
            AssertionConcern.AssertArgumentRange(templateCod, 1111, 9999, Errors.InvalidNumber);
            AssertionConcern.AssertArgumentRange(viewStart, 1111, 9999, Errors.InvalidNumber);
        }

        public void ValidatePlan(int plan)
        {
            AssertionConcern.AssertArgumentRange(plan, 111, 999, Errors.InvalidNumber);
        }

        private void Validate(double latitude, double longitude,
            string siteName, string semantica1, string rua, string numero, string distrito, string cidade, string estado, string telefone,
            string semantica2, string semantica3, string semantica4, string empresa, string cnpj,
            string whatsApp, string cep, string pais, string telefone2, string email, string webSite, string message)
        {                      
            
            AssertionConcern.AssertArgumentRange(latitude, -99.9999999, 99.9999999, Errors.InvalidNumber);
            AssertionConcern.AssertArgumentRange(longitude, -99.9999999, 99.9999999, Errors.InvalidNumber);
            
            AssertionConcern.AssertArgumentNotNull(siteName, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(siteName, 24, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(semantica1, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(semantica1, 24, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(rua, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(rua, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(numero, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(numero, 5, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(distrito, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(distrito, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(cidade, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(cidade, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(estado, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(estado, 2, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(telefone, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(telefone, 16, Errors.MaxLength);

            // não obrigatorio
            AssertionConcern.AssertArgumentLength(semantica2, 24, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(semantica3, 24, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(semantica4, 24, Errors.MaxLength);         
            AssertionConcern.AssertArgumentLength(empresa, 32, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(cnpj, 18, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(whatsApp, 16, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(cep, 9, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(pais, 20, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(telefone2, 16, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(email, 64, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(webSite, 128, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(message, 150, Errors.MaxLength);
        }

        private void Validate(int templateCod, int viewStart, double latitude, double longitude,
            string siteName, string semantica1, string rua, string numero, string distrito, string cidade, string estado, string telefone,
            string semantica2, string semantica3, string semantica4, string empresa, string cnpj,
            string WhatsApp, string cep, string pais, string telefone2, string email, string webSite, string message)
        {
            ValidateLayout(templateCod, viewStart);
            Validate(latitude, longitude, siteName, semantica1, rua, numero, distrito, cidade, estado, telefone,
               semantica2, semantica3, semantica4, empresa, cnpj, WhatsApp, cep, pais, telefone2, email, webSite, message);
        }
    }
}
