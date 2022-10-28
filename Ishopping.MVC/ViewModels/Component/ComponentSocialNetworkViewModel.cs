using Ishopping.MVC.Models.Communs;
using System;

namespace Ishopping.MVC.ViewModels.Component
{
    public class ComponentSocialNetworkViewModel : _SocialNetworkViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public string Link { get; set; }     
    }
}
