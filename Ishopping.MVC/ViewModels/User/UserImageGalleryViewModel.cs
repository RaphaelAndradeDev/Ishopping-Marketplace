using Ishopping.MVC.Models.Communs;
using System;

namespace Ishopping.MVC.ViewModels.User
{
    public class UserImageGalleryViewModel : _GalleryViewModel
    {
        public Guid Id { get; set; }
        public string IdUser { get; set; }
        public int SiteNumber { get; set; }

        // Checagem 
        public bool Checked { get; private set; }
        public bool IsBlock { get; private set; }
    }
}
