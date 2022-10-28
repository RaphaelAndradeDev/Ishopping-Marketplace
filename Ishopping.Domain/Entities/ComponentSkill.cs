using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ComponentSkill : _Component
    {     
        public int Position { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public int Level { get; private set; }

        // Get IsTags
        public string _Description { get { return IsHtmlTags.GetTags(Description); } }  


        //Relacionamentos
        public Guid ComponentSkillOptionId { get; private set; }
        public virtual ComponentSkillOption ComponentSkillOption { get; private set; }

        // Ctor
        protected ComponentSkill() { }

        public ComponentSkill(string userId, int siteNumber, Guid componentSkillOptionId, string category, int level, string description = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(category, level, description, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentSkillOptionId = componentSkillOptionId;
            this.Category = category;
            this.Level = level;
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Description = IsHtmlTags.SetTags(description);
        }

        public ComponentSkill(string userId, int siteNumber, ComponentSkillOption componentSkillOption, string category, int level, string description = "", int position = 1)
        {
            CommonValidate.Validate(userId, siteNumber);
            Validate(category, level, description, position);

            this.SiteNumber = siteNumber;
            this.IdUser = userId;
            this.ComponentSkillOption = componentSkillOption;
            this.Category = category;
            this.Level = level;
            this.Position = position;
            this.LastChange = DateTime.Now;

            this.Description = IsHtmlTags.SetTags(description);
        }

        // Methods
        public void AddComponentSkillOption(ComponentSkillOption componentSkillOption)
        {
            this.ComponentSkillOption = componentSkillOption;
        }

        public void ChangeComponentSkillOption(Guid componentSkillOptionId)
        {
            this.ComponentSkillOptionId = componentSkillOptionId;
        }

        public void Change(string category, int level, string description = "", int position = 1)
        {     
            this.Category = category;
            this.Level = level;
            this.Position = position;

            this.Description = IsHtmlTags.SetTags(description);
        }

        private void Validate(string category, int level, string description, int position)
        {             
            AssertionConcern.AssertArgumentNotEmpty(category, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(category, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentRange(level, 1, 999, Errors.InvalidNumber);

            AssertionConcern.AssertArgumentLength(description, 512, Errors.MaxLength);    

            AssertionConcern.AssertArgumentRange(position, 1, 6, Errors.InvalidNumber);
        }
    }
}
