using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentPanel : _Component
    {    
        public int Position { get; private set; }
        public string Icon { get; private set; }
        public string Title { get; private set; }   
        public string Text { get; private set; }    

        // Get IsTags
        public string _Title { get { return IsHtmlTags.GetTags(Title); } }
        public string _Text { get { return IsHtmlTags.GetTags(Text); } }  
  
        //Relacionamentos
        public Guid ComponentPanelOptionId { get; private set; }
        public virtual ComponentPanelOption ComponentPanelOption { get; private set; }

        // Ctor
        protected ComponentPanel() { }

        public ComponentPanel(string userId, int siteNumber, Guid componentPanelOptionId, string title, string text, string icon = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber);  
            Validate(title, text, icon, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentPanelOptionId = componentPanelOptionId;
            this.Icon = icon;
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Text = IsHtmlTags.SetTags(text);
        }

        public ComponentPanel(string userId, int siteNumber, ComponentPanelOption componentPanelOption, string title, string text, string icon = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(title, text, icon, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentPanelOption = componentPanelOption;
            this.Icon = icon;
            this.Position = position;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Text = IsHtmlTags.SetTags(text);
        }

        // Methods
        public void AddComponentPanelOption(ComponentPanelOption componentPanelOption)
        {
            this.ComponentPanelOption = componentPanelOption;
        }

        public void ChangeComponentPanelOption(Guid componentPanelOptionId)
        {
            this.ComponentPanelOptionId = componentPanelOptionId;
        }

        public void Change(string title, string text, string icon = "", int position = 1)
        {
            Validate(title, text, icon, position);
                        
            this.Icon = icon;
            this.Position = position;

            this.Title = IsHtmlTags.SetTags(title);
            this.Search = IsHtmlTags.RemoveTags(title);
            this.Text = IsHtmlTags.SetTags(text);
        }

        private void Validate(string title, string text, string icon, int position)
        {           
            AssertionConcern.AssertArgumentRange(position, 1, 6, Errors.InvalidNumber);

            AssertionConcern.AssertArgumentNotEmpty(title, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(title, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(text, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(text, 512, Errors.MaxLength);
                       
            AssertionConcern.AssertArgumentLength(icon, 32, Errors.MaxLength);
        }
    }
}
