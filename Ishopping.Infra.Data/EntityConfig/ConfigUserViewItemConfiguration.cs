using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ConfigUserViewItemConfiguration : EntityTypeConfiguration<ConfigUserViewItem>
    {
        public ConfigUserViewItemConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ConfigUserView>(x => x.ConfigUserView)
                .WithMany(x => x.ConfigUserViewItem)
                .HasForeignKey(x => x.ConfigUserViewId)
                .WillCascadeOnDelete(true);           
        }
    }
}
