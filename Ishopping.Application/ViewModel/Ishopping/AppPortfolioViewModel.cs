using Ishopping.Application.SectionModels.BasicModels;
using Ishopping.Application.SectionModels.Content;
using Ishopping.Application.SectionModels.User;
using Ishopping.Domain.ApplicationClass;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Application.ViewModel.Ishopping
{
    public class AppPortfolioViewModel
    {        
        public string Link { get; private set; }
        public IEnumerable<SimplePortfolio> Portfolio { get; private set; }    

        public AppPortfolioViewModel(IEnumerable<SimplePortfolio> simplePortfolio, string link = "")
        {
            Link = link;
            Portfolio = PortfolioFilter(simplePortfolio);
        }

        private IEnumerable<SimplePortfolio> PortfolioFilter(IEnumerable<SimplePortfolio> simplePortfolios)
        {
            return simplePortfolios.OrderBy(x => Guid.NewGuid());
        }
    }

    public class AppPortfolioMainViewModel
    {
        public IEnumerable<TextModels> Texts { get; private set; }
        public IEnumerable<ButtonModels> Buttons { get; private set; }
        public IEnumerable<VideoModels> Videos { get; private set; }
        public IEnumerable<string> Images { get; private set; }
        public BasicActivitySectionModels ComponentActivity { get; private set; }
        public BasicPostSectionModels ComponentPost { get; private set; }
        public ProfileContact ProfileContact { get; private set; }

        public string PortfolioTitle { get; private set; }
        public string PortfolioSubTitle { get; private set; }
        public IEnumerable<SimplePortfolio> PortfolioHead { get; private set; }
        public IEnumerable<SimplePortfolio> PortfolioChild { get; private set; }

        public AppPortfolioMainViewModel(ContentTextSectionModel contentTextSectionModel, ContentButtonSectionModel contentButtonSectionModel, ContentVideoSectionModel contentVideoSectionModel, UserImageGallerySectionModel userImageGallerySectionModel, BasicActivitySectionModels basicActivitySectionModels, BasicPostSectionModels basicPostSectionModels, IEnumerable<SimplePortfolio> simplePortfolios, BasicUserViewItem portfolioUserViewItem, ProfileContact profileContact)
        {
            Texts = contentTextSectionModel.ListText;
            Buttons = contentButtonSectionModel.ListButton;
            Videos = contentVideoSectionModel.ListVideo;
            ComponentActivity = basicActivitySectionModels;
            ComponentPost = basicPostSectionModels;
            Images = userImageGallerySectionModel.ListImage;
            ProfileContact = profileContact;

            PortfolioTitle = portfolioUserViewItem.TextView;
            PortfolioSubTitle = portfolioUserViewItem.SubTitle;
            PortfolioHead = PortfolioHeadFilter(simplePortfolios);
            PortfolioChild = PortfolioChildFilter(simplePortfolios);
        }

        private IEnumerable<SimplePortfolio> PortfolioHeadFilter(IEnumerable<SimplePortfolio> simplePortfolios)
        {
            // Só pode ter no máximo 4 categorias 
            // Deve ter no máximo 8 itens
            // De preferência devem ser aleatórios

            List<string> categorys = simplePortfolios.Where(x => x.PortfolioHead == true).OrderBy(x => x.Category).Distinct().Select(x => x.Category).Take(4).ToList();

            if (categorys.Count() == 0)
                return new List<SimplePortfolio>();

            var portfolio = simplePortfolios.Where(x => x.PortfolioHead == true && categorys.Contains(x.Category)).OrderBy(y => Guid.NewGuid()).Take(8).ToList();

            if (portfolio.Count() < 8)
            {
                var portfolioChild = simplePortfolios.Where(x => x.PortfolioHead == false).OrderBy(y => Guid.NewGuid()).Take(9).ToList();

                int i = 0;
                while (portfolio.Count < 8 && i < portfolioChild.Count)
                {
                    portfolio.Add(portfolioChild[i]);
                    i++;
                }
            }
            return portfolio;
        }

        private IEnumerable<SimplePortfolio> PortfolioChildFilter(IEnumerable<SimplePortfolio> simplePortfolios)
        {
            var portfolioChild = simplePortfolios.Where(x => x.PortfolioHead == false).OrderByDescending(y => y.PortfolioChild == true).Take(9).ToList();

            if (portfolioChild.Count() < 9)
            {
                var portfolio = simplePortfolios.Where(x => x.PortfolioHead == true).OrderBy(y => Guid.NewGuid()).ToList();

                int i = 0;
                while (portfolio.Count < 9 && i < portfolio.Count)
                {
                    portfolioChild.Add(portfolio[i]);
                    i++;
                }
            }
            return portfolioChild;
        }
    }
    
    public class AppPortfolioCategoryViewModel
    {
        public IEnumerable<TextModels> Texts { get; private set; }
        public IEnumerable<ButtonModels> Buttons { get; private set; }   
        public ProfileContact ProfileContact { get; private set; }

        public string PortfolioTitle { get; private set; }
        public string PortfolioSubTitle { get; private set; }
        public IEnumerable<SimplePortfolio> PortfolioHead { get; private set; }
        public IEnumerable<SimplePortfolio> PortfolioChild { get; private set; }

        public AppPortfolioCategoryViewModel(ContentTextSectionModel contentTextSectionModel, ContentButtonSectionModel contentButtonSectionModel, IEnumerable<SimplePortfolio> simplePortfolios, ProfileContact profileContact)
        {
            Texts = contentTextSectionModel.ListText;
            Buttons = contentButtonSectionModel.ListButton;
            ProfileContact = profileContact;                 
            PortfolioHead = PortfolioHeadFilter(simplePortfolios);
            PortfolioChild = PortfolioChildFilter(simplePortfolios);
        }

        private IEnumerable<SimplePortfolio> PortfolioHeadFilter(IEnumerable<SimplePortfolio> simplePortfolios)
        {
            var portfolio = simplePortfolios.Where(x => x.PortfolioHead == true);
            if(portfolio.Count() == 0)
                portfolio = simplePortfolios.OrderByDescending(x => x.PortfolioHead == true);
            return portfolio;
        }

        private IEnumerable<SimplePortfolio> PortfolioChildFilter(IEnumerable<SimplePortfolio> simplePortfolios)
        {
            return simplePortfolios.Where(x => x.PortfolioHead == false && x.PortfolioChild == true).Take(9);
        }
    }

    public class AppPortfolioSubCategoryViewModel
    {
        public IEnumerable<TextModels> Texts { get; private set; }
        public IEnumerable<ButtonModels> Buttons { get; private set; }
        public ProfileContact ProfileContact { get; private set; }

        public string PortfolioTitle { get; private set; }
        public string PortfolioSubTitle { get; private set; }
        public IEnumerable<SimplePortfolio> PortfolioHead { get; private set; }
        public IEnumerable<SimplePortfolio> PortfolioChild { get; private set; }

        public AppPortfolioSubCategoryViewModel(ContentTextSectionModel contentTextSectionModel, ContentButtonSectionModel contentButtonSectionModel, IEnumerable<SimplePortfolio> simplePortfolios, ProfileContact profileContact)
        {
            Texts = contentTextSectionModel.ListText;
            Buttons = contentButtonSectionModel.ListButton;
            ProfileContact = profileContact;
            PortfolioHead = PortfolioHeadFilter(simplePortfolios);
            PortfolioChild = PortfolioChildFilter(simplePortfolios);
        }

        private IEnumerable<SimplePortfolio> PortfolioHeadFilter(IEnumerable<SimplePortfolio> simplePortfolios)
        {            
            var portfolio = simplePortfolios.Where(x => x.PortfolioHead == false && x.PortfolioChild == true);
            if (portfolio.Count() == 0)
                portfolio = simplePortfolios.OrderByDescending(x => x.PortfolioHead == false && x.PortfolioChild == true);
            return portfolio;
        }

        private IEnumerable<SimplePortfolio> PortfolioChildFilter(IEnumerable<SimplePortfolio> simplePortfolios)
        {
            return simplePortfolios.Where(x => x.PortfolioHead == false && x.PortfolioChild == false).Take(9);
        }
    }

    public class AppPortfolioItemViewModel
    {
        public IEnumerable<TextModels> Texts { get; private set; }
        public IEnumerable<ButtonModels> Buttons { get; private set; }
        public ProfileContact ProfileContact { get; private set; }

        public string PortfolioTitle { get; private set; }
        public string PortfolioSubTitle { get; private set; }
        public SimplePortfolio PortfolioHead { get; private set; }
        public IEnumerable<SimplePortfolio> PortfolioChild { get; private set; }

        public AppPortfolioItemViewModel(ContentTextSectionModel contentTextSectionModel, ContentButtonSectionModel contentButtonSectionModel, IEnumerable<SimplePortfolio> simplePortfolios, SimplePortfolio simplePortfolio, ProfileContact profileContact)
        {
            Texts = contentTextSectionModel.ListText;
            Buttons = contentButtonSectionModel.ListButton;
            ProfileContact = profileContact;
            PortfolioHead = simplePortfolio;
            PortfolioChild = PortfolioChildFilter(simplePortfolios);
        }        

        private IEnumerable<SimplePortfolio> PortfolioChildFilter(IEnumerable<SimplePortfolio> simplePortfolios)
        {
            return simplePortfolios.OrderBy(x => Guid.NewGuid()).Take(9);
        }
    }
}
