using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IAdminFinancialPlanAppService : IAppServiceBase<AdminFinancialPlan>
    {
        Task<AdminFinancialPlan> GetByCodAsync(int cod);
    }
}
