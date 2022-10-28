using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using Ishopping.Domain.Entities;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class AdminTemplateConfiguration : EntityTypeConfiguration<AdminTemplate>
    {
        public AdminTemplateConfiguration()
        {
            HasKey(x => x.Id);
            Property(c => c.CssPath).HasMaxLength(512);
        }
    }
}
