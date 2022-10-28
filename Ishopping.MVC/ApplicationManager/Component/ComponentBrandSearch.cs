using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Ninject.Modules;
using Ninject;
using System;
using System.Threading.Tasks;

namespace Ishopping.ApplicationManager.Component
{
    public class ComponentBrandSearch
    {
        private readonly IComponentBrandAppService _componentBrand;
        private Guid _imageId;

        public ComponentBrandSearch(Guid imageId)
        {
            this._imageId = imageId;
            IKernel kernel = new StandardKernel(new ModulesForComponents());
            _componentBrand = kernel.Get<IComponentBrandAppService>();
        }

        public async Task<ComponentBrand> ImageSearch()
        {
            return await _componentBrand.GetByImageIdAsync(_imageId);
        }

    }
}