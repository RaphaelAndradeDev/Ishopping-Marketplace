using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ContentButtonOption : _Option
    {    
        public string TextBtn { get; private set; }       

        //Relacionamento
        public virtual ICollection<ContentButton> ContentButton { get; set; }

        // Ctor
        protected ContentButtonOption() { }

        public ContentButtonOption(string userId, bool isDefault, string textBtb)
        {
            CommonValidate.Validate(userId);
            Validate(textBtb);

            this.IdUser = userId;
            this.Default = isDefault;
            this.TextBtn = textBtb;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string textBtb)
        {
            Validate(textBtb);
            this.Default = isDefault;
            this.TextBtn = textBtb;           
        }

        private void Validate(string textBtn)
        {
            AssertionConcern.AssertArgumentNotEmpty(textBtn, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(textBtn, 64, Errors.MaxLength);
        }
    }
}
