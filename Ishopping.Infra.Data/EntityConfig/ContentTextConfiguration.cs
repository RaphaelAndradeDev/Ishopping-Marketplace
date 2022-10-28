using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ContentTextConfiguration : EntityTypeConfiguration<ContentText>
    {
        public ContentTextConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ContentTextOption>(x => x.ContentTextOption)
                .WithMany(x => x.ContentText)
                .HasForeignKey(x => x.ContentTextOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Text32).IsOptional().HasMaxLength(64);
            Property(c => c.Text512).IsOptional().HasMaxLength(512);
            Property(c => c.Text5120).IsOptional().HasMaxLength(5120);
        }
    }
}
