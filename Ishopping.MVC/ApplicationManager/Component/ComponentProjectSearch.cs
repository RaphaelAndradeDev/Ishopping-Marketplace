using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Ninject.Modules;
using Ninject;
using System;

namespace Ishopping.ApplicationManager.Component
{
    public class ComponentProjectSearch
    {
        private readonly IComponentProjectAppService _componentProject;
        private Guid _imageId;

        public ComponentProjectSearch(Guid imageId)
        {
            this._imageId = imageId;
            IKernel kernel = new StandardKernel(new ModulesForComponents());
            _componentProject = kernel.Get<IComponentProjectAppService>();
        }

        public ComponentProject ImageSearch()
        {
            return _componentProject.GetByImageId(_imageId);
        }
    }
}