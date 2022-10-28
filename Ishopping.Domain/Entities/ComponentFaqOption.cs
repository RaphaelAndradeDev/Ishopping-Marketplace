using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;
using System.Collections.Generic;

namespace Ishopping.Domain.Entities
{
    public class ComponentFaqOption : _Option
    { 
        public string Pergunta { get; private set; }
        public string Resposta { get; private set; }

        //Relacionamentos
        public virtual ICollection<ComponentFaq> ComponentFaq { get; private set; }

        // Ctor
        protected ComponentFaqOption() { }
      
        public ComponentFaqOption(string userId, bool isDefault, string pergunta, string resposta)
        {
            CommonValidate.Validate(userId);
            Validate(pergunta, resposta);

            this.IdUser = userId;
            this.Default = isDefault;
            this.Pergunta = pergunta;
            this.Resposta = resposta;
            this.LastChange = DateTime.Now;
        }

        // Methods
        public void Change(bool isDefault, string pergunta, string resposta)
        {
            Validate(pergunta, resposta);

            this.Default = isDefault;
            this.Pergunta = pergunta;
            this.Resposta = resposta;
        }

        private void Validate(string pergunta, string resposta)
        {        
            AssertionConcern.AssertArgumentNotEmpty(pergunta, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(pergunta, 64, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(resposta, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(resposta, 64, Errors.MaxLength);
        }
    }
}
