using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class ComponentExtraLinkConfiguration : EntityTypeConfiguration<ComponentExtraLink>
    {
        public ComponentExtraLinkConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired<ComponentExtraLinkOption>(x => x.ComponentExtraLinkOption)
                .WithMany(x => x.ComponentExtraLink)
                .HasForeignKey(x => x.ComponentExtraLinkOptionId)
                .WillCascadeOnDelete(true);
            Property(c => c.TextLink).IsRequired().HasMaxLength(64);
            Property(c => c.Link).IsRequired().HasMaxLength(128);
            Property(c => c.Description).IsOptional().HasMaxLength(512);
        }
    }
}
