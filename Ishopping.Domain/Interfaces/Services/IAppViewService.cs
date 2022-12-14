using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IAppViewService : IServiceBase<AppView>
    {
        IEnumerable<AppView> GetAllByType(int type);
    }
}
