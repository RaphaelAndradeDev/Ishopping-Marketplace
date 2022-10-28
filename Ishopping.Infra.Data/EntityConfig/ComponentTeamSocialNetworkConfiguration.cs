using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentTeamSocialNetworkConfiguration : EntityTypeConfiguration<ComponentTeamSocialNetwork>
    {
        public ComponentTeamSocialNetworkConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentTeam>(x => x.ComponentTeam)
                .WithMany(x => x.ComponentTeamSocialNetwork)
                .HasForeignKey(x => x.ComponentTeamId)
                .WillCascadeOnDelete(true);
            Property(c => c.Link).IsRequired().HasMaxLength(128);
            Property(c => c.Rede).IsRequired().HasMaxLength(32);
        }
    }
}
