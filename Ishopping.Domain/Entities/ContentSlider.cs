using Ishopping.Domain.Communs;
using System;

namespace Ishopping.Domain.Entities
{
    public class ContentSlider : _Slider
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public int ViewCod { get; set; }
        public string StyleClass { get; set; }
        public string ImageUrl { get; set; }
    }
}
