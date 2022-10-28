using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentClientOptionConfiguration : EntityTypeConfiguration<ComponentClientOption>
    {
        public ComponentClientOptionConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsRequired().HasMaxLength(64);
            Property(c => c.Functio).IsRequired().HasMaxLength(64);
            Property(c => c.Comment).IsRequired().HasMaxLength(64);
            Property(c => c.Projects).IsRequired().HasMaxLength(64);
        }
    }
}
