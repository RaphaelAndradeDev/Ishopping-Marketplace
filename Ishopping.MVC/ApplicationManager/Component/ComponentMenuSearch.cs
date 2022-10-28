using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Ninject.Modules;
using Ninject;
using System;

namespace Ishopping.ApplicationManager.Component
{
    public class ComponentMenuSearch
    {
        private readonly IComponentMenuAppService _componentMenu;
        private Guid _imageId;

        public ComponentMenuSearch(Guid imageId)
        {
            this._imageId = imageId;
            IKernel kernel = new StandardKernel(new ModulesForComponents());
            _componentMenu = kernel.Get<IComponentMenuAppService>();
        }

        public ComponentMenu ImageSearch()
        {
            return _componentMenu.GetByImageId(_imageId);
        }
    }
}