using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class AdminFinancialPlanAppService : AppServiceBase<AdminFinancialPlan>, IAdminFinancialPlanAppService
    {
        private readonly IAdminFinancialPlanService _adminFinancialPlanService;

        public AdminFinancialPlanAppService(IAdminFinancialPlanService adminFinancialPlanService)
            :base(adminFinancialPlanService)
        {
            _adminFinancialPlanService = adminFinancialPlanService;
        }

        public async Task<AdminFinancialPlan> GetByCodAsync(int cod)
        {
            return await _adminFinancialPlanService.GetByCodAsync(cod);
        }
    }
}
