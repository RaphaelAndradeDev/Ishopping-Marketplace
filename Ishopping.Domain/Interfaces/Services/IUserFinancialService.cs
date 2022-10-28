using Ishopping.Domain.Entities;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IUserFinancialService : IServiceBaseT2<UserFinancial>
    {
        UserFinancial GetByUserId(string userId);
        AdminFinancialPlan GetCurrentPlan(string userId);
        void Persist(UserFinancial userFinancial);
        Task<AdminFinancialPlan> GetCurrentPlanAsync(string userId);
    }
}
