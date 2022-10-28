using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentClient : _Component
    {     
        public string Name { get; private set; }     
        public string Functio { get; private set; }
        public string Comment { get; private set; }
        public string Projects { get; private set; }
        public string SiteOficial { get; private set; }

        // Get IsTags
        public string _Name { get { return IsHtmlTags.GetTags(Name); } }
        public string _Functio { get { return IsHtmlTags.GetTags(Functio); } }
        public string _Comment { get { return IsHtmlTags.GetTags(Comment); } }
        public string _Projects { get { return IsHtmlTags.GetTags(Projects); } }  


        // Relacionamentos       
        public Guid UserImageGalleryId { get; private set; }
        public virtual UserImageGallery UserImageGallery { get; private set; }

        public Guid ComponentClientOptionId { get; private set; }
        public virtual ComponentClientOption ComponentClientOption { get; private set; }

        // Ctor
        protected ComponentClient() { }

        public ComponentClient(string userId, int siteNumber, Guid userImageGalleryId, Guid componentClientOptionId, 
            string name, string functio = "", string comment = "", string projects = "", string siteOficial = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(name, functio, comment, projects, siteOficial);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGalleryId = userImageGalleryId;
            this.ComponentClientOptionId = componentClientOptionId;
            this.SiteOficial = siteOficial;
            this.LastChange = DateTime.Now;

            this.Name = IsHtmlTags.SetTags(name);
            this.Search = IsHtmlTags.RemoveTags(name);
            this.Functio = IsHtmlTags.SetTags(functio);
            this.Projects = IsHtmlTags.SetTags(projects);
            this.Comment = IsHtmlTags.SetTags(comment);
        }

        public ComponentClient(string userId, int siteNumber, Guid userImageGalleryId, ComponentClientOption componentClientOption,
            string name, string functio = "", string comment = "", string projects = "", string siteOficial = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(name, functio, comment, projects, siteOficial);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGalleryId = userImageGalleryId;
            this.ComponentClientOption = componentClientOption;
            this.SiteOficial = siteOficial;
            this.LastChange = DateTime.Now;

            this.Name = IsHtmlTags.SetTags(name);
            this.Search = IsHtmlTags.RemoveTags(name);
            this.Functio = IsHtmlTags.SetTags(functio);
            this.Projects = IsHtmlTags.SetTags(projects);
            this.Comment = IsHtmlTags.SetTags(comment);
        }

        // Methods
        public void AddComponentClientOption(ComponentClientOption componentClientOption)
        {
            this.ComponentClientOption = componentClientOption;
        }

        public void ChangeComponentClientOption(Guid componentClientOptionId)
        {
            this.ComponentClientOptionId = componentClientOptionId;
        }

        public void AddUserImageGallery(UserImageGallery userImageGallery)
        {
            this.UserImageGallery = userImageGallery;
        }

        public void Change(Guid userImageGalleryId, string name, string functio = "", string comment = "", string projects = "", string siteOficial = "")
        {
            Validate(name, functio, comment, projects, siteOficial);

            this.UserImageGalleryId = userImageGalleryId;    
            this.SiteOficial = siteOficial;

            this.Name = IsHtmlTags.SetTags(name);
            this.Search = IsHtmlTags.RemoveTags(name);
            this.Functio = IsHtmlTags.SetTags(functio);
            this.Projects = IsHtmlTags.SetTags(projects);
            this.Comment = IsHtmlTags.SetTags(comment);
        }

        private void Validate(string name, string functio, string comment, string projects, string siteOficial)
        {            
            AssertionConcern.AssertArgumentNotEmpty(name, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(name, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(functio, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(comment, 512, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(projects, 128, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(siteOficial, 128, Errors.MaxLength);            
        }
    }
}
