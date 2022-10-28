using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class UserSerializeViewDataConfiguration : EntityTypeConfiguration<UserSerializeViewData>
    {
        public UserSerializeViewDataConfiguration ()
	    {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.SiteNumber).IsRequired();
            Property(c => c.Serialize).IsRequired().HasColumnType("varchar(max)");
	    }     
    }
}
