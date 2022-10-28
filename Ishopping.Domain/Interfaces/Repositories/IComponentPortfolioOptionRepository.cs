using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentPortfolioOptionRepository : IRepositoryBaseT2<ComponentPortofolioOption>, IOptionRepositoryBaseT1<ComponentPortofolioOption>, IOptionRepositoryBaseT1Async<ComponentPortofolioOption>
    {        
    }
}
