using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentPricingConfiguration : EntityTypeConfiguration<ComponentPricing>
    {
        public ComponentPricingConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentPricingOption>(x => x.ComponentPricingOption)
                .WithMany(x => x.ComponentPricing)
                .HasForeignKey(x => x.ComponentPricingOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.NomePlano).IsRequired().HasMaxLength(64);
            Property(c => c.PriceUnid).IsRequired().HasMaxLength(6);
            Property(c => c.PriceCent).IsRequired().HasMaxLength(2);
            Property(c => c.Periodo).IsRequired().HasMaxLength(12);
            Property(c => c.Description).IsOptional().HasMaxLength(512);
            Property(c => c.Comment).IsOptional().HasMaxLength(512);
            Property(c => c.TextButton).IsOptional().HasMaxLength(20);
            Property(c => c.UrlButton).IsOptional().HasMaxLength(128);
            Property(c => c.Moeda).IsOptional().HasMaxLength(3);
        }
    }
}
