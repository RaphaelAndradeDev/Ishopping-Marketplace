using Ishopping.MVC.Models.Communs;
using Ishopping.MVC.ViewModels.User;
using System;

namespace Ishopping.ViewModels.Content
{
    public class ContentSliderViewModel : _SliderViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public int ViewCod { get; set; }
        public string ImageUrl { get; set; }
    }
}