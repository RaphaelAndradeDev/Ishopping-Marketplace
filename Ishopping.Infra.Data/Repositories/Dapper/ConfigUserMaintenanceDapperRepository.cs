using Dapper;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ConfigUserMaintenanceDapperRepository : Repository, IConfigUserMaintenanceDapperRepository
    {
        public void RemoveMaintenance()
        {
            using (var cn = IshoppingConnection)
            {
                cn.Open();
                string sqlQuery = "UPDATE ConfigUserMaintenance SET IsMaintenance = 0 WHERE GETDATE() > DateReturn AND IsMaintenance = 1";
                cn.Execute(sqlQuery);
                cn.Close();
            }
        }
    }
}
