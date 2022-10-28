using Ishopping.Domain.ApplicationClass;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IUserImageGalleryDapperRepository
    {
        int CountImg(int fileType, string userId);
        void SetImageCheck(IEnumerable<AdminImageChecked> adminImageChecked);
        Task<int> CountImgAsync(int fileType, string userId);
        Task<BasicImage> GetImageByViewCod(int viewCod, int fileType, int position, int siteNumber);
    }
}
