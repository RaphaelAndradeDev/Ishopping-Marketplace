using AutoMapper;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Application.SectionModels.BasicModels
{
    public class BasicPostSectionModels
    {
        public bool ItemActive { get; private set; }
        public string ItemTitle { get; private set; }
        public string ItemSubTitle { get; private set; }    
        public IEnumerable<SimplePost> ListItens { get; private set; }

        public async Task<BasicPostSectionModels> Execute(int siteNumber, IComponentPostService _componentPostService, IEnumerable<BasicUserViewItem> viewItens)
        {
            var sectionModels = new BasicPostSectionModels();                      

            var item = viewItens.First(x => x.ViewTypeCod == 30);
            sectionModels.ItemActive = item.Active;
            sectionModels.ItemTitle = item.TextView;
            sectionModels.ItemSubTitle = item.SubTitle;

            if (item.Active)
            {
                sectionModels.ListItens = Filter(await _componentPostService.GetAllBySiteNumberAsync(siteNumber, 3));
            }
            else
            {
                ListItens = new List<SimplePost>();
            }
            return sectionModels;
        }

        private IEnumerable<SimplePost> Filter(IEnumerable<SimplePost> listComponentPost)
        {
            foreach (var item in listComponentPost)
            {
                if (item.Paragrafo1.Length > 160)
                    item.Paragrafo1 = item.Paragrafo1.Substring(0, 160) + " ...";
            }
            return listComponentPost;
        }
    }
}
