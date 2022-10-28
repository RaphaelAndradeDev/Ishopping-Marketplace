
using System.Data.Entity.ModelConfiguration;
using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class SupportTransactionConfiguration : EntityTypeConfiguration<SupportTransaction>
    {
        public SupportTransactionConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
