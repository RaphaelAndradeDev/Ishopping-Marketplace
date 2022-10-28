using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Mvc.Serialization.Component;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.MVC.SectionModels.ComponentSerialize
{
    public class ComponentPostSectionModelSerialize 
    {        
        public bool ItemActive { get; private set; }
        public string ItemTitle { get; private set; }
        public string ItemSubTitle { get; private set; }
        public string ItemStTitle { get; private set; }
        public string ItemStSubTitle { get; private set; }
        public IEnumerable<ComponentPostSerialization> ListItens { get; private set; }
        public ComponentPostSectionModelSerialize(int siteNumber,
            IComponentPostAppService _componentPostAppService,
            IEnumerable<ConfigUserViewItem> viewItens)
        {           
            var item = viewItens.First(x => x.AdminViewItem.ViewTipo == "Post");
            this.ItemActive = item.Active;
            this.ItemTitle = item.TextView;
            this.ItemSubTitle = item.SubTitle;
            this.ItemStTitle = item.StTextView;
            this.ItemStSubTitle = item.StSubTitle;
                     
            if (item.Active)
            {
                var componentPost = _componentPostAppService.GetOrderByDate(siteNumber, 3);
                this.ListItens = Filter(Mapper.Map<IEnumerable<ComponentPost>, IEnumerable<ComponentPostSerialization>>(componentPost));
            }                     
            else
            {
                this.ListItens = new List<ComponentPostSerialization>();
            }               
        }

        private IEnumerable<ComponentPostSerialization> Filter(IEnumerable<ComponentPostSerialization> listComponentPost)
        {
            foreach (var item in listComponentPost)
            {
                if(item.Paragrafo1.Length > 160)
                   item.Paragrafo1 = item.Paragrafo1.Substring(0, 160) + " ...";
            }
            return listComponentPost;
        }
    }
}