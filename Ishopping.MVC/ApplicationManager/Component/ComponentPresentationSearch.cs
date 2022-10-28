using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Ninject.Modules;
using Ninject;
using System;

namespace Ishopping.ApplicationManager.Component
{
    public class ComponentPresentationSearch
    {
        private readonly IComponentPresentationAppService _componentPresentation;
        private Guid _imageId;

        public ComponentPresentationSearch(Guid imageId)
        {
            this._imageId = imageId;
            IKernel kernel = new StandardKernel(new ModulesForComponents());
            _componentPresentation = kernel.Get<IComponentPresentationAppService>();
        }

        public ComponentPresentation ImageSearch()
        {
            return _componentPresentation.GetByImageId(_imageId);
        }
    }
}