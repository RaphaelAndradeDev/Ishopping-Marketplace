using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Mvc.Serialization.Component;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.MVC.SectionModels.ComponentSerialize
{
    public class ComponentTeamSectionModelSerialize
    {
        private int _templateCod;
        private readonly IComponentTeamAppService _componentTeamAppService;
        public bool ItemActive { get; private set; }
        public string ItemTitle { get; private set; }
        public string ItemSubTitle { get; private set; }
        public string ItemStTitle { get; private set; }
        public string ItemStSubTitle { get; private set; }
        public IEnumerable<ComponentTeamSerialization> ListItens { get; private set; }
        public string[] Class { get; set; }

        public ComponentTeamSectionModelSerialize(int siteNumber, int templateCod,
            IComponentTeamAppService componentTeamAppService,
            IEnumerable<ConfigUserViewItem> viewItens)
        {          
            var item = viewItens.First(x => x.AdminViewItem.ViewTipo == "Equipe");
            this.ItemActive = item.Active;
            this.ItemTitle = item.TextView;
            this.ItemSubTitle = item.SubTitle;
            this.ItemStTitle = item.StTextView;
            this.ItemStSubTitle = item.StSubTitle;
            this._templateCod = templateCod;
            this._componentTeamAppService = componentTeamAppService;
            if (item.Active)
            {
                var componentTeam = AddAdminClass(componentTeamAppService.GetAllBySiteNumber(siteNumber));
                this.ListItens = Mapper.Map<IEnumerable<ComponentTeam>, IEnumerable<ComponentTeamSerialization>>(componentTeam);
            }                
            else
            {
                this.ListItens = new List<ComponentTeamSerialization>();
            }                
        }

        private IEnumerable<ComponentTeam> AddAdminClass(IEnumerable<ComponentTeam> listComponentTeam)
        {
            foreach (var item in listComponentTeam)
            {
                foreach (var sn in item.ComponentTeamSocialNetwork)
                {
                    var adminSn = _componentTeamAppService.GetAdminSocialNetworks(sn.Rede, _templateCod);
                    sn.AddAdminClass(adminSn.Classe1, adminSn.Classe2, adminSn.Classe3, adminSn.Classe4);
                }                
            }
            return listComponentTeam;
        }
    }
}