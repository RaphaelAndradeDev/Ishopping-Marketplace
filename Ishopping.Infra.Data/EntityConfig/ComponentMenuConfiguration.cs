using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentMenuConfiguration : EntityTypeConfiguration<ComponentMenu>
    {
        public ComponentMenuConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentMenuOption>(x => x.ComponentMenuOption)
                .WithMany(x => x.ComponentMenu)
                .HasForeignKey(x => x.ComponentMenuOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Title).IsRequired().HasMaxLength(64);
            Property(c => c.Category).IsOptional().HasMaxLength(64);
            Property(c => c.Description).IsOptional().HasMaxLength(512);
            Property(c => c.DayOfWeek).IsOptional().HasMaxLength(32);
        }
    }
}
