using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IComponentActivityOptionService : IServiceBaseT2<ComponentActivityOption>, IOptionServiceBaseT1<ComponentActivityOption>, IOptionServiceBaseT1Async<ComponentActivityOption>
    {        
        void StyleReplace(string userId, string name, string replace);
        void StyleRemove(string userId, string name);
        void UpdateAll(IEnumerable<ComponentActivityOption> componentActivityOption);
        Task<ComponentActivityOption> PutAsync(string userId, string styleTitle, string styleDescription);        
    }
}
