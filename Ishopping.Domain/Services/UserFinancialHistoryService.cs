using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class UserFinancialHistoryService : ServiceBaseT2<UserFinancialHistory>, IUserFinancialHistoryService
    {
        private readonly IUserFinancialHistoryRepository _userFinancialHistoryRepository;
        private readonly IUserFinancialHistoryDapperRepository _userFinancialHistoryDapperRepository;

        public UserFinancialHistoryService(
            IUserFinancialHistoryRepository userFinancialHistoryRepository,
            IUserFinancialHistoryDapperRepository userFinancialHistoryDapperRepository)
            :base(userFinancialHistoryRepository)
        {
            _userFinancialHistoryRepository = userFinancialHistoryRepository;
            _userFinancialHistoryDapperRepository = userFinancialHistoryDapperRepository;
        }
               
        public UserFinancialHistory GetBy(System.Guid id)
        {
            return _userFinancialHistoryRepository.GetBy(id);
        }

        public DateTime? GetDueDate(string userId)
        {
            return _userFinancialHistoryRepository.GetDueDate(userId);
        }

        public IEnumerable<UserFinancialHistory> GetAllDueDate()
        {
            return _userFinancialHistoryRepository.GetAllDueDate();
        }

        public void SetHistoryBlock(IEnumerable<Guid> id)
        {
            _userFinancialHistoryDapperRepository.SetHistoryBlock(id);
        }

        public void Persist(UserFinancialHistory userFinancialHistory, bool insert)
        {
            _userFinancialHistoryDapperRepository.Persist(userFinancialHistory, insert);
        }

        // Async Methods
        public async Task<UserFinancialHistory> GetByAsync(Guid id)
        {
            return await _userFinancialHistoryRepository.GetByAsync(id);
        }       
      
    }
}
