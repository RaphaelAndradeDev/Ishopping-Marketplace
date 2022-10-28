using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IConfigUserStyleClassService : IServiceBaseT2<ConfigUserStyleClass>
    {        
        ConfigUserStyleClass GetById(Guid id, string userId);
        ConfigUserStyleClass GetByClassName(string className, string userId);         
        IEnumerable<ConfigUserStyleClass> GetAllByUserId(string userId);
        void AddRanger(IEnumerable<ConfigUserStyleClass> configUserStyleClass);    
        void DeleteAll(string userId);

        // Async Methods
        Task<IEnumerable<string>> GetAllClassNameAsync(string userId);
        Task<ConfigUserStyleClass> GetByIdAsync(Guid id, string userId);
        Task<ConfigUserStyleClass> GetByClassNameAsync(string className, string userId);
        Task<IEnumerable<ConfigUserStyleClass>> GetAllByUserIdAsync(string userId);       
    }
}
