using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ConfigUserDisplayConfiguration : EntityTypeConfiguration<ConfigUserDisplay>
    {
        public ConfigUserDisplayConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Specific).IsRequired().HasMaxLength(256);
            Property(p => p.SemanticFull).IsRequired().HasMaxLength(256);
            Property(p => p.AddressFull).IsRequired().HasMaxLength(256);
            Property(p => p.SiteName).IsRequired().HasMaxLength(128);           
        }
    }
}
