using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Ninject.Modules;
using Ninject;
using System;

namespace Ishopping.ApplicationManager.Component
{
    public class ComponentPostSearch
    {
        private readonly IComponentPostAppService _componentPost;
        private Guid _imageId;

        public ComponentPostSearch(Guid imageId)
        {
            this._imageId = imageId;
            IKernel kernel = new StandardKernel(new ModulesForComponents());
            _componentPost = kernel.Get<IComponentPostAppService>();
        }

        public ComponentPost ImageSearch()
        {
            return _componentPost.GetByImageId(_imageId);
        }
    }
}