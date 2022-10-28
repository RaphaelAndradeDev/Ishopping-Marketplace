using AutoMapper;
using ImageResizer;
using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Models;
using Ishopping.ViewModels.User;
using Microsoft.AspNet.Identity;
using MvcFileUploader;
using MvcFileUploader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ishopping.MVC.Controllers
{
    
     public class ImgUploadController : Controller
    {
        private readonly IAdminViewDataAppService _adminViewData;
        private readonly IAdminImageGalleryAppService _adminImageGallery;      
        private readonly IUserRegisterProfileAppService _userRegisterProfile;
        private readonly IUserImageGalleryAppService _userImageGallery;

        public ImgUploadController(
            IAdminViewDataAppService adminViewData,
            IAdminImageGalleryAppService adminImageGallery, 
            IUserRegisterProfileAppService userRegisterProfile,
            IUserImageGalleryAppService userImageGallery)
        {
            _adminViewData = adminViewData;
            _adminImageGallery = adminImageGallery;
            _userRegisterProfile = userRegisterProfile;
            _userImageGallery = userImageGallery;
        }        

        [CustomAuthorizeAttribute(Roles = "ExProfile")]
        public async Task<ActionResult> ImageUpLoad(int fileType, int viewCod = 0)
        {           
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetBasicProfileAsync(userId);
            if (!profile.ExistItem(ConvertToViewType(fileType))) return HttpNotFound();

            var imgResponse = await _userImageGallery.FileUploadAsync(userId, fileType, profile.TemplateCod, viewCod);
            if (!imgResponse.Validade || imgResponse.ImageQuantity == 0) return HttpNotFound();

            var imgResponseViewModel = Mapper.Map<ImageGalleryResponse, ImageGalleryResponseViewModel>(imgResponse);
            return View(imgResponseViewModel);
        }
                 

        // ################ Admin #####################################################

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult AdminUploadFileImg(int id)
        {
            ViewBag.ViewDataId = id;
            return View();
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult AdminUploadFilePng(int id)
        {
            ViewBag.ViewDataId = id;
            return View();
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult AdminUploadFileLogo(int id)
        {
            ViewBag.ViewDataId = id;
            return View();
        }

        [Authorize(Roles = "AdminLevel1, AdminLevel2")]
        public ActionResult AdminUploadFileSlider(int id)
        {
            ViewBag.ViewDataId = id;
            return View();
        } 

		public async Task<ActionResult> UploadFile( int entityId, int viewCod = 0) 
        {       
            string userId = User.Identity.GetUserId();
            var profile = await _userRegisterProfile.GetByUserIdAsync(userId);            

            string fileName = string.Empty;
            Random rnd = new Random();                                    
            var statuses = new List<ViewDataUploadFileResult>();
            var listImage = new List<UserImageGallery>();
            var listPath = new List<String>();

            try
            {
                for (var i = 0; i < Request.Files.Count; i++)
                {
                    var st = FileSaver.StoreFile(x =>
                    {                                                         
                        x.File = Request.Files[i];
                        int rndName = rnd.Next(1000000000, 2145483647) + x.File.ContentLength;
                        var fileNameWithoutPath = Path.GetFileName(x.File.FileName);
                        var fileExtension = Path.GetExtension(fileNameWithoutPath);

                        x.DeleteUrl = Url.Action("DeleteFile", new { entityId = entityId });
                        x.StorageDirectory = Server.MapPath("~/Content/uploads");
                        x.UrlPrefix = "/Content/uploads/" + profile.SiteNumber;
                        fileName = rndName + fileExtension;
                        x.FileName = fileName;
                        x.GenName = rndName;
                        x.ThrowExceptions = true;                                               
                    });
                    var imgResponse = await _userImageGallery.FileUploadAsync(userId, entityId, profile.TemplateCod, viewCod);
                    if (imgResponse.MaxImageQuantity > 0)
                    {
                        var ig = new UserImageGallery(userId, profile.SiteNumber, viewCod, fileName, entityId, profile.SiteNumber, 0);
                        listImage.Add(ig);
                        statuses.Add(st);
                    }   
                    else
                    {
                        throw new InvalidOperationException();
                    }
                } 
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ImgUploadController", "UploadFileT1", profile.SiteNumber.ToString());
            }       
               
            Dictionary<string, string> versions = new Dictionary<string, string>();
            switch (entityId)
            {
                case 1: 
                    // views
                    versions.Add("", "maxwidth=1600&maxheight=1067&format=jpg");
                    break;
                case 2:
                    // icones
                    versions.Add("", "maxwidth=160&maxheight=160&format=jpg");
                    break;
                case 3:
                    // logo
                    versions.Add("", "maxwidth=280&maxheight=160&format=jpg");
                    break;
                case 4: 
                    // cliente
                    versions.Add("", "maxwidth=320&maxheight=320&format=jpg");
                    break;
                case 5: 
                    // equipe
                    versions.Add("", "maxwidth=320&maxheight=320&format=jpg");
                    break;
                case 6: 
                    // marca
                    versions.Add("", "maxwidth=320&maxheight=320&format=jpg");
                    break;
                case 7:
                    // portofolio
                    versions.Add("", "maxwidth=600&maxheight=600&format=jpg");
                    versions.Add("_tb", "width=100&height=100&crop=auto&format=jpg");
                    versions.Add("_m", "maxwidth=400&maxheight=400format=jpg");
                    versions.Add("_l", "maxwidth=900&maxheight=900&format=jpg");
                    break;
                case 8:
                    // projetos
                    versions.Add("", "maxwidth=600&maxheight=600&format=jpg");
                    break;
                case 9: 
                    // produtos
                    versions.Add("", "maxwidth=600&maxheight=600&format=jpg");
                    break;
                case 10: 
                    // post
                    versions.Add("", "maxwidth=700&maxheight=450&format=jpg");
                    break;
                case 11: 
                    // serviços
                    versions.Add("", "maxwidth=280&maxheight=280&format=jpg");
                    break;
                case 12:
                    // cartão de visita
                    versions.Add("", "maxwidth=340&maxheight=194&format=jpg");
                    break;
                case 13:
                    // menu
                    versions.Add("", "maxwidth=280&maxheight=280&format=jpg");
                    break;
                case 14:
                    // thumbnail
                    versions.Add("", "maxwidth=180&maxheight=180&format=jpg");
                    break;
                case 15:
                    // apresentação
                    versions.Add("", "maxwidth=600&maxheight=600&format=jpg");
                    break;
                case 16:
                    // slider
                    versions.Add("", "maxwidth=900&maxheight=900&format=jpg");
                    break;
                default:                
                    versions.Add("", "maxwidth=600&maxheight=600&format=jpg");
                    break;
            }

            try
            {
                foreach (var item in statuses)
                {                                                    
                    // novo codigo
                    GenerateVersions(versions, item.FullPath, "~/Content/uploads/" + profile.SiteNumber + "/" + item.SavedFileName);

                    // codigo antigo
                    //ResizeSettings resizeSettings = new ResizeSettings();
                    //resizeSettings.MaxWidth = maxWidth;
                    //resizeSettings.MaxHeight = maxHeight;
                    //resizeSettings.Quality = 90;
                    //ImageJob imageJob = new ImageJob(item.FullPath, "~/Content/uploads/" + profile.SiteNumber + "/" + item.SavedFileName, resizeSettings);
                    //imageJob.CreateParentDirectory = true;
                    //imageJob.Build();

                    listPath.Add(item.FullPath);
                }
            }
            catch (Exception ex) 
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ImgUploadController", "UploadFileT2", profile.SiteNumber.ToString());
            }

            _userImageGallery.AddRanger(listImage);   
  
            // set serialize
            if(entityId <= 3)
            {
                profile.SetSerialize(true);
                _userRegisterProfile.Update(profile);
            }

            //adding thumbnail url for jquery file upload javascript plugin                     
            statuses.ForEach(x => x.thumbnailUrl = x.url + "?width=160&height=160"); // uses ImageResizer httpmodule to resize images from this url        

            //setting custom download url instead of direct url to file which is default
            statuses.ForEach(x => x.url = Url.Action("DownloadFile", new { fileUrl = x.url, mimetype = x.type }));   

            var viewresult = Json(new {files = statuses});
            //for IE8 which does not accept application/json
            if (Request.Headers["Accept"] != null && !Request.Headers["Accept"].Contains("application/json"))
                viewresult.ContentType = "text/plain";
            try
            {
                foreach (var item in listPath)
                {
                    System.IO.File.Delete(item);
                }
            }
            catch (Exception ex) 
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ImgUploadController", "UploadFileT3", profile.SiteNumber.ToString());
            }
                  
            return viewresult;
        }

        public ActionResult AdminUploadFile(int entityId, int id)
        {        
            int folder = _adminViewData.GetById(id).ViewCod;

            string fileName;
            Random rnd = new Random();
            var statuses = new List<ViewDataUploadFileResult>();
            var listImage = new List<AdminImageGallery>();
            var listPath = new List<String>();

            try
            {
                for (var i = 0; i < Request.Files.Count; i++)
                {
                    var st = FileSaver.StoreFile(x =>
                    {
                        x.File = Request.Files[i];
                        int rndName = rnd.Next(1000000000, 2145483647) + x.File.ContentLength;
                        var fileNameWithoutPath = Path.GetFileName(x.File.FileName);
                        var fileExtension = Path.GetExtension(fileNameWithoutPath);

                        x.DeleteUrl = Url.Action("DeleteFile", new { entityId = entityId });
                        x.StorageDirectory = Server.MapPath("~/Content/uploads");
                        x.UrlPrefix = "/Content/uploads/" + folder;
                        fileName = rndName + fileExtension;
                        x.FileName = fileName;
                        x.GenName = rndName;
                        x.ThrowExceptions = true;             

                        AdminImageGallery ig = new AdminImageGallery(id, folder, fileName, entityId, folder, 0);               
                        listImage.Add(ig);
                    });
                    statuses.Add(st);
                }

            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ImgUploadController", "AdminUploadFileT1");
            }

            int maxWidth, maxHeight;
            switch (entityId)
            {
                case 1:
                    maxWidth = 1920; maxHeight = 1280;      // views
                    break;
                case 2:
                    maxWidth = 160; maxHeight = 160;        // icones
                    break;
                case 3:
                    maxWidth = 350; maxHeight = 225;        // logo
                    break;                
                default:
                    maxWidth = 700; maxHeight = 450;
                    break;
            }

            try
            {
                foreach (var item in statuses)
                {
                    ResizeSettings resizeSettings = new ResizeSettings();
                    resizeSettings.MaxWidth = maxWidth;
                    resizeSettings.MaxHeight = maxHeight;
                    resizeSettings.Quality = 90;

                    ImageJob imageJob = new ImageJob(item.FullPath, "~/Content/uploads/" + folder + "/" + item.SavedFileName, resizeSettings);
                    imageJob.CreateParentDirectory = true;
                    imageJob.Build();

                    listPath.Add(item.FullPath);
                }
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ImgUploadController", "AdminUploadFileT2");
            }           

            _adminImageGallery.AddRanger(listImage);

            //adding thumbnail url for jquery file upload javascript plugin                     
            statuses.ForEach(x => x.thumbnailUrl = x.url + "?width=160&height=160"); // uses ImageResizer httpmodule to resize images from this url        

            //setting custom download url instead of direct url to file which is default
            statuses.ForEach(x => x.url = Url.Action("DownloadFile", new { fileUrl = x.url, mimetype = x.type }));         

            var viewresult = Json(new { files = statuses });
            //for IE8 which does not accept application/json
            if (Request.Headers["Accept"] != null && !Request.Headers["Accept"].Contains("application/json"))
                viewresult.ContentType = "text/plain";
            try
            {
                foreach (var item in listPath)
                {
                    System.IO.File.Delete(item);
                }
            }
            catch (Exception ex)
            {
                LogError.WhiteError(GetPathToLogError(), ex.ToString(), "ImgUploadController", "AdminUploadFileT3");
            }
        
            return viewresult;
        }
        
        [HttpPost] // should accept only post
        public ActionResult DeleteFile(string fileUrl)
        {
            string[] sizes = new string[8] { "", "_tb", "_xs", "_s", "_xm", "_m", "_xl", "_l" };
            var filePath = Server.MapPath(fileUrl);

            string directory = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string fileExt = Path.GetExtension(filePath);

            foreach (var size in sizes)
            {
                string path = Path.Combine(directory, fileName + size + fileExt);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }

            _userImageGallery.Remove(_userImageGallery.GetByFileName(fileName + fileExt));                     

            var viewresult = Json(new { error = String.Empty });
            //for IE8 which does not accept application/json
            if (Request.Headers["Accept"] != null && !Request.Headers["Accept"].Contains("application/json"))
                viewresult.ContentType = "text/plain"; 

            return viewresult; // trigger success
        }

        public ActionResult DownloadFile(string fileUrl, string mimetype)
        {
            var filePath = Server.MapPath(fileUrl);

            if (System.IO.File.Exists(filePath))
                return File(filePath, mimetype);
            else
            {
                return new HttpNotFoundResult("File not found");
            }
        }

        private string GetPathToLogError()
        {
            string userPath = "~/Content/uploads/1101";
            return Server.MapPath(userPath);
        }

        private string ConvertToViewType(int fileType)
        {
            switch (fileType)
            {
                case 1:
                    return "img_11";
                case 2:
                    return "img_12";
                case 3:
                    return "img_13";
                case 4:
                    return "img_23";
                case 5:
                    return "img_36";
                case 6:
                    return "img_22";
                case 7:
                    return "img_29";
                case 8:
                    return "img_32";
                case 9:
                    return "img_40";
                case 10:
                    return "img_30";
                case 11:
                    return "img_33";
                case 12:
                    return "ever";       
                case 13:
                    return "img_27";
                case 14:
                    return "img_37";
                case 15:
                    return "img_38";
                case 16:
                    return "img_16";           
                default:
                    return string.Empty;
            }
        }

        public IList<string> GenerateVersions(Dictionary<string, string> versions, string pathSource, string pathDest)
        {
            string basePath = ImageResizer.Util.PathUtils.RemoveExtension(pathDest);

            //To store the list of generated paths
            List<string> generatedFiles = new List<string>();

            //Generate each version
            foreach (string suffix in versions.Keys)
                //Let the image builder add the correct extension based on the output file type
                generatedFiles.Add(ImageBuilder.Current.Build(pathSource, basePath + suffix,
                  new ResizeSettings(versions[suffix]), false, true));

            return generatedFiles;
        }

    }
}
