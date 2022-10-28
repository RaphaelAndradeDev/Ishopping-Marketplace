using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentProjectConfiguration : EntityTypeConfiguration<ComponentProject>
    {
        public ComponentProjectConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentProjectOption>(x => x.ComponentProjectOption)
                .WithMany(x => x.ComponentProject)
                .HasForeignKey(x => x.ComponentProjectOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Title).IsRequired().HasMaxLength(64);
            Property(c => c.Description).IsRequired().HasMaxLength(512);
            Property(c => c.Name).IsOptional().HasMaxLength(64);
            Property(c => c.Client).IsOptional().HasMaxLength(64);
            Property(c => c.Category).IsOptional().HasMaxLength(32);
            Property(c => c.WebSite).IsOptional().HasMaxLength(128);
            Property(c => c.Team).IsOptional().HasMaxLength(128);
            Property(c => c.UrlVideo).IsOptional().HasMaxLength(128);
        }
    }
}
