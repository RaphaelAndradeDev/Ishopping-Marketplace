using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentServiceOptionConfiguration : EntityTypeConfiguration<ComponentServiceOption>
    {
        public ComponentServiceOptionConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Title).IsRequired().HasMaxLength(64);
            Property(c => c.Description).IsRequired().HasMaxLength(64);
        }
    }
}
