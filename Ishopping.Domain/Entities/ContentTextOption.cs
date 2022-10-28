using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ContentTextOption : _Option
    {       
        public string Text32 { get; private set; }
        public string Text512 { get; private set; }
        public string Text5120 { get; private set; }   
    
        //Relacionamentos
        public virtual ICollection<ContentText> ContentText { get; set; }

        // Ctor
        protected ContentTextOption() { }

        public ContentTextOption(string userId, bool isDefault, string text32, string text512, string text5120)
        {
            CommonValidate.Validate(userId);
            Validate(text32, text512, text5120);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Text32 = text32;
            this.Text512 = text512;
            this.Text5120 = text5120;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string text32, string text512, string text5120)
        {
            Validate(text32, text512, text5120);

            this.Default = isDefault;
            this.Text32 = text32;
            this.Text512 = text512;
            this.Text5120 = text5120;
        }

        private void Validate(string text32, string text512, string text5120)
        {
            AssertionConcern.AssertArgumentNotEmpty(text32, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(text32, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(text512, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(text512, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(text5120, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(text5120, 64, Errors.MaxLength);
        }
    }
}
