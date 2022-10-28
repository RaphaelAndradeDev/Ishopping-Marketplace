using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ContentButtonOptionConfiguration : EntityTypeConfiguration<ContentButtonOption>
    {
        public ContentButtonOptionConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.TextBtn).IsRequired().HasMaxLength(64);
        }
    }
}
