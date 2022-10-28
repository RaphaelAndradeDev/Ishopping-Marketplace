using Ishopping.Models;
using Ishopping.MVC.ViewModels.User;
using System.Collections.Generic;

namespace Ishopping.ViewModels.ImageGallery
{
    public class ImageT1ViewModel
    {
        public IEnumerable<UserImageGalleryViewModel> UserImageGalleryViewModel { get; private set; }
        public Serialize Serialize { get; private set; }

        public ImageT1ViewModel(IEnumerable<UserImageGalleryViewModel> userImageGalleryViewModel, Serialize serialize)
        {
            this.UserImageGalleryViewModel = userImageGalleryViewModel;
            this.Serialize = serialize;
        }
    }
}