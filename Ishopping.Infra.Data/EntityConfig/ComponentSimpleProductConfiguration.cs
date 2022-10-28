using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentSimpleProductConfiguration : EntityTypeConfiguration<ComponentSimpleProduct>
    {
        public ComponentSimpleProductConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentSimpleProductOption>(x => x.ComponentSimpleProductOption)
                .WithMany(x => x.ComponentSimpleProduct)
                .HasForeignKey(x => x.ComponentSimpleProductOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Name).IsRequired().HasMaxLength(64);
            Property(c => c.Description).IsRequired().HasMaxLength(512);      
            Property(c => c.Brand).IsOptional().HasMaxLength(32);
            Property(c => c.Model).IsOptional().HasMaxLength(32);
        }
    }
}
