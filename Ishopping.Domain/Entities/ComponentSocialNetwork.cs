using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentSocialNetwork : _SocialNetwork
    {
        public Guid Id { get; private set; }
        public string IdUser { get; private set; }
        public int SiteNumber { get; private set; }
        public string Link { get; private set; }

        // Ctor
        protected ComponentSocialNetwork() { }

        public ComponentSocialNetwork(string userId, int siteNumber, string rede, string link)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(rede, link);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.Rede = rede;
            this.Link = link;           
        }

        // Methods
        public void Change(string rede, string link)
        {
            Validate(rede, link);
                      
            this.Rede = rede;
            this.Link = link;          
        }

        public void AddAdminClass(string classe1, string classe2, string classe3, string classe4)
        {
            Validate(classe1, classe2, classe3, classe4);
                   
            this.Classe1 = classe1;
            this.Classe2 = classe2;
            this.Classe3 = classe3;
            this.Classe4 = classe4;
        }

        private void Validate(string rede, string link)
        {
            AssertionConcern.AssertArgumentNotEmpty(rede, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(rede, 20, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(link, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(link, 128, Errors.MaxLength);
        }

        private void Validate(string classe1, string classe2, string classe3, string classe4)
        {           
            AssertionConcern.AssertArgumentLength(classe1, 48, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(classe2, 48, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(classe3, 48, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(classe4, 48, Errors.MaxLength);
        }
    }
}
