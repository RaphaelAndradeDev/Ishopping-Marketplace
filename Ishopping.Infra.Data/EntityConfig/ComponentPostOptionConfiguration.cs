using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentPostOptionConfiguration : EntityTypeConfiguration<ComponentPostOption>
    {
        public ComponentPostOptionConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Autor).IsRequired().HasMaxLength(64);
            Property(c => c.Categoria).IsRequired().HasMaxLength(64);
            Property(c => c.Titulo).IsRequired().HasMaxLength(64);
            Property(c => c.SubTitulo).IsRequired().HasMaxLength(64);
            Property(c => c.Paragrafo).IsRequired().HasMaxLength(64);
        }
    }
}
