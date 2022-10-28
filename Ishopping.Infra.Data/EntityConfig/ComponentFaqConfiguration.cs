using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentFaqConfiguration : EntityTypeConfiguration<ComponentFaq>
    {
        public ComponentFaqConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentFaqOption>(x => x.ComponentFaqOption)
                .WithMany(x => x.ComponentFaq)
                .HasForeignKey(x => x.ComponentFaqOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Pergunta).IsRequired().HasMaxLength(256);
            Property(c => c.Resposta).IsRequired().HasMaxLength(512);
            Property(c => c.Category).IsOptional().HasMaxLength(32);
        }
    }
}
