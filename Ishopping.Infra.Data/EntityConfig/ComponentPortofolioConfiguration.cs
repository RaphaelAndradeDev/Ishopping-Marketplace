using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentPortofolioConfiguration : EntityTypeConfiguration<ComponentPortofolio>
    {
        public ComponentPortofolioConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentPortofolioOption>(x => x.ComponentPortofolioOption)
                .WithMany(x => x.ComponentPortofolio)
                .HasForeignKey(x => x.ComponentPortofolioOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Title).IsRequired().HasMaxLength(64);
            Property(c => c.Description).IsOptional().HasMaxLength(512);
            Property(c => c.Category).IsOptional().HasMaxLength(32);
            Property(c => c.List).IsOptional().HasMaxLength(256);
        }
    }
}
