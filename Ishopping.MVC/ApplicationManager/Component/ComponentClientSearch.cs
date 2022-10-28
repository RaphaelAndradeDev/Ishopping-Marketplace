using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Ninject.Modules;
using Ninject;
using System;

namespace Ishopping.ApplicationManager.Component
{
    public class ComponentClientSearch
    {
        private readonly IComponentClientAppService _componentClient;
        private Guid _imageId;

        public ComponentClientSearch(Guid imageId)
        {
            this._imageId = imageId;
            IKernel kernel = new StandardKernel(new ModulesForComponents());
            _componentClient = kernel.Get<IComponentClientAppService>();
        }

        public ComponentClient ImageSearch()
        {
            return _componentClient.GetByImageId(_imageId);
        }
    }
}