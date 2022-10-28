﻿using AutoMapper;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Mvc.Serialization.Component;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.MVC.SectionModels.ComponentSerialize
{
    public class ComponentSkillSectionModelSerialize
    {        
        public bool ItemActive { get; private set; }
        public string ItemTitle { get; private set; }
        public string ItemSubTitle { get; private set; }
        public string ItemStTitle { get; private set; }
        public string ItemStSubTitle { get; private set; }
        public IEnumerable<ComponentSkillSerialization> ListItens { get; private set; }

        public ComponentSkillSectionModelSerialize(int siteNumber, 
            IComponentSkillAppService componentSkillAppService,
            IEnumerable<ConfigUserViewItem> viewItens)
        {          
            var item = viewItens.First(x => x.AdminViewItem.ViewTipo == "Habilidades");
            this.ItemActive = item.Active;
            this.ItemTitle = item.TextView;
            this.ItemSubTitle = item.SubTitle;
            this.ItemStTitle = item.StTextView;
            this.ItemStSubTitle = item.StSubTitle;
            if (item.Active)
            {
                var componentSkill = componentSkillAppService.GetAllBySiteNumber(siteNumber);
                this.ListItens = Mapper.Map<IEnumerable<ComponentSkill>, IEnumerable<ComponentSkillSerialization>>(componentSkill);
            }
            else
            {
                this.ListItens = new List<ComponentSkillSerialization>();
            }
        }    
    }
}