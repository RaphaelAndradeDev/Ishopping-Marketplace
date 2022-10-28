using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentTeamConfiguration : EntityTypeConfiguration<ComponentTeam>
    {
        public ComponentTeamConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentTeamOption>(x => x.ComponentTeamOption)
                .WithMany(x => x.ComponentTeam)
                .HasForeignKey(x => x.ComponentTeamOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Name).IsRequired().HasMaxLength(64);
            Property(c => c.Functio).IsOptional().HasMaxLength(64);
            Property(c => c.Description).IsOptional().HasMaxLength(512);
        }
    }
}
