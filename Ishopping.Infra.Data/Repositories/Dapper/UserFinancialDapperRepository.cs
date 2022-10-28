using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class UserFinancialDapperRepository : Repository, IUserFinancialDapperRepository
    {
        public void Persist(UserFinancial userFinancial)
        {
            using (var cn = IshoppingConnection)
            {
                if (userFinancial.Id == Guid.Empty)
                {
                    cn.Open();
                    string sqlQuery = "INSERT INTO UserFinancial(IdUser,SiteNumber,Name,Email,AreaCod,Phone,Cpf) VALUES (@IdUser,@SiteNumber,@Name,@Email,@AreaCod,@Phone,@Cpf)";
                    cn.Execute(sqlQuery,
                        new
                        {
                            userFinancial.IdUser,
                            userFinancial.SiteNumber,
                            userFinancial.Name,
                            userFinancial.Email,
                            userFinancial.AreaCod,
                            userFinancial.Phone,
                            userFinancial.Cpf                                               
                        });
                    cn.Close();                    
                }
                else
                {
                    cn.Open();
                    string sqlQuery = "UPDATE UserFinancial SET Name = @Name, Email = @Email, AreaCod = @AreaCod, Phone = @Phone, Cpf = @Cpf WHERE IdUser = @IdUser";
                    cn.Execute(sqlQuery,
                    new
                    {                                              
                        userFinancial.Name,
                        userFinancial.Email,
                        userFinancial.AreaCod,
                        userFinancial.Phone,
                        userFinancial.Cpf,
                        userFinancial.IdUser
                    });
                    cn.Close(); 
                }
            }
        }
    }
}
