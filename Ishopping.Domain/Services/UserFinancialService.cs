using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class UserFinancialService : ServiceBaseT2<UserFinancial>, IUserFinancialService
    {
        private readonly IUserFinancialRepository _userFinancialRepository;
        private readonly IUserFinancialDapperRepository _userFinancialDapperRepository;

        public UserFinancialService(
            IUserFinancialRepository userFinancialRepository,
            IUserFinancialDapperRepository userFinancialDapperRepository)
            :base(userFinancialRepository)
        {
            _userFinancialRepository = userFinancialRepository;
            _userFinancialDapperRepository = userFinancialDapperRepository;
        }

        public UserFinancial GetByUserId(string userId)
        {
            return _userFinancialRepository.GetByUserId(userId);
        }
        
        public AdminFinancialPlan GetCurrentPlan(string userId)
        {
            return _userFinancialRepository.GetCurrentPlan(userId);
        }
        
        public void Persist(UserFinancial userFinancial)
        {
            _userFinancialDapperRepository.Persist(userFinancial);
        }


        // Async Methods
        public async Task<AdminFinancialPlan> GetCurrentPlanAsync(string userId)
        {
            return await _userFinancialRepository.GetCurrentPlanAsync(userId);
        }
    }
}
