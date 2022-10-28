using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ContentList : _Content
    {
        public string Search { get; private set; }
        public string Lista { get; private set; }    
        public bool Ordered { get; private set; }           // lista ordenada = true, não ordenada = false 

        // Get IsTags
        public string _Lista { get { return IsHtmlTags.GetTags(Lista); } }
   
        //Relacionamentos
        public Guid ContentListOptionId { get; private set; }
        public virtual ContentListOption ContentListOption { get; private set; }

        // Ctor
        protected ContentList() { }

        public ContentList(string userId, int siteNumber, Guid contentListOptionId, int viewCod, int position, string lista, bool ordered = false)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(viewCod, position, lista);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.ContentListOptionId = contentListOptionId;
            this.ViewCod = viewCod;
            this.Position = position;
            this.Lista = IsHtmlTags.SetTags(lista);
            this.Search = IsHtmlTags.RemoveTags(lista);
            this.LastChange = DateTime.Now;
        }

        public ContentList(string userId, int siteNumber, ContentListOption contentListOption, int viewCod, int position, string lista, bool ordered = false)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(viewCod, position, lista);

            this.IdUser = userId;
            this.SiteNumber = siteNumber;
            this.ContentListOption = contentListOption;
            this.ViewCod = viewCod;
            this.Position = position;
            this.Lista = IsHtmlTags.SetTags(lista);
            this.Search = IsHtmlTags.RemoveTags(lista);
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void AddContentListOption(ContentListOption contentListOption)
        {
            this.ContentListOption = contentListOption;
        }

        public void ChangeContentListOption(Guid contentListOptionId)
        {
            this.ContentListOptionId = contentListOptionId;
        }

        public void Change(int viewCod, int position, string lista, bool ordered = false)
        {
            Validate(viewCod, position, lista);
                        
            this.ViewCod = viewCod;
            this.Position = position;
            this.Lista = IsHtmlTags.SetTags(lista);
            this.Search = IsHtmlTags.RemoveTags(lista);
        }

        private void Validate(int viewCod, int position, string lista)
        {    
            AssertionConcern.AssertArgumentRange(viewCod, 1111, 9999, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(position, 1, 99, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(lista, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(lista, 256, Errors.MaxLength);                    
        }
    }
}
