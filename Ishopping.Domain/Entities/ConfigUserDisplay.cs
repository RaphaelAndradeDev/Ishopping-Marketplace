using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using System;
using System.Text.RegularExpressions;

namespace Ishopping.Domain.Entities
{
    public class ConfigUserDisplay
    {
        public Guid Id { get; private set; }
        public string IdUser { get; private set; }
        public int SiteNumber { get; private set; }
        public string Action { get; private set; }
        public string Controller { get; private set; }
        public int DisplayValue { get; private set; }
        public int DisplayCount { get; private set; }
        public bool Maintenance { get; private set; }
        public bool Blocked { get; private set; }
        public string Title { get; private set; }
        public string Message { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        // ********  Usado para busca     
        public string Street { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string SemanticFull { get; private set; }
        public string AddressFull { get; private set; }
        public string Specific { get; private set; }

        // ********  Retorno da busca   
        public string SiteName { get; private set; }


        // Relacionamentos       
        public Guid UserImageGalleryId { get; private set; }
        public virtual UserImageGallery UserImageGallery { get; private set; }

        // Ctor
        protected ConfigUserDisplay() { }

        public ConfigUserDisplay(Guid userImageGalleryId, string action, string controller, bool blocked,
            int displayValue, bool maintenance, string title, string message, UserRegisterProfile profile)
        {
            CommonValidate.Validate(profile.IdUser, profile.SiteNumber);
            Validate(action, controller, displayValue, title, message);

            this.IdUser = profile.IdUser;
            this.SiteNumber = profile.SiteNumber;
            this.UserImageGalleryId = userImageGalleryId;
            this.Action = action;
            this.Controller = controller;
            this.Blocked = blocked;
            this.DisplayCount = 0;
            this.DisplayValue = displayValue;          
            this.Maintenance = maintenance;
            this.Title = title;
            this.Message = message;
            this.Latitude = profile.Latitude;
            this.Longitude = profile.Longitude;
            this.Street = profile.Rua.ToLower();
            this.District = profile.Distrito.ToLower();
            this.City = profile.Cidade.ToLower();
            this.State = profile.Estado.ToLower();
            this.SiteName = profile.SiteName.ToLower();
            this.SemanticFull = GetSemanticFull(profile);
            this.AddressFull = GetAddressFull(profile);            
            this.Specific = GetSpecific(profile);
        }
        
        // Methods
        public void AddUserImageGallery(UserImageGallery userImageGallery)
        {
            this.UserImageGallery = userImageGallery;
        }

        public void Change(Guid userImageGalleryId, bool blocked, string title, string message)
        {
            Validate(title, message);

            this.UserImageGalleryId = userImageGalleryId;      
            this.Blocked = blocked;     
            this.Title = title;
            this.Message = message;
        }

        public void Change(UserRegisterProfile profile)
        {
            this.Latitude = profile.Latitude;
            this.Longitude = profile.Longitude;
            this.Street = profile.Rua.ToLower();
            this.District = profile.Distrito.ToLower();
            this.City = profile.Cidade.ToLower();
            this.State = profile.Estado.ToLower();
            this.SiteName = profile.SiteName.ToLower();
            this.SemanticFull = GetSemanticFull(profile);
            this.AddressFull = GetAddressFull(profile);            
            this.Specific = GetSpecific(profile);
        }

        public void Change(string action, string controller, bool blocked, int displayValue, bool maintenance)
        {
            Validate(action, controller, displayValue);

            this.Action = action;
            this.Controller = controller;
            this.Blocked = blocked;      
            this.DisplayValue = displayValue;
            this.Maintenance = maintenance;
        }

        public void SetBlock(bool isBlock)
        {
            this.Blocked = isBlock;
        }

        public void SetMaintenance(bool isMaintenance)
        {
            this.Maintenance = isMaintenance;
        }

        private string GetSpecific(UserRegisterProfile profile)
        {
            string cnpj = Regex.Replace(profile.Cnpj, @"[^0-9]+", "");
            string cep = Regex.Replace(profile.CEP, @"[^0-9]+", "");

            return profile.Empresa + "," + cnpj + "," + profile.SiteName + "," + profile.SiteNumber + "," +
                profile.Telefone + "," + profile.Telefone2 + "," + profile.WhatsApp + "," + profile.Skype + "," + profile.Email + "," + cep;
        }

        private string GetSemanticFull(UserRegisterProfile profile)
        {
            return profile.Semantica1 + "," + profile.Semantica2 + "," + profile.Semantica3 + "," + profile.Semantica4 + "," + profile.SiteName;
        }

        private string GetAddressFull(UserRegisterProfile profile)
        {
            return profile.Rua + " " + profile.Distrito + " " + profile.Cidade + " " + profile.Estado;
        }   

        private void Validate(string title, string message)
        { 
            AssertionConcern.AssertArgumentNotNull(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(message, 128, Errors.MaxLength);
        }

        private void Validate(string action, string controller, int displayValue)
        {        
            AssertionConcern.AssertArgumentNotNull(action, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(action, 20, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(controller, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(controller, 32, Errors.MaxLength);
           
            AssertionConcern.AssertArgumentRange(displayValue, 100, 9999, Errors.InvalidNumber);
        }

        private void Validate(string action, string controller,  int displayValue, string title, string message)
        {           
            Validate(title, message);
            Validate(action, controller, displayValue);               
        }
    }
}
