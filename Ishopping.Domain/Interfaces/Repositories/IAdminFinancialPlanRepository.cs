using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IAdminFinancialPlanRepository : IRepositoryBase<AdminFinancialPlan>
    {
        AdminFinancialPlan GetByCod(int cod);
    }
}
