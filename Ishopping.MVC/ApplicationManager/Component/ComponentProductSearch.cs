using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Ninject.Modules;
using Ninject;
using System;

namespace Ishopping.ApplicationManager.Component
{
    public class ComponentProductSearch
    {
        private readonly IComponentSimpleProductAppService _componentProduct;
        private Guid _imageId;

        public ComponentProductSearch(Guid imageId)
        {
            this._imageId = imageId;
            IKernel kernel = new StandardKernel(new ModulesForComponents());
            _componentProduct = kernel.Get<IComponentSimpleProductAppService>();
        }

        public ComponentSimpleProduct ImageSearch()
        {
            return _componentProduct.GetByImageId(_imageId);
        }

    }
}