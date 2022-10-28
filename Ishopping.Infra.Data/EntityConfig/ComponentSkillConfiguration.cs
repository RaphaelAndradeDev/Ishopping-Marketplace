using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentSkillConfiguration : EntityTypeConfiguration<ComponentSkill>
    {
        public ComponentSkillConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentSkillOption>(x => x.ComponentSkillOption)
                .WithMany(x => x.ComponentSkill)
                .HasForeignKey(x => x.ComponentSkillOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Category).IsRequired().HasMaxLength(32);           
            Property(c => c.Description).IsOptional().HasMaxLength(512);
        }
    }
}
