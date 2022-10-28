using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentActivityConfiguration : EntityTypeConfiguration<ComponentActivity>
    {
        public ComponentActivityConfiguration()
        {      
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentActivityOption>(x => x.ComponentActivityOption)
                .WithMany(x => x.ComponentActivity)
                .HasForeignKey(x => x.ComponentActivityOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Title).IsRequired().HasMaxLength(64);
            Property(c => c.VectorIcon).IsRequired().HasMaxLength(32);
            Property(c => c.Description).IsOptional().HasMaxLength(512);
        }
    }
}
