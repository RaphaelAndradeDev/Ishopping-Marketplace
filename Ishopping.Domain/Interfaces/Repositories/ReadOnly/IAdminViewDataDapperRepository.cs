using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IAdminViewDataDapperRepository
    {
        AdminViewData GetByViewCod(int viewCod);
        Task<AdminViewData> GetByViewCodAsync(int viewCod);
        Task<AdminViewData> GetListImageAsync(int templateCod, int viewCod);
    }
}
