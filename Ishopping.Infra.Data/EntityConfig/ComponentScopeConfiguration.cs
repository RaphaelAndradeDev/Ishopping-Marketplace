using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentScopeConfiguration : EntityTypeConfiguration<ComponentScope>
    {
        public ComponentScopeConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentScopeOption>(x => x.ComponentScopeOption)
                .WithMany(x => x.ComponentScope)
                .HasForeignKey(x => x.ComponentScopeOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Title).IsRequired().HasMaxLength(64);
            Property(c => c.VectorIcon).IsRequired().HasMaxLength(32);
            Property(c => c.Category).IsOptional().HasMaxLength(32);
            Property(c => c.Description).IsOptional().HasMaxLength(512);
        }
    }
}
