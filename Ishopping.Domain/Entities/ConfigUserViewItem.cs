using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ConfigUserViewItem : _UserData
    {     
        public bool Active { get; private set; }                                // Ativar este item.                                 
        public string TextMenu { get; private set; }                            // Texto que aparecera no menu para esta viewItem
        public string TextView { get; private set; }                            // Texto que aparecera na view
        public string StTextView { get; private set; }                          // Estilo do texto que aparecera na view
        public string SubTitle { get; private set; }                            // Subtitulo que aparecera na view 
        public string StSubTitle { get; private set; }                          // Estilo do subtitulo que aparecera na view 

        // Get IsTags
        public string _TextView { get { return IsHtmlTags.GetTags(TextView); } }
        public string _SubTitle { get { return IsHtmlTags.GetTags(SubTitle); } }


        // Relacionamentos ----------------------------
        public Guid ConfigUserViewId { get; private set; }
        public virtual ConfigUserView ConfigUserView { get; private set; }
        public int AdminViewItemId { get; private set; }
        public virtual AdminViewItem AdminViewItem { get; private set; }


        // Ctor
        protected ConfigUserViewItem() { }

        public ConfigUserViewItem(string userId, int siteNumber, int adminViewItemId, Guid configUserViewId,
             bool active = true, string textMenu = "", string textView = "", string stTextView = "", string subTitle = "", string stSubTitle = "")
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(textMenu, textView, stTextView, subTitle, stSubTitle);        

            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.AdminViewItemId = adminViewItemId;
            this.ConfigUserViewId = configUserViewId;        
            this.Active = active;
            this.TextMenu = textMenu;
            this.StTextView = stTextView;
            this.StSubTitle = stSubTitle;
            this.TextView = IsHtmlTags.SetTags(textView);
            this.SubTitle = IsHtmlTags.SetTags(subTitle);
            this.LastChange = DateTime.Now;
        }
       
        public void AddAdminViewItem(AdminViewItem adminViewItem)
        {
            this.AdminViewItem = adminViewItem;
        }

        public void Change(bool active, string textMenu, string textView)
        {
            Validate(textMenu, textView);

            this.Active = active;
            this.TextMenu = textMenu;
            this.TextView = textView;
            this.LastChange = DateTime.Now;
        }

        public void Change(string textView, string stTextView, string subTitle, string stSubTitle)
        {
            Validate(textView, stTextView, subTitle, stSubTitle);
                      
            this.StTextView = stTextView;
            this.StSubTitle = stSubTitle;
            this.TextView = IsHtmlTags.SetTags(textView);
            this.SubTitle = IsHtmlTags.SetTags(subTitle);
            this.LastChange = DateTime.Now;
        }

        public void Change(AdminViewItem adminViewItem, ConfigUserView configUserView,
            bool active = true, string textMenu = "", string textView = "", string stTextView = "", string subTitle = "", string stSubTitle = "")
        {
            Validate(textMenu, textView, stTextView, subTitle, stSubTitle); 

            this.AdminViewItem = adminViewItem;
            this.ConfigUserView = configUserView; 
            this.Active = active;
            this.TextMenu = textMenu;
            this.StTextView = stTextView;
            this.StSubTitle = stSubTitle;
            this.TextView = IsHtmlTags.SetTags(textView);
            this.SubTitle = IsHtmlTags.SetTags(subTitle);
            this.LastChange = DateTime.Now;
        }

        public void StyleChange(string stTextView, string stSubTitle)
        {
            ValidateSt(stTextView, stSubTitle);

            this.StTextView = stTextView;
            this.StSubTitle = stSubTitle;        
            this.LastChange = DateTime.Now;
        }
        
        private void Validate(string textMenu, string textView)
        {
            AssertionConcern.AssertArgumentLength(textMenu, 20, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(textView, 64, Errors.MaxLength);
        }

        private void ValidateSt(string stTextView, string stSubTitle)
        {        
            AssertionConcern.AssertArgumentLength(stTextView, 64, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(stSubTitle, 64, Errors.MaxLength);
        }

        private void Validate(string textView, string stTextView, string subTitle, string stSubTitle)
        {
            ValidateSt(stTextView, stSubTitle);
            AssertionConcern.AssertArgumentLength(textView, 64, Errors.MaxLength);
            AssertionConcern.AssertArgumentLength(subTitle, 256, Errors.MaxLength);
        }

        private void Validate(string textMenu, string textView, string stTextView, string subTitle, string stSubTitle)
        {
            AssertionConcern.AssertArgumentLength(textMenu, 20, Errors.MaxLength);
            Validate(textView, stTextView, subTitle, stSubTitle);       
        }
  
    }
}
