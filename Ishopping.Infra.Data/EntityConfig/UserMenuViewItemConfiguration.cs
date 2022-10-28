using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class UserMenuViewItemConfiguration : EntityTypeConfiguration<UserMenuViewItem>
    {
        public UserMenuViewItemConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<UserMenuView>(x => x.UserMenuView)
                .WithMany(x => x.UserMenuViewItem)
                .HasForeignKey(x => x.UserMenuViewId)
                .WillCascadeOnDelete(true);
        }
    }
}
