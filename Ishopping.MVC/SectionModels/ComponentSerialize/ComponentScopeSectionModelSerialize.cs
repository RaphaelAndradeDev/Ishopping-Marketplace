using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Mvc.Serialization.Component;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.MVC.SectionModels.ComponentSerialize
{
    public class ComponentScopeSectionModelSerialize
    {        
        public bool ItemActive { get; private set; }
        public string ItemTitle { get; private set; }
        public string ItemSubTitle { get; private set; }
        public string ItemStTitle { get; private set; }
        public string ItemStSubTitle { get; private set; }
        public IEnumerable<ComponentScopeSerialization> ListItens { get; private set; }
        public string[,] Class { get; private set; }

        public ComponentScopeSectionModelSerialize(int siteNumber,
            IComponentScopeAppService componentScopeAppService,
            IEnumerable<ConfigUserViewItem> viewItens)
        {           
            var item = viewItens.First(x => x.AdminViewItem.ViewTipo == "Escopo");
            this.ItemActive = item.Active;
            this.ItemTitle = item.TextView;
            this.ItemSubTitle = item.SubTitle;
            this.ItemStTitle = item.StTextView;
            this.ItemStSubTitle = item.StSubTitle;
            if (item.Active)
            {
                var componentScope = componentScopeAppService.GetAllBySiteNumber(siteNumber);
                this.ListItens = Mapper.Map<IEnumerable<ComponentScope>, IEnumerable<ComponentScopeSerialization>>(componentScope);
            }
            else
            {
                this.ListItens = new List<ComponentScopeSerialization>();
            }
        }      
    }
}