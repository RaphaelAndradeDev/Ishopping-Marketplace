using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentFaq : _Component
    {    
        public int Position { get; private set; }
        public string Category { get; private set; }
        public string Pergunta { get; private set; }       
        public string Resposta { get; private set; }

        // Get IsTags
        public string _Pergunta { get { return IsHtmlTags.GetTags(Pergunta); } }
        public string _Resposta { get { return IsHtmlTags.GetTags(Resposta); } }  


        // Relacionamentos
        public Guid ComponentFaqOptionId { get; private set; }
        public virtual ComponentFaqOption ComponentFaqOption { get; private set; }

        // Ctor
        protected ComponentFaq() { }

        public ComponentFaq(string userId, int siteNumber, Guid componentFaqOptionId, string pergunta, string resposta, string category = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(pergunta, resposta, category, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentFaqOptionId = componentFaqOptionId;
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Pergunta = IsHtmlTags.SetTags(pergunta);
            this.Search = IsHtmlTags.RemoveTags(pergunta.Substring(0, 64));
            this.Resposta = IsHtmlTags.SetTags(resposta);
        }

        public ComponentFaq(string userId, int siteNumber, ComponentFaqOption componentFaqOption, string pergunta, string resposta, string category = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(pergunta, resposta, category, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentFaqOption = componentFaqOption;
            this.Position = position;

            this.Pergunta = IsHtmlTags.SetTags(pergunta);
            this.Search = IsHtmlTags.RemoveTags(pergunta.Substring(0, 64));
            this.Resposta = IsHtmlTags.SetTags(resposta);
        }

        // Methods
        public void AddComponentFaqOption(ComponentFaqOption componentFaqOption)
        {
            this.ComponentFaqOption = componentFaqOption;
        }

        public void ChangeComponentFaqOption(Guid componentFaqOptionId)
        {
            this.ComponentFaqOptionId = componentFaqOptionId;
        }

        public void Change(Guid componentFaqOptionId, string pergunta, string resposta, string category = "", int position = 1)
        {
            Validate(pergunta, resposta, category, position);

            this.ComponentFaqOptionId = componentFaqOptionId;
            this.Position = position;

            this.Pergunta = IsHtmlTags.SetTags(pergunta);
            this.Search = IsHtmlTags.RemoveTags(pergunta.Substring(0, 64));
            this.Resposta = IsHtmlTags.SetTags(resposta);
        }

        private void Validate(string pergunta, string resposta, string category, int position)
        {            
            AssertionConcern.AssertArgumentRange(position, 1, 6, Errors.InvalidNumber);

            AssertionConcern.AssertArgumentNotEmpty(pergunta, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(pergunta, 256, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotEmpty(resposta, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(resposta, 512, Errors.MaxLength);

            AssertionConcern.AssertArgumentLength(category, 32, Errors.MaxLength);                       
        }
    }
}
