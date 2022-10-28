
using System.Data.Entity.ModelConfiguration;
using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class SupportTransactionStatusConfiguration : EntityTypeConfiguration<SupportTransactionStatus>
    {
        public SupportTransactionStatusConfiguration()
        {
            HasKey(c => c.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
