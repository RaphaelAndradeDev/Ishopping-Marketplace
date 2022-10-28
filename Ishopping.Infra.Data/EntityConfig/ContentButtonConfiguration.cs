using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ContentButtonConfiguration : EntityTypeConfiguration<ContentButton>
    {
        public ContentButtonConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ContentButtonOption>(x => x.ContentButtonOption)
                .WithMany(x => x.ContentButton)
                .HasForeignKey(x => x.ContentButtonOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.TextBtn).IsRequired().HasMaxLength(64);
            Property(c => c.TextURL).IsOptional().HasMaxLength(128);
        }
    }
}
