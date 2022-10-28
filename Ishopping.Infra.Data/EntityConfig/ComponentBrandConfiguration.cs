using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentBrandConfiguration : EntityTypeConfiguration<ComponentBrand>
    {
        public ComponentBrandConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentBrandOption>(x => x.ComponentBrandOption)
                .WithMany(x => x.ComponentBrand)
                .HasForeignKey(x => x.ComponentBrandOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Marca).IsRequired().HasMaxLength(32);
            Property(c => c.Comment).IsOptional().HasMaxLength(64);
            Property(c => c.SiteOficial).IsOptional().HasMaxLength(128);         
        }
    }
}
