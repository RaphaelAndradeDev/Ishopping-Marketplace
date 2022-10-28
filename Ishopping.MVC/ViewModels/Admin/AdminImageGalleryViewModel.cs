using Ishopping.MVC.Models.Communs;

namespace Ishopping.MVC.ViewModels.Admin
{
    public class AdminImageGalleryViewModel : _GalleryViewModel
    {
        public int Id { get; set; }
        public int AdminViewDataId { get; set; }  
        public virtual AdminViewData_ViewModel AdminViewData { get; set; }
    }
}
