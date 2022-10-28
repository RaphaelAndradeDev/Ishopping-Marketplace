using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Ninject.Modules;
using Ninject;
using System;

namespace Ishopping.ApplicationManager.Component
{
    public class ConfigUserDisplaySearch
    {
        private readonly IConfigUserDisplayAppService _configUserDisplay;
        private Guid _imageId;

        public ConfigUserDisplaySearch(Guid imageId)
        {
            this._imageId = imageId;
            IKernel kernel = new StandardKernel(new ModuleForConfigUser());
            _configUserDisplay = kernel.Get<IConfigUserDisplayAppService>();
        }

        public ConfigUserDisplay ImageSearch()
        {
            return _configUserDisplay.GetByImageId(_imageId);
        }

    }
}