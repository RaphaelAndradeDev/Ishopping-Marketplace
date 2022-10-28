using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Mvc.Serialization.Component;
using Ishopping.Ninject.Modules;
using Ninject;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.MVC.SectionModels.ComponentSerialize
{
    public class ComponentPortofolioSectionModelSerialize 
    {        
        public bool ItemActive { get; private set; }
        public string ItemTitle { get; private set; }
        public string ItemSubTitle { get; private set; }
        public string ItemStTitle { get; private set; }
        public string ItemStSubTitle { get; private set; }
        public IEnumerable<string> ListCategory { get; private set; }
        public IEnumerable<ComponentPortofolioSerialization> ListItens { get; private set; }        

        public ComponentPortofolioSectionModelSerialize(int siteNumber,
            IComponentPortofolioAppService componentPortofolioAppService,
            IEnumerable<ConfigUserViewItem> viewItens)
        {            
            var item = viewItens.First(x => x.AdminViewItem.ViewTipo == "Portfolio");
            this.ItemActive = item.Active;
            this.ItemTitle = item.TextView;
            this.ItemSubTitle = item.SubTitle;
            this.ItemStTitle = item.StTextView;
            this.ItemStSubTitle = item.StSubTitle;
            if (item.Active)
            {
                var componentPortofolio = componentPortofolioAppService.GetAllBySiteNumber(siteNumber);
                this.ListItens = Mapper.Map<IEnumerable<ComponentPortofolio>, IEnumerable<ComponentPortofolioSerialization>>(componentPortofolio);
            }
            else
            {
                this.ListItens = new List<ComponentPortofolioSerialization>();
            }
        }
    }
}