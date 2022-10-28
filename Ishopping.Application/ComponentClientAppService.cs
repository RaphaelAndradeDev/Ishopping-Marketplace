using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentClientAppService : AppServiceBaseT2<ComponentClient>, IComponentClientAppService
    {
        private readonly IComponentClientService _componentClientService;
        private readonly IComponentClientOptionService _componentClientOptionService;
        private readonly IUserImageGalleryService _userImageGalleryService;   

        public ComponentClientAppService(
            IComponentClientService componentClientService,
            IComponentClientOptionService componentClientOptionService,
            IUserImageGalleryService userImageGalleryService)
            :base(componentClientService)
        {
            _componentClientService = componentClientService;
            _componentClientOptionService = componentClientOptionService;
            _userImageGalleryService = userImageGalleryService;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentClientService.Search(startsWith, userId);
        }

        public ComponentClient GetByImageId(Guid imageId)
        {
            return _componentClientService.GetByImageId(imageId);
        }

        public IEnumerable<ComponentClient> GetAllBySiteNumber(int siteNumber)
        {
            return _componentClientService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentClient GetBySiteNumber(int siteNumber)
        {
            return _componentClientService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentClient> GetAllByUserId(string userId)
        {
            return _componentClientService.GetAllByUserId(userId);
        }

        public ComponentClient GetById(Guid id, string userId)
        {
            return _componentClientService.GetById(id, userId);
        }

        public ComponentClient GetByTerm(string title, string userId)
        {
            return _componentClientService.GetByTerm(title, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentClientService.SearchAsync(startsWith, userId);
        }

        public async Task<ComponentClient> GetByImageIdAsync(Guid imageId)
        {
            return await _componentClientService.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentClient> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentClientService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentClient>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentClientService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentClient>> GetAllByUserIdAsync(string userId)
        {
            return await _componentClientService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentClient> GetByIdAsync(Guid id, string userId)
        {
            return await _componentClientService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentClient> GetByTermAsync(string term, string userId)
        {
            return await _componentClientService.GetByTermAsync(term, userId);
        } 


        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentClientOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, comment = obj.Comment, funtio = obj.Functio, name = obj.Name, projects = obj.Projects };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, string name, string styleName, string functio, string styleFunction, 
            string comment, string styleComment, string project, string styleProject, string siteOficial, string fileName)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var imageGallery = await _userImageGalleryService.GetByAsync(4, fileName, userId);
            if (imageGallery == null)
            {
                json.Redirect = false;
                json.Message = "Imagem não encontrada";
                return json;
            }

            var clientOption = await _componentClientOptionService.PutAsync(styleName, styleFunction, styleComment, styleProject, userId);

            if (_id != Guid.Empty)
            {
                var client = await _componentClientService.GetByIdAsync(_id, userId);
                json.Redirect = client.UserImageGallery.FileName != imageGallery.FileName;
                client.Change(imageGallery.Id, name, functio, comment, project, siteOficial);

                if(clientOption.Id == Guid.Empty)
                {
                    if(client.ComponentClientOption.Default)
                    {
                        client.AddComponentClientOption(clientOption);
                    }
                    else
                    {
                        client.ComponentClientOption.Change(false, styleName, styleFunction, styleComment, styleProject);
                    }
                    _componentClientService.Update(client);
                }
                else
                {
                    var optionOld = client.ComponentClientOptionId;
                    bool optionDefault = client.ComponentClientOption.Default;

                    client.ChangeComponentClientOption(clientOption.Id);
                    _componentClientService.Update(client);

                    if (!optionDefault)
                    {
                        var obj = await _componentClientOptionService.GetByIdAsync(optionOld);
                        _componentClientOptionService.Remove(obj);
                    }
                }             
                json.Id = client.Id.ToString();
                return json;
            }
            else
            {
                if(clientOption.Id == Guid.Empty)
                {
                    var client = new ComponentClient(userId, siteNumber, imageGallery.Id, clientOption, name, functio, comment, project, siteOficial);
                    _componentClientService.Add(client);
                }
                else
                {
                    var client = new ComponentClient(userId, siteNumber, imageGallery.Id, clientOption.Id, name, functio, comment, project, siteOficial);
                    _componentClientService.Add(client);
                }          
                json.Redirect = true;
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var client = await _componentClientService.GetByIdAsync(_id, userId);

            if (client != null)
            {
                var optionOld = client.ComponentClientOptionId;
                bool optionDefault = client.ComponentClientOption.Default;

                _componentClientService.Remove(client);

                if (!optionDefault)
                {
                    var obj = await _componentClientOptionService.GetByIdAsync(optionOld);
                    _componentClientOptionService.Remove(obj);
                }

                return new JsonDelete(true);
            }
            else
            {
                return new JsonDelete(client.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentClientService.DeleteAll(userId);
        }

    }
}
