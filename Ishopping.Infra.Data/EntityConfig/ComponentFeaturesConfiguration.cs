using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentFeaturesConfiguration : EntityTypeConfiguration<ComponentFeatures>
    {
        public ComponentFeaturesConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentFeaturesOption>(x => x.ComponentFeaturesOption)
                .WithMany(x => x.ComponentFeatures)
                .HasForeignKey(x => x.ComponentFeaturesOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Title).IsRequired().HasMaxLength(64);
            Property(c => c.Icon).IsOptional().HasMaxLength(32);
            Property(c => c.Description).IsOptional().HasMaxLength(512);
        }
    }
}
