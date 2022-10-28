using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Ninject.Modules;
using Ninject;
using System;

namespace Ishopping.ApplicationManager.Component
{
    public class ComponentServiceSearch
    {
        private readonly IComponentServiceAppService _componentService;
        private Guid _imageId;

        public ComponentServiceSearch(Guid imageId)
        {
            this._imageId = imageId;
            IKernel kernel = new StandardKernel(new ModulesForComponents());
            _componentService = kernel.Get<IComponentServiceAppService>();
        }

        public ComponentService ImageSearch()
        {
            return _componentService.GetByImageId(_imageId);
        }
    }
}