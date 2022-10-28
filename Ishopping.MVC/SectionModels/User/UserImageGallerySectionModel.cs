using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.SectionModels.User
{
    public class UserImageGallerySectionModel
    {
        private readonly IUserImageGalleryAppService _userImageGallery;
        private readonly IAdminImageGalleryAppService _adminImageGallery;

        public List<string> ListImage { get; private set; }

        private int _siteNumber;
        private int _viewCod;
        private int _fileType;
        private AdminViewData _viewData;

        public UserImageGallerySectionModel(int siteNumber, 
            IUserImageGalleryAppService userImageGallery,
            IAdminImageGalleryAppService adminImageGallery,
            int fileType, int viewCod, 
            AdminViewData adminViewData)
        {
            this._siteNumber = siteNumber;
            this._fileType = fileType;
            this._viewCod = viewCod;
            this._viewData = adminViewData;

            _userImageGallery = userImageGallery;
            _adminImageGallery = adminImageGallery;

            this.ListImage = listImage();
        }

        private List<string> listImage()
        {
            int ps = 0;
            List<string> list = new List<string>();
            var adminImg = new List<AdminImageGallery>();

            switch(_fileType)
            {
                case 1:
                    ps = _viewData.ListImage;
                    break;
                case 2:
                    ps = _viewData.ListIconPng;
                    break;
                case 3:
                    ps = _viewData.ListLogo;
                    break;             
            }           

            string[] fileName = new string[ps];

            var listImg = _userImageGallery.GetAllBySiteNumber(_siteNumber, _fileType).ToList();

            for (int i = 0; i < ps; i++)
            {
                fileName[i] = listImg.Where(x => x.Position == i + 1).Select(x => x.Folder.ToString() + "/" + x.FileName).FirstOrDefault();
                if (fileName[i] != null) { list.Add(fileName[i]); }
                else
                {
                    if (adminImg.Count == 0)
                    {
                        adminImg = _adminImageGallery.GetAllByViewCod(_viewCod, _fileType).ToList();
                        list.Add(adminImg.Where(b => b.Position == i + 1).Select(x => x.Folder.ToString() + "/" + x.FileName).FirstOrDefault());
                    }
                    else
                    {
                        list.Add(adminImg.Where(b => b.Position == i + 1).Select(x => x.Folder.ToString() + "/" + x.FileName).FirstOrDefault());
                    }
                }
            }
            return list;
        }
    }
}