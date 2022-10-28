using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Ninject.Modules;
using Ninject;
using System;

namespace Ishopping.ApplicationManager.Component
{
    public class ComponentThumbnailSearch
    {
        private readonly IComponentThumbnailAppService _componentThumbnail;
        private Guid _imageId;

        public ComponentThumbnailSearch(Guid imageId)
        {
            this._imageId = imageId;
            IKernel kernel = new StandardKernel(new ModulesForComponents());
            _componentThumbnail = kernel.Get<IComponentThumbnailAppService>();
        }

        public ComponentThumbnail ImageSearch()
        {
            return _componentThumbnail.GetByImageId(_imageId);
        }
    }
}