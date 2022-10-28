using Ishopping.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Ishopping.Infra.Data.EntityConfig
{
    public class AdminSliderConfigConfiguration : EntityTypeConfiguration<AdminSliderConfig>
    {
        public AdminSliderConfigConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}
