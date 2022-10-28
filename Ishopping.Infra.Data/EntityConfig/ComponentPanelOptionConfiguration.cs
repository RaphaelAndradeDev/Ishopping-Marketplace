using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentPanelOptionConfiguration : EntityTypeConfiguration<ComponentPanelOption>
    {
        public ComponentPanelOptionConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Title).IsRequired().HasMaxLength(64);
            Property(c => c.Text).IsRequired().HasMaxLength(64);
        }
    }
}
