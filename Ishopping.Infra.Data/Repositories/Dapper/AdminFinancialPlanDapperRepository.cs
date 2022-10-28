using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class AdminFinancialPlanDapperRepository : Repository, IAdminFinancialPlanDapperRepository
    {
        public async Task<AdminFinancialPlan> GetByCodAsync(int cod)
        {
            string str = "SELECT *" +
             " FROM AdminFinancialPlan" +
             " WHERE Cod = @Cod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var adminFinancialPlan = await cn.QueryFirstAsync<AdminFinancialPlan>(str, new { Cod = cod });
                cn.Close();
                return adminFinancialPlan;
            }
        }
    }
}
