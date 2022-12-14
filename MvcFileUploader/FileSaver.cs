
using MvcFileUploader.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MvcFileUploader
{
    public class FileSaver
    {        
        public static List<ViewDataUploadFileResult> StoreFiles(IEnumerable<MvcFileSave> mvcFiles)
        {        
            return mvcFiles.Select(x => StoreFile(delegate(MvcFileSave f)
                                                      {
                                                          if (f == null) throw new ArgumentNullException("MvcFileSave");
                                                          f = x;
                                                      })).ToList();
        }

        public static ViewDataUploadFileResult StoreFile(Action<MvcFileSave> action)
        {
            var mvcFile = new MvcFileSave();        
            action(mvcFile);           
            ViewDataUploadFileResult status; 
            
            var dirInfo = new DirectoryInfo(mvcFile.StorageDirectory);
            var file = mvcFile.File;
            var fileNameWithoutPath = Path.GetFileName(mvcFile.File.FileName);
            var fileExtension = Path.GetExtension(fileNameWithoutPath);
            var fileName = Path.GetFileNameWithoutExtension(Path.GetFileName(mvcFile.File.FileName));
            int genName = mvcFile.GenName;
            var genFileName =  genName + fileExtension;// get filename if set
            var fullPath = Path.Combine(mvcFile.StorageDirectory, genFileName);            

            try
            {                
                var viewDataUploadFileResult = new ViewDataUploadFileResult()
                {
                    name = fileNameWithoutPath,
                    SavedFileName = genFileName,
                    size = file.ContentLength,
                    type = file.ContentType,
                    url = mvcFile.UrlPrefix + "/" + genFileName,
                    //delete_url = Url.Action("DeleteFile", new { fileUrl = "/"+storageRoot+"/" + genFileName }),
                    //thumbnail_url = thumbUrl + "?width=100",
                    deleteType = "POST",
                    Title = fileName,

                    //for controller use
                    FullPath = dirInfo.FullName + "/" + genFileName
                };

                //add delete url                           
                mvcFile.AddFileUriParamToDeleteUrl("fileUrl", viewDataUploadFileResult.url);
                viewDataUploadFileResult.deleteUrl = mvcFile.DeleteUrl;
                

                status = viewDataUploadFileResult;   

                mvcFile.File.SaveAs(fullPath);
            }
            catch (Exception exc)
            {
                if (mvcFile.ThrowExceptions)
                    throw;
                
                status = new ViewDataUploadFileResult()
                             {
                                 error = exc.Message,
                                 name = file.FileName,
                                 size = file.ContentLength,
                                 type = file.ContentType 
                             };
            }

            return status;
        } 
    
    
    } 
    
}
