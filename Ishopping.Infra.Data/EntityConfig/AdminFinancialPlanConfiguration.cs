using Ishopping.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class AdminFinancialPlanConfiguration : EntityTypeConfiguration<AdminFinancialPlan>
    {
        public AdminFinancialPlanConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}
