using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ContentTextOptionConfiguration : EntityTypeConfiguration<ContentTextOption>
    {
        public ContentTextOptionConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Text32).IsRequired().HasMaxLength(64);
            Property(c => c.Text512).IsRequired().HasMaxLength(64);
            Property(c => c.Text5120).IsRequired().HasMaxLength(64);
        }
    }
}
