using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class UserMenuConfiguration : EntityTypeConfiguration<UserMenu>
    {
        public UserMenuConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);           
        }
    }
}
