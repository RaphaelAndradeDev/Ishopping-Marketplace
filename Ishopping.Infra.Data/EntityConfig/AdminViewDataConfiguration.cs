using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using Ishopping.Domain.Entities;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class AdminViewDataConfiguration : EntityTypeConfiguration<AdminViewData>
    {
        public AdminViewDataConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}
