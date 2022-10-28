using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class AdminFinancialPlanService : ServiceBase<AdminFinancialPlan>, IAdminFinancialPlanService
    {
        private readonly IAdminFinancialPlanRepository _adminFinancialPlanRepository;
        private readonly IAdminFinancialPlanDapperRepository _adminFinancialPlanDapperRepository;

        public AdminFinancialPlanService(
            IAdminFinancialPlanRepository adminFinancialPlanRepository,
            IAdminFinancialPlanDapperRepository adminFinancialPlanDapperRepository)
            : base(adminFinancialPlanRepository)
        {
            _adminFinancialPlanRepository = adminFinancialPlanRepository;
            _adminFinancialPlanDapperRepository = adminFinancialPlanDapperRepository;
        }
        
        public AdminFinancialPlan GetByCod(int cod)
        {
            return _adminFinancialPlanRepository.GetByCod(cod);
        }


        public async Task<AdminFinancialPlan> GetByCodAsync(int cod)
        {
            return await _adminFinancialPlanDapperRepository.GetByCodAsync(cod);
        }
    }
}
