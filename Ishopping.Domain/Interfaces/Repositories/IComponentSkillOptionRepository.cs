using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentSkillOptionRepository : IRepositoryBaseT2<ComponentSkillOption>, IOptionRepositoryBaseT1<ComponentSkillOption>, IOptionRepositoryBaseT1Async<ComponentSkillOption>
    {        
    }
}
