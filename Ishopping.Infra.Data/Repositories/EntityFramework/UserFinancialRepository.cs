using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Ishopping.Infra.Data.Repositories
{
    public class UserFinancialRepository : RepositoryBaseT2<UserFinancial>, IUserFinancialRepository
    {
        public UserFinancial GetByUserId(string userId)
        {
            return db.UserFinancial.Include("UserFinancialHistory.AdminFinancialPlan").First(x => x.IdUser == userId);
        }

        public AdminFinancialPlan GetCurrentPlan(string userId)
        {
            return db.UserFinancial.Include("UserFinancialHistory.AdminFinancialPlan").FirstOrDefault(x => x.IdUser == userId).UserFinancialHistory.OrderBy(x => x.Date).Last().AdminFinancialPlan;            
        }
           
        // Async Methods
        public async Task<AdminFinancialPlan> GetCurrentPlanAsync(string userId)
        {
            var financial = await db.UserFinancial.Include("UserFinancialHistory.AdminFinancialPlan").FirstOrDefaultAsync(x => x.IdUser == userId);
            return financial.UserFinancialHistory.OrderBy(x => x.Date).Last().AdminFinancialPlan;
        }
    }
}
