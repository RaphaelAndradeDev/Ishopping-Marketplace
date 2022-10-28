using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentPricingOptionConfiguration : EntityTypeConfiguration<ComponentPricingOption>
    {
        public ComponentPricingOptionConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.NomePlano).IsRequired().HasMaxLength(64);
            Property(c => c.Moeda).IsRequired().HasMaxLength(64);
            Property(c => c.PriceUnid).IsRequired().HasMaxLength(64);
            Property(c => c.PriceCent).IsRequired().HasMaxLength(64);
            Property(c => c.Periodo).IsRequired().HasMaxLength(64);
            Property(c => c.Description).IsRequired().HasMaxLength(64);
            Property(c => c.Comment).IsRequired().HasMaxLength(64);
            Property(c => c.TextButton).IsRequired().HasMaxLength(64);
            Property(c => c.Price).IsRequired().HasMaxLength(64);
        }
    }
}
