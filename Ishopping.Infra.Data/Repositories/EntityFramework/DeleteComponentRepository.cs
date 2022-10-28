using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Infra.Data.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class DeleteComponentRepository : IDeleteComponentRepository
    {
        protected IshoppingContext db = new IshoppingContext();

        public List<int> DeleteComponent(string userId, IEnumerable<int> viewItemCod)
        {
            List<int> listImgType = new List<int>();

            foreach (var item in viewItemCod)
            {
                switch (item)
                {
                    case 21:
                        var componentActivity = db.ComponentActivity.Where(x => x.IdUser == userId).ToList();
                        db.ComponentActivity.RemoveRange(componentActivity);
                        var componentActivityOption = db.ComponentActivityOption.Where(x => x.IdUser == userId).ToList();                      
                        db.ComponentActivityOption.RemoveRange(componentActivityOption);
                        break;
                    case 22:
                        listImgType.Add(6);// Componente que possui imagem
                        var componentBrand = db.ComponentBrand.Where(x => x.IdUser == userId).ToList();
                        db.ComponentBrand.RemoveRange(componentBrand);
                        var componentBrandOption = db.ComponentBrandOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentBrandOption.RemoveRange(componentBrandOption);
                        break;
                    case 23:
                        listImgType.Add(4);// Componente que possui imagem
                        var componentClient = db.ComponentClient.Where(x => x.IdUser == userId).ToList();
                        db.ComponentClient.RemoveRange(componentClient);
                        var componentClientOption = db.ComponentClientOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentClientOption.RemoveRange(componentClientOption);
                        break;
                    case 24:
                        var componentExtraLink = db.ComponentExtraLink.Where(x => x.IdUser == userId).ToList();
                        db.ComponentExtraLink.RemoveRange(componentExtraLink);
                        var componentExtraLinkOption = db.ComponentExtraLinkOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentExtraLinkOption.RemoveRange(componentExtraLinkOption);
                        break;
                    case 25:
                        var componentFaq = db.ComponentFaq.Where(x => x.IdUser == userId).ToList();
                        db.ComponentFaq.RemoveRange(componentFaq);
                        var componentFaqOption = db.ComponentFaqOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentFaqOption.RemoveRange(componentFaqOption);
                        break;
                    case 26:
                        var componentFeatures = db.ComponentFeatures.Where(x => x.IdUser == userId).ToList();
                        db.ComponentFeatures.RemoveRange(componentFeatures);
                        var componentFeaturesOption = db.ComponentFeaturesOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentFeaturesOption.RemoveRange(componentFeaturesOption);
                        break;
                    case 27:
                        listImgType.Add(13);// Componente que possui imagem
                        var componentMenu = db.ComponentMenu.Where(x => x.IdUser == userId).ToList();
                        db.ComponentMenu.RemoveRange(componentMenu);
                        var componentMenuOption = db.ComponentMenuOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentMenuOption.RemoveRange(componentMenuOption);
                        break;
                    case 28:
                        var componentPanel = db.ComponentPanel.Where(x => x.IdUser == userId).ToList();
                        db.ComponentPanel.RemoveRange(componentPanel);
                        var componentPanelOption = db.ComponentPanelOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentPanelOption.RemoveRange(componentPanelOption);
                        break;
                    case 29:
                        listImgType.Add(7);// Componente que possui imagem
                        var componentPortofolio = db.ComponentPortofolio.Where(x => x.IdUser == userId).ToList();
                        db.ComponentPortofolio.RemoveRange(componentPortofolio);
                        var componentPortofolioOption = db.ComponentPortofolioOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentPortofolioOption.RemoveRange(componentPortofolioOption);
                        break;
                    case 30:
                        listImgType.Add(10);// Componente que possui imagem
                        var componentPost = db.ComponentPost.Where(x => x.IdUser == userId).ToList();
                        db.ComponentPost.RemoveRange(componentPost);
                        var componentPostOption = db.ComponentPostOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentPostOption.RemoveRange(componentPostOption);
                        break;
                    case 31:
                        var componentPricing = db.ComponentPricing.Where(x => x.IdUser == userId).ToList();
                        db.ComponentPricing.RemoveRange(componentPricing);
                        var componentPricingOption = db.ComponentPricingOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentPricingOption.RemoveRange(componentPricingOption);
                        break;
                    case 32:
                        listImgType.Add(8);// Componente que possui imagem
                        var componentProject = db.ComponentProject.Where(x => x.IdUser == userId).ToList();
                        db.ComponentProject.RemoveRange(componentProject);
                        var componentProjectOption = db.ComponentProjectOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentProjectOption.RemoveRange(componentProjectOption);
                        break;
                    case 33:
                        listImgType.Add(11);// Componente que possui imagem
                        var componentService = db.ComponentService.Where(x => x.IdUser == userId).ToList();
                        db.ComponentService.RemoveRange(componentService);
                        var componentServiceOption = db.ComponentServiceOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentServiceOption.RemoveRange(componentServiceOption);
                        break;
                    case 34:
                        var componentSkill = db.ComponentSkill.Where(x => x.IdUser == userId).ToList();
                        db.ComponentSkill.RemoveRange(componentSkill);
                        var componentSkillOption = db.ComponentSkillOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentSkillOption.RemoveRange(componentSkillOption);
                        break;       
                    case 36:
                        listImgType.Add(5);// Componente que possui imagem
                        var componentTeam = db.ComponentTeam.Where(x => x.IdUser == userId).ToList();
                        db.ComponentTeam.RemoveRange(componentTeam);
                        var componentTeamOption = db.ComponentTeamOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentTeamOption.RemoveRange(componentTeamOption);
                        break;                       
                    case 37:
                        listImgType.Add(14);// Componente que possui imagem
                        var componentThumbnail = db.ComponentThumbnail.Where(x => x.IdUser == userId).ToList();
                        db.ComponentThumbnail.RemoveRange(componentThumbnail);                       
                        break;
                    case 38:
                        listImgType.Add(15);// Componente que possui imagem
                        var componentPresentation = db.ComponentPresentation.Where(x => x.IdUser == userId).ToList();
                        db.ComponentPresentation.RemoveRange(componentPresentation);
                        var componentPresentationOption = db.ComponentPresentationOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentPresentationOption.RemoveRange(componentPresentationOption);
                        break;
                    case 39:
                        var componentScope = db.ComponentScope.Where(x => x.IdUser == userId).ToList();
                        db.ComponentScope.RemoveRange(componentScope);
                        var componentScopeOption = db.ComponentScopeOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentScopeOption.RemoveRange(componentScopeOption);
                        break;
                    case 40:
                        listImgType.Add(9);// Componente que possui imagem
                        var componentSimpleProduct = db.ComponentSimpleProduct.Where(x => x.IdUser == userId).ToList();
                        db.ComponentSimpleProduct.RemoveRange(componentSimpleProduct);
                        var componentSimpleProductOption = db.ComponentSimpleProductOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentSimpleProductOption.RemoveRange(componentSimpleProductOption);
                        break;
                    case 41:
                        var componentSummary = db.ComponentSummary.Where(x => x.IdUser == userId).ToList();
                        db.ComponentSummary.RemoveRange(componentSummary);
                        var componentSummaryOption = db.ComponentSummaryOption.Where(x => x.IdUser == userId).ToList();
                        db.ComponentSummaryOption.RemoveRange(componentSummaryOption);
                        break;
                }
            }

            // Deletar mesmo que não esteja na lista
            var socialNetwork = db.ComponentSocialNetwork.Where(x => x.IdUser == userId).ToList();
            db.ComponentSocialNetwork.RemoveRange(socialNetwork);
                    
            db.SaveChanges();
            return listImgType;
        }
    }
}
