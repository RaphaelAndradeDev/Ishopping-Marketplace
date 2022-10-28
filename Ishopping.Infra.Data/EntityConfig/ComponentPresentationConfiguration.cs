using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentPresentationConfiguration : EntityTypeConfiguration<ComponentPresentation>
    {
        public ComponentPresentationConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentPresentationOption>(x => x.ComponentPresentationOption)
                .WithMany(x => x.ComponentPresentation)
                .HasForeignKey(x => x.ComponentPresentationOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Title).IsRequired().HasMaxLength(64);
            Property(c => c.Category).IsRequired().HasMaxLength(32);
            Property(c => c.Description).IsRequired().HasMaxLength(512);
            Property(c => c.VectorIcon).IsOptional().HasMaxLength(32);
        }
    }
}
