using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;

namespace Ishopping.Infra.Data.Repositories
{
    public class ECommerceProductRepository : RepositoryBaseT2<ECommerceProduct>, IECommerceProductRepository
    {
        public ECommerceProduct GetByImageId(string imageId)
        {
            var userImageGallery = db.UserImageGallery.Find(imageId);
            return db.ECommerceProduct.FirstOrDefault(x => x.UserImageGallery.Any(y => y.Id == userImageGallery.Id));
        }
    }
}
