using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class UserMenuViewConfiguration : EntityTypeConfiguration<UserMenuView>
    {
        public UserMenuViewConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<UserMenu>(x => x.UserMenu)
                .WithMany(x => x.UserMenuView)
                .HasForeignKey(x => x.UserMenuId)
                .WillCascadeOnDelete(true);
        }
    }
}
