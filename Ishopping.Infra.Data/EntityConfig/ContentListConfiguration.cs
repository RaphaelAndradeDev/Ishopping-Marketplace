using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ContentListConfiguration : EntityTypeConfiguration<ContentList>
    {
        public ContentListConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ContentListOption>(x => x.ContentListOption)
                .WithMany(x => x.ContentList)
                .HasForeignKey(x => x.ContentListOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Lista).IsRequired().HasMaxLength(256);
        }
    }
}
