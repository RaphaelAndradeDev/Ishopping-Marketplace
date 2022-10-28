using Dapper;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Infra.Data.Repositories.Dapper.Commun;
using System;
using System.Collections.Generic;

namespace Ishopping.Infra.Data.Repositories.Dapper
{
    public class UserFinancialHistoryDapperRepository : Repository, IUserFinancialHistoryDapperRepository
    {
        public void Persist(UserFinancialHistory userFinancialHistory, bool insert)
        {       
            if(userFinancialHistory.Group == 0)
            {
                Guid id = GetId(userFinancialHistory);

                if (id == Guid.Empty)
                {
                    userFinancialHistory.Id = Guid.Empty;
                    AddFinancialHistory(userFinancialHistory);
                }                        
                else
                {                   
                    userFinancialHistory.Id = id;
                    UpdateFinancialHistory(userFinancialHistory);
                }                        
            }
            else
            {
                if (insert)
                {
                    AddFinancialHistory(userFinancialHistory);
                }
                else
                {
                    UpdateFinancialHistory(userFinancialHistory);
                }
            }                       
        }

        public void SetHistoryBlock(IEnumerable<Guid> id)
        {
            using (var cn = IshoppingConnection)
            {
                cn.Open();
                string sqlQuery = "UPDATE UserFinancialHistory SET IsBlock = 1 WHERE Id = @Id";
                cn.Execute(sqlQuery, new { Id = id });
                cn.Close();
            }
        }


        // Private Methods
        private Guid GetId(UserFinancialHistory userFinancialHistory)
        {
            using (var cn = IshoppingConnection)
            {
                string str = "SELECT Id" +
                      " FROM UserFinancialHistory" +
                      " WHERE UserFinancialId = @UserFinancialId AND [Group] = 0";

                cn.Open();
                Guid id = cn.ExecuteScalar<Guid>(str, new { UserFinancialId = userFinancialHistory.UserFinancialId });
                cn.Close();
                return id;
            }
        }

        private void AddFinancialHistory(UserFinancialHistory userFinancialHistory)
        {
            using (var cn = IshoppingConnection)
            {
                userFinancialHistory.Id = Guid.NewGuid();                
                string sqlQuery = "INSERT INTO UserFinancialHistory (Id,[Group],Company,[Date],Status,LastChange,PlanValue,Discount,Payment,AddDayToPlan,DueDate,UserFinancialId,AdminFinancialPlanId,IsBlock) VALUES (@Id,@Group,@Company,@Date,@Status,@LastChange,@PlanValue,@Discount,@Payment,@AddDayToPlan,@DueDate,@UserFinancialId,@AdminFinancialPlanId,@IsBlock)";

                cn.Open();
                cn.Execute(sqlQuery,
                    new
                    {
                        userFinancialHistory.Id,
                        userFinancialHistory.Group,
                        userFinancialHistory.Company,
                        userFinancialHistory.Date,
                        userFinancialHistory.Status,
                        userFinancialHistory.LastChange,
                        userFinancialHistory.PlanValue,
                        userFinancialHistory.Discount,
                        userFinancialHistory.Payment,
                        userFinancialHistory.AddDayToPlan,
                        userFinancialHistory.DueDate,
                        userFinancialHistory.UserFinancialId,
                        userFinancialHistory.AdminFinancialPlanId,
                        userFinancialHistory.IsBlock
                    });
                cn.Close();
            }
        }

        private void UpdateFinancialHistory(UserFinancialHistory userFinancialHistory)
        {
            using (var cn = IshoppingConnection)
            {
                string sqlQuery = "UPDATE UserFinancialHistory SET [Group] = @Group, Company = @Company, [Date] = @Date, Status = @Status, LastChange = @LastChange, PlanValue = @PlanValue, Discount = @Discount, Payment = @Payment, AddDayToPlan = @AddDayToPlan, DueDate = @DueDate, AdminFinancialPlanId = @AdminFinancialPlanId, IsBlock = @IsBlock WHERE Id = @Id";

                cn.Open();
                cn.Execute(sqlQuery,
                   new
                   {
                       userFinancialHistory.Group,
                       userFinancialHistory.Company,
                       userFinancialHistory.Date,
                       userFinancialHistory.Status,
                       userFinancialHistory.LastChange,
                       userFinancialHistory.PlanValue,
                       userFinancialHistory.Discount,
                       userFinancialHistory.Payment,
                       userFinancialHistory.AddDayToPlan,
                       userFinancialHistory.DueDate,
                       userFinancialHistory.AdminFinancialPlanId,
                       userFinancialHistory.IsBlock,
                       userFinancialHistory.Id                     
                   });
                cn.Close();
            }
        }
    }
}
