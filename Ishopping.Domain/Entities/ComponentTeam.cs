using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentTeam : _Component
    {   
        public string Name { get; private set; }    
        public string Functio { get; private set; }
        public string Description { get; private set; }

        // Get IsTags
        public string _Name { get { return IsHtmlTags.GetTags(Name); } }
        public string _Functio { get { return IsHtmlTags.GetTags(Functio); } }
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }


        // Relacionamentos 
        public Guid UserImageGalleryId { get; private set; }
        public virtual UserImageGallery UserImageGallery { get; private set; }

        public virtual ICollection<ComponentTeamSocialNetwork> ComponentTeamSocialNetwork { get; private set; }

        public Guid ComponentTeamOptionId { get; private set; }
        public virtual ComponentTeamOption ComponentTeamOption { get; private set; }

        // Ctor
        protected ComponentTeam() { }

        public ComponentTeam(string userId, int siteNumber, Guid userImageGalleryId, Guid componentTeamOptionId, string name, string functio = "", string description = "")
        {
            CommonValidate.Validate(userId, siteNumber);  
            Validate(name, functio, description);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;          
            this.UserImageGalleryId = userImageGalleryId;           
            this.ComponentTeamOptionId = componentTeamOptionId;
            this.LastChange = DateTime.Now;

            this.Name = IsHtmlTags.SetTags(name);
            this.Search = IsHtmlTags.RemoveTags(name);
            this.Functio = IsHtmlTags.SetTags(functio);
            this.Description = IsHtmlTags.SetTags(description);
        }

        public ComponentTeam(string userId, int siteNumber, Guid userImageGalleryId, ComponentTeamOption componentTeamOption, string name, string functio = "", string description = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(name, functio, description);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGalleryId = userImageGalleryId;
            this.ComponentTeamOption = componentTeamOption;
            this.LastChange = DateTime.Now;

            this.Name = IsHtmlTags.SetTags(name);
            this.Search = IsHtmlTags.RemoveTags(name);
            this.Functio = IsHtmlTags.SetTags(functio);
            this.Description = IsHtmlTags.SetTags(description);
        }

        // Methods
        public void AddComponentTeamOption(ComponentTeamOption componentTeamOption)
        {
            this.ComponentTeamOption = componentTeamOption;
        }

        public void ChangeComponentTeamOption(Guid componentTeamOptionId)
        {
            this.ComponentTeamOptionId = componentTeamOptionId;
        }

        public void AddComponentTeamSocialNetwork(ComponentTeamSocialNetwork componentTeamSocialNetwork)
        {
            this.ComponentTeamSocialNetwork.Add(componentTeamSocialNetwork);
        }

        public void AddUserImageGallery(UserImageGallery userImageGallery)
        {
            this.UserImageGallery = userImageGallery;
        }

        public void Change(Guid userImageGalleryId, string name, string functio = "", string description = "")
        {
            Validate(name, functio, description);
                        
            this.UserImageGalleryId = userImageGalleryId;       

            this.Name = IsHtmlTags.SetTags(name);
            this.Search = IsHtmlTags.RemoveTags(name);
            this.Functio = IsHtmlTags.SetTags(functio);
            this.Description = IsHtmlTags.SetTags(description);
        }

        private void Validate(string name, string functio, string description)
        {           
            AssertionConcern.AssertArgumentNotEmpty(name, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(name, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(functio, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);        
        }
    }
}
