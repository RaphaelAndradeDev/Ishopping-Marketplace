using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using Ishopping.Domain.Entities;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class AdminImageGalleryConfiguration : EntityTypeConfiguration<AdminImageGallery>
    {
        public AdminImageGalleryConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}
