using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class UserRegisterProfileConfiguration : EntityTypeConfiguration<UserRegisterProfile>
    {
        public UserRegisterProfileConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.AppMenu).IsRequired().HasMaxLength(1024);
        }
    }
}
