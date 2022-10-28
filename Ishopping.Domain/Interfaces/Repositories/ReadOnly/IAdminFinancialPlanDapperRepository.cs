using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IAdminFinancialPlanDapperRepository
    {
        Task<AdminFinancialPlan> GetByCodAsync(int cod);
    }
}
