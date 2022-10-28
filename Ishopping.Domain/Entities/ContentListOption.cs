using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ContentListOption : _Option
    {       
        public string Lista { get; private set; }   
   
        //Relacionamentos
        public virtual ICollection<ContentList> ContentList { get; set; }

        // Ctor
        protected ContentListOption() { }
      
        public ContentListOption(string userId, bool isDefault, string lista)
        {
            CommonValidate.Validate(userId);
            Validate(lista);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Lista = lista;
            this.LastChange = DateTime.Now;
        }

        public void Change(bool isDefault, string lista)
        {
            Validate(lista);

            this.Default = isDefault;
            this.Lista = lista;           
        }

        private void Validate(string lista)
        {
            AssertionConcern.AssertArgumentNotEmpty(lista, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(lista, 64, Errors.MaxLength);
        }
    }
}
