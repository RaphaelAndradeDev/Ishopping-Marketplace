using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ConfigUserStyleColorConfiguration : EntityTypeConfiguration<ConfigUserStyleColor>
    {
        public ConfigUserStyleColorConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ConfigUserAppearance>(x => x.ConfigUserAppearance)
                .WithMany(x => x.ConfigUserStyleColor)
                .HasForeignKey(x => x.ConfigUserAppearanceId)
                .WillCascadeOnDelete(true);
        }
    }
}
