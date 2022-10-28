using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class UserRegisterProfileRepository : RepositoryBaseT2<UserRegisterProfile>, IUserRegisterProfileRepository
    {
        public UserRegisterProfile GetBySiteNumber(int siteNumber)
        {
             return db.UserRegisterProfile.FirstOrDefault(x => x.SiteNumber == siteNumber);
        }
        
        public UserRegisterProfile GetByUserId(string userId)
        {
            return db.UserRegisterProfile.FirstOrDefault(x => x.IdUser == userId);
        }
        
        public bool ExistProfile(string userId)
        {
            return db.UserRegisterProfile.Any(x => x.IdUser == userId);
        }
        
        public GroupPlan GetPlan(string userId)
        {
            var adminTemplateRepository = new AdminTemplateRepository();    
            var adminViewDataRepository = new AdminViewDataRepository();
            var profile = GetByUserId(userId);

            var adminTemplate = adminTemplateRepository.GetByViewCod(profile.ViewStart);

            var groupPlan = new GroupPlan();      
            groupPlan.KeyTemplete = adminTemplate.TemplateCod;
            groupPlan.KeyGroup = adminTemplate.Group;
            groupPlan.KeyViewStart = profile.ViewStart;
            groupPlan.TemplateName = adminTemplate.Name;
            groupPlan.ViewName = adminViewDataRepository.GetViewName(profile.ViewStart);
            return groupPlan;
        }

        public void SetSerialize(bool serialize, string userId)
        {
            var profile = GetByUserId(userId);
            profile.SetSerialize(serialize);
            Update(profile);
        }

        public bool ExistSiteNumber(int siteNumber, string userId)
        {
            if (siteNumber < 111111111)
                return false;
            return db.UserRegisterProfile.Any(x => x.SiteNumber == siteNumber && x.IdUser != userId);
        }

        public bool ExistSiteName(string siteName, string userId)
        {
            if (siteName.Length < 4)
                return false;
            return db.UserRegisterProfile.Any(x => x.SiteName == siteName && x.IdUser != userId);
        }

        public bool ExistCnpj(string cnpj, string userId)
        {
            if (cnpj.Length < 18)
                return false;
            return db.UserRegisterProfile.Any(x => x.Cnpj == cnpj && x.IdUser != userId);
        }

        public bool ExistEmail(string email, string userId)
        {
            if (email.Length < 4)
                return false;
            return db.UserRegisterProfile.Any(x => x.Email == email && x.IdUser != userId);
        }

        public bool ExistEmpresa(string empresa, string userId)
        {
            if (empresa.Length < 4)
                return false;
            return db.UserRegisterProfile.Any(x => x.Empresa == empresa && x.IdUser != userId);
        }

        public bool ExistWebsite(string website, string userId)
        {
            if (website.Length < 10)
                return false;
            return db.UserRegisterProfile.Any(x => x.Cnpj == website && x.IdUser != userId);
        }

        public void DeleteProfileExtension(string userId)
        {
            var profile = GetByUserId(userId);

            // Delete User
            var userMenu = db.UserMenu.FirstOrDefault(x => x.IdUser == userId);
            db.UserMenu.Remove(userMenu);

            // Delete Config
            var configUserSlider = db.ConfigUserStyleClass.Where(x => x.IdUser == userId).ToList();
            db.ConfigUserStyleClass.RemoveRange(configUserSlider);

            var configUserView = db.ConfigUserView.Where(x => x.IdUser == userId).ToList();
            db.ConfigUserView.RemoveRange(configUserView);

            // Delete Appearance
            var appearance = db.ConfigUserAppearance.First(x => x.IdUser == userId);
            db.ConfigUserAppearance.Remove(appearance);

            // Delete Content
            var contentButton = db.ContentButton.Where(x => x.IdUser == userId).ToList();
            db.ContentButton.RemoveRange(contentButton);

            var contentIcon = db.ContentIcon.Where(x => x.IdUser == userId).ToList();
            db.ContentIcon.RemoveRange(contentIcon);

            var contentList = db.ContentList.Where(x => x.IdUser == userId).ToList();
            db.ContentList.RemoveRange(contentList);

            var contentText = db.ContentText.Where(x => x.IdUser == userId).ToList();
            db.ContentText.RemoveRange(contentText);

            var contentVideo = db.ContentVideo.Where(x => x.IdUser == userId).ToList();
            db.ContentVideo.RemoveRange(contentVideo);

            // Delete Component            
            var adminViewItem = db.AdminViewItem.Where(x => x.AdminViewData.AdminTemplate.TemplateCod == profile.TemplateCod)
                .Select(x => x.ViewTipo).Distinct().ToList();

            List<int> listImgType = new List<int>();
            listImgType.Add(1); // imagens da view
            listImgType.Add(2); // imagens de icon
            listImgType.Add(3); // imagens de logo

            foreach (var item in adminViewItem)
            {
                switch(item)
                {
                    case "Atividades":
                        var componentActivity = db.ComponentActivity.Where(x => x.IdUser == userId).ToList();
                        db.ComponentActivity.RemoveRange(componentActivity);
                       break;
                    case "Links":
                       var componentExtraLink = db.ComponentExtraLink.Where(x => x.IdUser == userId).ToList();
                       db.ComponentExtraLink.RemoveRange(componentExtraLink);
                       break;
                    case "Habilidades":
                       var componentSkill = db.ComponentSkill.Where(x => x.IdUser == userId).ToList();
                       db.ComponentSkill.RemoveRange(componentSkill);
                       break;
                    case "Ranking":
                       var componentFeatures = db.ComponentFeatures.Where(x => x.IdUser == userId).ToList();
                       db.ComponentFeatures.RemoveRange(componentFeatures);
                       break;
                    case "Planos":
                       var componentPricing = db.ComponentPricing.Where(x => x.IdUser == userId).ToList();
                       db.ComponentPricing.RemoveRange(componentPricing);
                       break;
                    case "FAQ":
                       var componentFaq = db.ComponentFaq.Where(x => x.IdUser == userId).ToList();
                       db.ComponentFaq.RemoveRange(componentFaq);
                       break;

                        // Componentes que possuem imagem
                    case "Clientes":
                       listImgType.Add(4);
                       var componentClient = db.ComponentClient.Where(x => x.IdUser == userId).ToList();
                       db.ComponentClient.RemoveRange(componentClient);
                       break;
                    case "Equipe":
                       listImgType.Add(5);
                       var componentTeam = db.ComponentTeam.Where(x => x.IdUser == userId).ToList();
                       db.ComponentTeam.RemoveRange(componentTeam);
                       break;
                    case "Marcas":
                       listImgType.Add(6);
                       var componentBrand = db.ComponentBrand.Where(x => x.IdUser == userId).ToList();
                       db.ComponentBrand.RemoveRange(componentBrand);
                       break;
                    case "Portfolio":
                       listImgType.Add(7);
                       var componentPortofolio = db.ComponentPortofolio.Where(x => x.IdUser == userId).ToList();
                       db.ComponentPortofolio.RemoveRange(componentPortofolio);
                       break;
                    case "Projetos":
                       listImgType.Add(8);
                       var componentProject = db.ComponentProject.Where(x => x.IdUser == userId).ToList();
                       db.ComponentProject.RemoveRange(componentProject);
                       break;
                    case "Post":
                       listImgType.Add(10);
                       var componentPost = db.ComponentPost.Where(x => x.IdUser == userId).ToList();
                       db.ComponentPost.RemoveRange(componentPost);
                       break;
                    case "Serviços":
                       listImgType.Add(11);
                       var componentService = db.ComponentService.Where(x => x.IdUser == userId).ToList();
                       db.ComponentService.RemoveRange(componentService);
                       break;
                    case "Menu":
                       listImgType.Add(13);
                       var componentMenu = db.ComponentMenu.Where(x => x.IdUser == userId).ToList();
                       db.ComponentMenu.RemoveRange(componentMenu);
                       break;                                           
                }                
            }

            // Delete Images
            var userImageGallery = db.UserImageGallery.Where(x => listImgType.Contains(x.FileType) && x.IdUser == userId).ToList();
            db.UserImageGallery.RemoveRange(userImageGallery);

            db.SaveChanges();        
        }       
        
    }
}
