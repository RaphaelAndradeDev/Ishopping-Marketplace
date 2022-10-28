using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentProject : _Component
    {        
        public string Name { get; private set; }
        public string Title { get; private set; }
        public DateTime DateIn { get; private set; }
        public string Client { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public string WebSite { get; private set; }
        public string UrlVideo { get; private set; }
        public string Team { get; private set; }

        // Get IsTags
        public string _Title { get { return IsHtmlTags.GetTags(Title); } }
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }
        public string _Name { get { return IsHtmlTags.GetTags(Name); } }
        public string _Client { get { return IsHtmlTags.GetTags(Client); } }
             

        // Relacionamentos
        public virtual ICollection<UserImageGallery> UserImageGallery { get; private set; }

        public Guid ComponentProjectOptionId { get; private set; }
        public virtual ComponentProjectOption ComponentProjectOption { get; private set; }

        // Ctor
        protected ComponentProject() { }

        public ComponentProject(string userId, int siteNumber, ICollection<UserImageGallery> userImageGallery, Guid componentProjectOptionId, string title, string description, DateTime dateIn, 
            string name = "", string client = "", string category = "", string webSite = "", string team = "", string urlVideo = "")
        {
            CommonValidate.Validate(userId, siteNumber);  
            Validate(title, description, name, client, category, webSite, team, urlVideo);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGallery = userImageGallery;
            this.ComponentProjectOptionId = componentProjectOptionId;
            this.DateIn = dateIn;
            this.Category = category;
            this.WebSite = webSite;
            this.Team = team;
            this.UrlVideo = urlVideo;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
            this.Name = IsHtmlTags.SetTags(name);
            this.Client = IsHtmlTags.SetTags(client);  

            this.UserImageGallery = new HashSet<UserImageGallery>();
        }

        public ComponentProject(string userId, int siteNumber, ICollection<UserImageGallery> userImageGallery, ComponentProjectOption componentProjectOption, string title, string description, DateTime dateIn,
            string name = "", string client = "", string category = "", string webSite = "", string team = "", string urlVideo = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(title, description, name, client, category, webSite, team, urlVideo);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.UserImageGallery = userImageGallery;
            this.ComponentProjectOption = componentProjectOption;
            this.DateIn = dateIn;
            this.Category = category;
            this.WebSite = webSite;
            this.Team = team;
            this.UrlVideo = urlVideo;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
            this.Name = IsHtmlTags.SetTags(name);
            this.Client = IsHtmlTags.SetTags(client);

            this.UserImageGallery = new HashSet<UserImageGallery>();
        }

        // Methods
        public void AddComponentProjectOption(ComponentProjectOption componentProjectOption)
        {
            this.ComponentProjectOption = componentProjectOption;
        }

        public void ChangeComponentProjectOption(Guid componentProjectOptionId)
        {
            this.ComponentProjectOptionId = componentProjectOptionId;
        }

        public void AddListUserImageGallery(ICollection<UserImageGallery> userImageGallery)
        {
            this.UserImageGallery = userImageGallery;
        }

        public void Change(ICollection<UserImageGallery> userImageGallery, string title, string description, DateTime dateIn,
            string name = "", string client = "", string category = "", string webSite = "", string team = "", string urlVideo = "")
        {
            Validate(title, description, name, client, category, webSite, team, urlVideo);

            this.UserImageGallery = userImageGallery;        
            this.DateIn = dateIn;
            this.Category = category;
            this.WebSite = webSite;
            this.Team = team;
            this.UrlVideo = urlVideo;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Description = IsHtmlTags.SetTags(description);
            this.Name = IsHtmlTags.SetTags(name);
            this.Client = IsHtmlTags.SetTags(client);  
        }

        private void Validate(string title, string description,
            string name, string client, string category, string webSite, string team, string urlVideo)
        {            
            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(description, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(name, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(client, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(category, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(webSite, 128, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(team, 128, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(urlVideo, 128, Errors.MaxLength);
        }
    }
}
