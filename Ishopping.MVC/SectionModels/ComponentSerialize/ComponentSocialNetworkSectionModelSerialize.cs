using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Mvc.Serialization.Component;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.MVC.SectionModels.ComponentSerialize
{
    public class ComponentSocialNetworkSectionModelSerialize 
    {
        private int _templateCod;
        private readonly IComponentSocialNetworkAppService _componentSocialNetworkAppService;
        public bool ItemActive { get; private set; }
        public string ItemTitle { get; private set; }
        public string ItemSubTitle { get; private set; }
        public string ItemStTitle { get; private set; }
        public string ItemStSubTitle { get; private set; }
        public IEnumerable<ComponentSocialNetworkSerialization> ListItens { get; private set; }

        public ComponentSocialNetworkSectionModelSerialize(int siteNumber, int templateCod,
            IComponentSocialNetworkAppService componentSocialNetworkAppService,       
            IEnumerable<ConfigUserViewItem> viewItens)
        {           
            var item = viewItens.First(x => x.AdminViewItem.ViewTipo == "Redes Sociais");
            this.ItemActive = item.Active;
            this.ItemTitle = item.TextView;
            this.ItemSubTitle = item.SubTitle;
            this.ItemStTitle = item.StTextView;
            this.ItemStSubTitle = item.StSubTitle;
            this._templateCod = templateCod;
            this._componentSocialNetworkAppService = componentSocialNetworkAppService;
            if (item.Active)
            {
                var componentSocialNetwork = AddAdminClass(componentSocialNetworkAppService.GetAllBySiteNumber(siteNumber));
                this.ListItens = Mapper.Map<IEnumerable<ComponentSocialNetwork>, IEnumerable<ComponentSocialNetworkSerialization>>(componentSocialNetwork);
            }
            else
            {
                this.ListItens = new List<ComponentSocialNetworkSerialization>();
            }
        }

        private IEnumerable<ComponentSocialNetwork> AddAdminClass(IEnumerable<ComponentSocialNetwork> listComponentSocialNetwork)
        {
            foreach (var item in listComponentSocialNetwork)
            {
                var adminSn = _componentSocialNetworkAppService.GetAdminSocialNetworks(item.Rede, _templateCod);
                item.AddAdminClass(adminSn.Classe1, adminSn.Classe2, adminSn.Classe3, adminSn.Classe4);
            }

            return listComponentSocialNetwork;
        }
    }
}