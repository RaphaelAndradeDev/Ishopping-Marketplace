
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IConfigUserStyleClassDapperRepository
    {
        Task<IEnumerable<string>> GetAllClassNameAsync(string userId);
    }
}
