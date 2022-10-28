using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Mvc.Serialization.Component;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.MVC.SectionModels.ComponentSerialize
{
    public class ComponentSimpleProductSectionModelSerialize
    {        
        public bool ItemActive { get; private set; }
        public string ItemTitle { get; private set; }
        public string ItemSubTitle { get; private set; }
        public string ItemStTitle { get; private set; }
        public string ItemStSubTitle { get; private set; }
        public IEnumerable<ComponentSimpleProductSerialization> ListItens { get; private set; }
        public string[,] Class { get; private set; }

        public ComponentSimpleProductSectionModelSerialize(int siteNumber,
            IComponentSimpleProductAppService componentSimpleProductAppService,
            IEnumerable<ConfigUserViewItem> viewItens)
        {           
            var item = viewItens.First(x => x.AdminViewItem.ViewTipo == "Produto");
            ItemActive = item.Active;
            ItemTitle = item.TextView;
            ItemSubTitle = item.SubTitle;
            ItemStTitle = item.StTextView;
            ItemStSubTitle = item.StSubTitle;
            if (item.Active)
            {
                var componentSimpleProduct = componentSimpleProductAppService.GetAllBySiteNumber(siteNumber);
                ListItens = Mapper.Map<IEnumerable<ComponentSimpleProduct>, IEnumerable<ComponentSimpleProductSerialization>>(componentSimpleProduct);     
            }
            else
            {
                ListItens = new List<ComponentSimpleProductSerialization>();
            }
        }      
    }
}