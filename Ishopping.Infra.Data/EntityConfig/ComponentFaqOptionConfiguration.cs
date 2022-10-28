using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentFaqOptionConfiguration : EntityTypeConfiguration<ComponentFaqOption>
    {
        public ComponentFaqOptionConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Pergunta).IsRequired().HasMaxLength(64);
            Property(c => c.Resposta).IsRequired().HasMaxLength(64);
        }
    }
}
