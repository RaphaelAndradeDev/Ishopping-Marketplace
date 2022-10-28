using Ishopping.Common.Constants;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories
{
    public class UserFinancialHistoryRepository : RepositoryBaseT2<UserFinancialHistory>, IUserFinancialHistoryRepository
    {
        public UserFinancialHistory GetBy(Guid id)
        {
            return db.UserFinancialHistory.Include("UserFinancial").FirstOrDefault(x => x.Id == id);
        }

        public DateTime? GetDueDate(string userId)
        {
            var listFinancialHistory = db.UserFinancialHistory.Include("UserFinancial")
                .Where(x => x.UserFinancial.IdUser == userId && 
                (x.Status == (int)ConstantFinancial.Transaction.Approved ||
                 x.Status == (int)ConstantFinancial.Transaction.Deducted)||
                 x.Status == (int)ConstantFinancial.Transaction.Warranted).ToList();

            var history = listFinancialHistory.OrderBy(x => x.LastChange).LastOrDefault();

            if (history != null)
            {
                if (history.Group != 0)
                {
                    var financialHistory = listFinancialHistory.Where(x => x.Group == history.Group).ToList();
                    return financialHistory.LastOrDefault().DueDate;
                }
            }           
            
            return null;        
        }

        public IEnumerable<UserFinancialHistory> GetAllDueDate()
        {
            return db.UserFinancialHistory.Include("UserFinancial").Where(x => x.IsBlock == false && (x.Status == (int)ConstantFinancial.Transaction.Approved || x.Status == (int)ConstantFinancial.Transaction.Deducted));
        }

        // Async Methods
        public async Task<UserFinancialHistory> GetByAsync(Guid id)
        {
            return await db.UserFinancialHistory.Include("UserFinancial").Include("AdminFinancialPlan").FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
