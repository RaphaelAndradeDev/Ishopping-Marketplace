using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IAdminFinancialPlanService : IServiceBase<AdminFinancialPlan>
    {
        AdminFinancialPlan GetByCod(int cod);
        Task<AdminFinancialPlan> GetByCodAsync(int cod);
    }
}
