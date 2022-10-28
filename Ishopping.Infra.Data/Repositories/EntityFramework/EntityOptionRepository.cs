using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Infra.Data.Contexto;
using System;
using System.Collections.Generic;

namespace Ishopping.Infra.Data.Repositories
{
    public class EntityOptionRepository : IEntityOptionRepository
    {
        protected IshoppingContext db = new IshoppingContext();

        public void AddEntityOption(int entityOption, string userId)
        {
            AddOption(entityOption, userId);
            db.SaveChanges();
        }

        public void AddEntityOption(IEnumerable<int> listEntityOption, string userId)
        {
            foreach (var entityOption in listEntityOption)
            {
                AddOption(entityOption, userId);
            }
            db.SaveChanges();
        }

        public Guid AddContentButtonOption(string userId)
        {
            var contentButtonOption = new ContentButtonOption(userId, true, "SemEstilo");
            db.ContentButtonOption.Add(contentButtonOption);
            db.SaveChanges();
            return contentButtonOption.Id;
        }

        public Guid AddContentListOption(string userId)
        {
            var contentListOption = new ContentListOption(userId, true, "SemEstilo");
            db.ContentListOption.Add(contentListOption);
            db.SaveChanges();
            return contentListOption.Id;
        }

        public Guid AddContentTextOption(string userId)
        {
            var contentTextOption = new ContentTextOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo");
            db.ContentTextOption.Add(contentTextOption);
            db.SaveChanges();
            return contentTextOption.Id;
        }

        private void AddOption(int entityOption, string userId)
        {
            switch (entityOption)
            {
                case 11:
                    var contentButton = new ContentButtonOption(userId, true, "SemEstilo");
                    db.ContentButtonOption.Add(contentButton);
                    break;

                case 13:
                    var contentList = new ContentListOption(userId, true, "SemEstilo");
                    db.ContentListOption.Add(contentList);
                    break;

                case 14:
                    var contentText = new ContentTextOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ContentTextOption.Add(contentText);
                    break;

                case 21:
                    var componentActivityOption = new ComponentActivityOption(userId, true, "SemEstilo", "SemEstilo");
                    db.ComponentActivityOption.Add(componentActivityOption);
                    break;

                case 22:
                    var componentBrand = new ComponentBrandOption(userId, true, "SemEstilo", "SemEstilo");
                    db.ComponentBrandOption.Add(componentBrand);
                    break;

                case 23:
                    var componentClient = new ComponentClientOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ComponentClientOption.Add(componentClient);
                    break;

                case 24:
                    var componentExtraLink = new ComponentExtraLinkOption(userId, true, "SemEstilo", "SemEstilo");
                    db.ComponentExtraLinkOption.Add(componentExtraLink);
                    break;

                case 25:
                    var componentFaq = new ComponentFaqOption(userId, true, "SemEstilo", "SemEstilo");
                    db.ComponentFaqOption.Add(componentFaq);
                    break;

                case 26:
                    var componentFeatures = new ComponentFeaturesOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ComponentFeaturesOption.Add(componentFeatures);
                    break;

                case 27:
                    var componentMenu = new ComponentMenuOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ComponentMenuOption.Add(componentMenu);
                    break;

                case 28:
                    var componentPanel = new ComponentPanelOption(userId, true, "SemEstilo", "SemEstilo");
                    db.ComponentPanelOption.Add(componentPanel);
                    break;

                case 29:
                    var componentPortfolio = new ComponentPortofolioOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ComponentPortofolioOption.Add(componentPortfolio);
                    break;

                case 30:
                    var componentPost = new ComponentPostOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ComponentPostOption.Add(componentPost);
                    break;

                case 31:
                    var componentPricing = new ComponentPricingOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ComponentPricingOption.Add(componentPricing);
                    break;

                case 32:
                    var componentProject = new ComponentProjectOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ComponentProjectOption.Add(componentProject);
                    break;

                case 33:
                    var componentService = new ComponentServiceOption(userId, true, "SemEstilo", "SemEstilo");
                    db.ComponentServiceOption.Add(componentService);
                    break;

                case 34:
                    var componentSkill = new ComponentSkillOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ComponentSkillOption.Add(componentSkill);
                    break;

                case 36:
                    var componentTeam = new ComponentTeamOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ComponentTeamOption.Add(componentTeam);
                    break;

                case 38:
                    var componentPresentation = new ComponentPresentationOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ComponentPresentationOption.Add(componentPresentation);
                    break;

                case 39:
                    var componentScope = new ComponentScopeOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ComponentScopeOption.Add(componentScope);
                    break;

                case 40:
                    var componentSimpleProduct = new ComponentSimpleProductOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ComponentSimpleProductOption.Add(componentSimpleProduct);
                    break;

                case 41:
                    var componentSummary = new ComponentSummaryOption(userId, true, "SemEstilo", "SemEstilo", "SemEstilo");
                    db.ComponentSummaryOption.Add(componentSummary);
                    break;
            }
        }
    }
}
