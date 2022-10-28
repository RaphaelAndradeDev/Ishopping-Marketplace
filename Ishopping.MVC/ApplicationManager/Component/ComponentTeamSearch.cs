using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Ninject.Modules;
using Ninject;
using System;

namespace Ishopping.ApplicationManager.Component
{
    public class ComponentTeamSearch
    {
        private readonly IComponentTeamAppService _componentTeam;
        private Guid _imageId;

        public ComponentTeamSearch(Guid imageId)
        {
            this._imageId = imageId;
            IKernel kernel = new StandardKernel(new ModulesForComponents());
            _componentTeam = kernel.Get<IComponentTeamAppService>();
        }

        public ComponentTeam ImageSearch()
        {
            return _componentTeam.GetByImageId(_imageId);
        }
    }
}