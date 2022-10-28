using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System;
using System.Threading.Tasks;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class UserSerializeViewDataDapperRepository : Repository, IUserSerializeViewDataDapperRepository
    {
        public UserSerializeViewData GetBySiteNumber(int siteNumber, int viewCod)
        {
            string str = "SELECT *" +
              " FROM UserSerializeViewData" +
              " WHERE SiteNumber = @SiteNumber AND ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var userSerializeViewData = cn.QueryFirstOrDefault<UserSerializeViewData>(str, new { SiteNumber = siteNumber, ViewCod = viewCod });
                cn.Close();
                return userSerializeViewData;
            }
        }
                
        public void Persist(UserSerializeViewData userSerializeViewData)
        {
            using (var cn = IshoppingConnection)
            {

                if (userSerializeViewData.Id == Guid.Empty)
                {
                    cn.Open();
                    string sqlQuery = "INSERT INTO UserSerializeViewData(IdUser,SiteNumber,Serialize,ViewCod,IsBlock,IsMaintenance,LastChange) VALUES (@IdUser,@SiteNumber,@Serialize,@ViewCod,@IsBlock,@IsMaintenance,@LastChange)";
                    cn.Execute(sqlQuery,
                        new
                        {
                            userSerializeViewData.IdUser,
                            userSerializeViewData.SiteNumber,
                            userSerializeViewData.Serialize,
                            userSerializeViewData.ViewCod,
                            userSerializeViewData.IsBlock,
                            userSerializeViewData.IsMaintenance,
                            userSerializeViewData.LastChange                  
                        });
                    cn.Close();
                }
                else
                {
                    cn.Open();
                    string sqlQuery = "UPDATE UserSerializeViewData SET Serialize = @Serialize WHERE Id = @Id";
                    cn.Execute(sqlQuery, new {
                        userSerializeViewData.Serialize,
                        userSerializeViewData.Id
                    });
                    cn.Close();
                }
            }        
        }


        // Async Methods
        public async Task<UserSerializeViewData> GetBySiteNumberAsync(int siteNumber, int viewCod)
        {
            string str = "SELECT *" +
              " FROM UserSerializeViewData" +
              " WHERE SiteNumber = @SiteNumber AND ViewCod = @ViewCod";

            using (var cn = IshoppingConnection)
            {
                cn.Open();
                var userSerializeViewData = await cn.QueryFirstOrDefaultAsync<UserSerializeViewData>(str, new { SiteNumber = siteNumber, ViewCod = viewCod });
                cn.Close();
                return userSerializeViewData;
            }
        }
    }
}
