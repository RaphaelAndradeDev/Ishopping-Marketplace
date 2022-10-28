using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IUserFinancialRepository : IRepositoryBaseT2<UserFinancial>
    {
        UserFinancial GetByUserId(string userId);
        AdminFinancialPlan GetCurrentPlan(string userId);
        Task<AdminFinancialPlan> GetCurrentPlanAsync(string userId);
    }
}
