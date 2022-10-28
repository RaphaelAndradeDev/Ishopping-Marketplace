using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Ishopping.Domain.Services
{
    public class UserSerializeViewDataService : ServiceBaseT2<UserSerializeViewData>, IUserSerializeViewDataService
    {
        private readonly IUserSerializeViewDataRepository _userSerializeViewDataRepository;
        private readonly IUserSerializeViewDataDapperRepository _userSerializeViewDataDapperRepository;

        public UserSerializeViewDataService(
            IUserSerializeViewDataRepository userRegisterProfileRepository,
            IUserSerializeViewDataDapperRepository userRegisterProfileDapperRepository)
            :base(userRegisterProfileRepository)
        {
            _userSerializeViewDataRepository = userRegisterProfileRepository;
            _userSerializeViewDataDapperRepository = userRegisterProfileDapperRepository;
        }

        public UserSerializeViewData GetBySiteNumber(int siteNumber, int viewCod)
        {
            return _userSerializeViewDataDapperRepository.GetBySiteNumber(siteNumber, viewCod);
        }

        public IEnumerable<UserSerializeViewData> GetAllBySiteNumber(int siteNumber)
        {
            return _userSerializeViewDataRepository.GetAllBySiteNumber(siteNumber);
        }

        public void Persist(UserSerializeViewData userSerializeViewData)
        {
            _userSerializeViewDataDapperRepository.Persist(userSerializeViewData);
        }                                       

        public UserSerializeViewData GetByUserId(string userId, int viewCod)
        {
            return _userSerializeViewDataRepository.GetByUserId(userId, viewCod);
        }

        public IEnumerable<UserSerializeViewData> GetAllByUserId(string userId)
        {
            return _userSerializeViewDataRepository.GetAllByUserId(userId);
        }          

        public void RemoveAll(int siteNumber)
        {
            _userSerializeViewDataRepository.RemoveAll(siteNumber);
        }


        // Async Methods
        public async Task<UserSerializeViewData> GetBySiteNumberAsync(int siteNumber, int viewCod)
        {
            return await _userSerializeViewDataDapperRepository.GetBySiteNumberAsync(siteNumber, viewCod);
        }   
    }
}
