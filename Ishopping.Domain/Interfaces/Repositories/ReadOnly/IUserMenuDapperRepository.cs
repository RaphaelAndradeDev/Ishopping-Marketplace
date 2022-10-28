using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IUserMenuDapperRepository
    {
        UserMenu GetBySiteNumber(int siteNumber);
        Task<UserMenu> GetBySiteNumberAsync(int siteNumber); 
    }
}
