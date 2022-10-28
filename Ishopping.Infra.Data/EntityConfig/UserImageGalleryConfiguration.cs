using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using Ishopping.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class UserImageGalleryConfiguration : EntityTypeConfiguration<UserImageGallery>
    {
        public UserImageGalleryConfiguration()
        {
            HasKey(x => x.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
