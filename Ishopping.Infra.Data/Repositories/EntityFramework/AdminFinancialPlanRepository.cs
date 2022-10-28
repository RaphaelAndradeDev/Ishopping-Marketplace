using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Ishopping.Infra.Data.Repositories
{
    public class AdminFinancialPlanRepository : RepositoryBase<AdminFinancialPlan>, IAdminFinancialPlanRepository
    {
        public AdminFinancialPlan GetByCod(int cod)
        {
            return db.AdminFinancialPlan.FirstOrDefault(x => x.Cod == cod);
        }
    }
}
