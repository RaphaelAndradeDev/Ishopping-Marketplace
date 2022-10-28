using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ConfigUserStyleClassService : ServiceBaseT2<ConfigUserStyleClass>, IConfigUserStyleClassService
    {
        private readonly IConfigUserStyleClassRepository _configUserStyleClassRepository;
        private readonly IConfigUserStyleClassDapperRepository _configUserStyleClassDapperRepository;

        public ConfigUserStyleClassService(
            IConfigUserStyleClassRepository configUserStyleClassRepository,
            IConfigUserStyleClassDapperRepository configUserStyleClassDapperRepository)
            : base(configUserStyleClassRepository)
        {
            _configUserStyleClassRepository = configUserStyleClassRepository;
            _configUserStyleClassDapperRepository = configUserStyleClassDapperRepository;
        }

        public void AddRanger(IEnumerable<ConfigUserStyleClass> configUserStyleClass)
        {
            _configUserStyleClassRepository.AddRanger(configUserStyleClass);
        }

        public ConfigUserStyleClass GetById(Guid id, string userId)
        {
            return _configUserStyleClassRepository.GetById(id, userId);
        }
        
        public IEnumerable<ConfigUserStyleClass> GetAllByUserId(string userId)
        {
            return _configUserStyleClassRepository.GetAllByUserId(userId);
        }
        
        public void DeleteAll(string userId)
        {
            _configUserStyleClassRepository.DeleteAll(userId);
        }
        
        public ConfigUserStyleClass GetByClassName(string className, string userId)
        {
            return _configUserStyleClassRepository.GetByClassName(className, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> GetAllClassNameAsync(string userId)
        {
            return await _configUserStyleClassDapperRepository.GetAllClassNameAsync(userId);
        }       

        public async Task<ConfigUserStyleClass> GetByClassNameAsync(string className, string userId)
        {
            return await _configUserStyleClassRepository.GetByClassNameAsync(className, userId);
        }

        public async Task<IEnumerable<ConfigUserStyleClass>> GetAllByUserIdAsync(string userId)
        {
            return await _configUserStyleClassRepository.GetAllByUserIdAsync(userId);
        } 
               
        public async Task<ConfigUserStyleClass> GetByIdAsync(Guid id, string userId)
        {
            return await _configUserStyleClassRepository.GetByIdAsync(id, userId);
        }

           

    }
}
