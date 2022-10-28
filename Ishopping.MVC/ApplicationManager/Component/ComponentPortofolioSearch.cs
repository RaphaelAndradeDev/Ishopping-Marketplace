using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Ninject.Modules;
using Ninject;
using System;

namespace Ishopping.ApplicationManager.Component
{
    public class ComponentPortofolioSearch
    {
        private readonly IComponentPortofolioAppService _componentPortofolio;
        private Guid _imageId;

        public ComponentPortofolioSearch(Guid imageId)
        {
            this._imageId = imageId;
            IKernel kernel = new StandardKernel(new ModulesForComponents());
            _componentPortofolio = kernel.Get<IComponentPortofolioAppService>();
        }

        public ComponentPortofolio ImageSearch()
        {
            return _componentPortofolio.GetByImageId(_imageId);
        }
    }
}