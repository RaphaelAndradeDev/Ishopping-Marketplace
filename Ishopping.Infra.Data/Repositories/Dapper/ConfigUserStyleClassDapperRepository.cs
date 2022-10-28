using Dapper;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class ConfigUserStyleClassDapperRepository : Repository, IConfigUserStyleClassDapperRepository
    {
        string noClass = "SemEstilo";
        public async Task<IEnumerable<string>> GetAllClassNameAsync(string userId)
        {
            string str = "SELECT ClassName" +
              " FROM ConfigUserStyleClass" +
              " WHERE IdUser = @IdUser AND ClassName <> @NoClass";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                IEnumerable<string> className = await cn.QueryAsync<string>(str, new { IdUser = userId, NoClass = noClass });
                cn.Close();
                return className;
            }
        }
    }
}
