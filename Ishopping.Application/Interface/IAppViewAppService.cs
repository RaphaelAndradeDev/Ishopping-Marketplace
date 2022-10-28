using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Application.Interface
{
    public interface IAppViewAppService : IAppServiceBase<AppView>
    {
        IEnumerable<AppView> GetAllByType(int type);
    }
}
