using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Ninject.Modules;
using Ninject;
using System;

namespace Ishopping.ApplicationManager.Content
{
    public class ContentSliderSearch
    {
        private readonly IContentSliderAppService _contentSlider;
        private Guid _imageId;

        public ContentSliderSearch(Guid imageId)
        {
            this._imageId = imageId;
            IKernel kernel = new StandardKernel(new ModuleForContentSlider());
            _contentSlider = kernel.Get<IContentSliderAppService>();
        }

        public ContentSlider ImageSearch()
        {
            return _contentSlider.GetByImageId(_imageId);
        }
    }
}