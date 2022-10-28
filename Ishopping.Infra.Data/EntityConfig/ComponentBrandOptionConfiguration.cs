using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentBrandOptionConfiguration : EntityTypeConfiguration<ComponentBrandOption>
    {
        public ComponentBrandOptionConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Marca).IsRequired().HasMaxLength(64);
            Property(c => c.Comment).IsRequired().HasMaxLength(64);
        }
    }
}
