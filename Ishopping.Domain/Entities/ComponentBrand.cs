using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentBrand : _Component
    {       
        public string Marca { get; private set; } 
        public string Comment { get; private set; }
        public string SiteOficial { get; private set; }
        public int Exibicao { get; private set; }

        // Get IsTags
        public string _Marca { get { return IsHtmlTags.GetTags(Marca); } }
        public string _Comment { get { return IsHtmlTags.GetTags(Comment); } }  


        // Relacionamentos     
        public Guid UserImageGalleryId { get; private set; }
        public virtual UserImageGallery UserImageGallery { get; private set; }

        public Guid ComponentBrandOptionId { get; private set; }
        public virtual ComponentBrandOption ComponentBrandOption { get; private set; }

        // Ctor
        protected ComponentBrand() { }

        public ComponentBrand(string userId, int siteNumber, Guid userImageGalleryId, Guid componentBrandOptionId, string marca, string comment = "", string siteOficial = "", int exibicao = 0)
        {
            CommonValidate.Validate(userId, siteNumber);  
            Validate(marca, comment, siteOficial, exibicao);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGalleryId = userImageGalleryId;
            this.ComponentBrandOptionId = componentBrandOptionId;
            this.SiteOficial = siteOficial;
            this.Exibicao = exibicao;
            this.LastChange = DateTime.Now;

            this.Marca = IsHtmlTags.SetTags(marca);
            this.Search = IsHtmlTags.RemoveTags(marca);
            this.SiteOficial = IsHtmlTags.SetTags(comment);
        }

        public ComponentBrand(string userId, int siteNumber, Guid userImageGalleryId, ComponentBrandOption componentBrandOption, string marca, string comment = "", string siteOficial = "", int exibicao = 0)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(marca, comment, siteOficial, exibicao);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGalleryId = userImageGalleryId;
            this.ComponentBrandOption = componentBrandOption;
            this.SiteOficial = siteOficial;
            this.Exibicao = exibicao;
            this.LastChange = DateTime.Now;

            this.Marca = IsHtmlTags.SetTags(marca);
            this.Search = IsHtmlTags.RemoveTags(marca);
            this.SiteOficial = IsHtmlTags.SetTags(comment);
        }

        // Methods
        public void AddComponentBrandOption(ComponentBrandOption componentBrandOption)
        {
            this.ComponentBrandOption = componentBrandOption;
        }

        public void ChangeComponentBrandOption(Guid componentBrandOptionId)
        {
            this.ComponentBrandOptionId = componentBrandOptionId;
        }

        public void AddUserImageGallery(UserImageGallery userImageGallery)
        {
            this.UserImageGallery = userImageGallery;
        }

        public void Change(Guid userImageGalleryId, string marca, string comment = "", string siteOficial = "", int exibicao = 0)
        {
            Validate(marca, comment, siteOficial, exibicao);

            this.UserImageGalleryId = userImageGalleryId;           
            this.SiteOficial = siteOficial;
            this.Exibicao = exibicao;

            this.Marca = IsHtmlTags.SetTags(marca);
            this.Search = IsHtmlTags.RemoveTags(marca);
            this.SiteOficial = IsHtmlTags.SetTags(comment);
        }

        private void Validate(string marca, string comment, string siteOficial, int exibicao)
        {          
            AssertionConcern.AssertArgumentNotEmpty(marca, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(marca, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(comment, 256, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(siteOficial, 128, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(exibicao, 0, 9, Errors.InvalidNumber);
        }
    }
}
