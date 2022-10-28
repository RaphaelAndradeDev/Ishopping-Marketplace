using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentSummaryConfiguration : EntityTypeConfiguration<ComponentSummary>
    {
        public ComponentSummaryConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentSummaryOption>(x => x.ComponentSummaryOption)
                .WithMany(x => x.ComponentSummary)
                .HasForeignKey(x => x.ComponentSummaryOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Title).IsRequired().HasMaxLength(64);
            Property(c => c.Description).IsRequired().HasMaxLength(512);
            Property(c => c.Category).IsOptional().HasMaxLength(32);
        }
    }
}
