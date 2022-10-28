using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentPanelConfiguration : EntityTypeConfiguration<ComponentPanel>
    {
        public ComponentPanelConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentPanelOption>(x => x.ComponentPanelOption)
                .WithMany(x => x.ComponentPanel)
                .HasForeignKey(x => x.ComponentPanelOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Title).IsRequired().HasMaxLength(64);
            Property(c => c.Text).IsRequired().HasMaxLength(512);
            Property(c => c.Icon).IsOptional().HasMaxLength(32);
        }
    }
}
