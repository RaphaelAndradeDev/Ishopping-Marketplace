using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentThumbnailConfiguration : EntityTypeConfiguration<ComponentThumbnail>
    {
        public ComponentThumbnailConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Category).IsOptional().HasMaxLength(32);
            Property(c => c.VectorIcon).IsOptional().HasMaxLength(32);
        }
    }
}
