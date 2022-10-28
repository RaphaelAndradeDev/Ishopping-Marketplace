using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentClientConfiguration : EntityTypeConfiguration<ComponentClient>
    {
        public ComponentClientConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentClientOption>(x => x.ComponentClientOption)
                .WithMany(x => x.ComponentClient)
                .HasForeignKey(x => x.ComponentClientOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Name).IsRequired().HasMaxLength(64);
            Property(c => c.Functio).IsOptional().HasMaxLength(64);
            Property(c => c.Comment).IsOptional().HasMaxLength(512);
            Property(c => c.Projects).IsOptional().HasMaxLength(128);
            Property(c => c.SiteOficial).IsOptional().HasMaxLength(128);
        }
    }
}
