using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentServiceConfiguration : EntityTypeConfiguration<ComponentService>
    {
        public ComponentServiceConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentServiceOption>(x => x.ComponentServiceOption)
                .WithMany(x => x.ComponentService)
                .HasForeignKey(x => x.ComponentServiceOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Title).IsRequired().HasMaxLength(64);
            Property(c => c.Description).IsOptional().HasMaxLength(512);
        }
    }
}
