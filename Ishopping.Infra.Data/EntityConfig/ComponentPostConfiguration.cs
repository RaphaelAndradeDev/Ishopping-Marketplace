using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentPostConfiguration : EntityTypeConfiguration<ComponentPost>
    {
        public ComponentPostConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentPostOption>(x => x.ComponentPostOption)
                .WithMany(x => x.ComponentPost)
                .HasForeignKey(x => x.ComponentPostOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.Titulo).IsRequired().HasMaxLength(64);
            Property(c => c.Paragrafo1).IsRequired().HasMaxLength(5120);
            Property(c => c.Autor).IsOptional().HasMaxLength(32);
            Property(c => c.Categoria).IsOptional().HasMaxLength(32);
            Property(c => c.SubTitulo1).IsOptional().HasMaxLength(128);
            Property(c => c.SubTitulo2).IsOptional().HasMaxLength(128);
            Property(c => c.SubTitulo3).IsOptional().HasMaxLength(128);
            Property(c => c.Paragrafo2).IsOptional().HasMaxLength(5120);
            Property(c => c.Paragrafo3).IsOptional().HasMaxLength(5120);
            Property(c => c.Video).IsOptional().HasMaxLength(256);
        }
    }
}
