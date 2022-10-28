using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Application.SectionModels.User
{
    public class UserImageGallerySectionModel
    {
        private readonly IUserImageGalleryService _userImageGallery;
        private readonly IAdminImageGalleryService _adminImageGallery;

        public List<string> ListImage { get; private set; }

        private int _siteNumber;
        private int _viewCod;
        private int _fileType;  
        private AdminViewData _viewData;

        public UserImageGallerySectionModel(int siteNumber,
            IUserImageGalleryService userImageGallery,
            IAdminImageGalleryService adminImageGallery,
            int fileType, int viewCod,
            AdminViewData adminViewData)
        {
            _siteNumber = siteNumber;
            _fileType = fileType;
            _viewCod = viewCod;
            _viewData = adminViewData;

            _userImageGallery = userImageGallery;
            _adminImageGallery = adminImageGallery;

            ListImage = GetListImage();
        }

        public UserImageGallerySectionModel(int siteNumber,
        IUserImageGalleryService userImageGallery,
        IAdminImageGalleryService adminImageGallery,
        int fileType, int viewCod, int listImage)
        {
            _siteNumber = siteNumber;
            _fileType = fileType;
            _viewCod = viewCod;     

            _userImageGallery = userImageGallery;
            _adminImageGallery = adminImageGallery;

            ListImage = GetListImage(listImage);
        }

        private List<string> GetListImage()
        {
            int ps = 0;
            List<string> list = new List<string>();
            var adminImg = new List<AdminImageGallery>();

            switch (_fileType)
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

        private List<string> GetListImage(int listImage)
        {          
            List<string> list = new List<string>();
            var adminImg = new List<AdminImageGallery>();   

            string[] fileName = new string[listImage];

            var listImg = _userImageGallery.GetAllBySiteNumber(_siteNumber, _fileType).ToList();

            for (int i = 0; i < listImage; i++)
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
