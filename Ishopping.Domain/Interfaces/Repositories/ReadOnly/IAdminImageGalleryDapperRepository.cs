using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IAdminImageGalleryDapperRepository
    {
        IEnumerable<AdminImageGallery> GetAllByViewCod(int viewCod, int fileType);
        Task<IEnumerable<AdminImageGallery>> GetAllByViewCodAsync(int viewCod, int fileType);
    }
}
