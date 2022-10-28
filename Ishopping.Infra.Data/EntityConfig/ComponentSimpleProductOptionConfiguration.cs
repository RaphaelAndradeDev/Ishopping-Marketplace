using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentSimpleProductOptionConfiguration : EntityTypeConfiguration<ComponentSimpleProductOption>
    {
        public ComponentSimpleProductOptionConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsRequired().HasMaxLength(64);
            Property(c => c.Category).IsRequired().HasMaxLength(64);
            Property(c => c.Brand).IsRequired().HasMaxLength(64);
            Property(c => c.Model).IsRequired().HasMaxLength(64);
            Property(c => c.Description).IsRequired().HasMaxLength(64);
            Property(c => c.Price).IsRequired().HasMaxLength(64);
        }
    }
}
