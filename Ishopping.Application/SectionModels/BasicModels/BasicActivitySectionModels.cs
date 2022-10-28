using AutoMapper;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Application.SectionModels.BasicModels
{
    public class BasicActivitySectionModels
    {
        public bool ItemActive { get; private set; }
        public string ItemTitle { get; private set; }
        public string ItemSubTitle { get; private set; }
        public IEnumerable<BasicActivity> ListItens { get; private set; }

        public BasicActivitySectionModels(int siteNumber,
            IComponentActivityService componentActivityService,
            IEnumerable<BasicUserViewItem> viewItens)
        {
            var item = viewItens.First(x => x.ViewTypeCod == 21);
            this.ItemActive = item.Active;
            this.ItemTitle = item.TextView;
            this.ItemSubTitle = item.SubTitle;    
            if (item.Active)
            {
                var componentActivity = componentActivityService.GetAllBySiteNumber(siteNumber);
                this.ListItens = Mapper.Map<IEnumerable<ComponentActivity>, IEnumerable<BasicActivity>>(componentActivity);
            }
            else
            {
                this.ListItens = new List<BasicActivity>();
            }
        }
    }
}
