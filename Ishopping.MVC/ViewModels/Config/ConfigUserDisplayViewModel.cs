using Ishopping.MVC.ViewModels.User;
using System;

namespace Ishopping.MVC.ViewModels.Config
{
    public class ConfigUserDisplayViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public int DisplayValue { get; set; }
        public int DisplayCount { get; set; }
        public bool Maintenance { get; set; }
        public bool Blocked { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string _Latitude { get { return Latitude.ToString().Replace(",","."); } }
        public string _Longitude { get { return Longitude.ToString().Replace(",", "."); } }

        // Relacionamentos       
        public string ImageGalleryId { get; set; }
        public virtual UserImageGalleryViewModel UserImageGallery { get; set; }
    }
}
