using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ContentListAppService : AppServiceBaseT2<ContentList>, IContentListAppService
    {
        private readonly IContentListService _contentListService;
        private readonly IContentListOptionService _contentListOptionService;

        public ContentListAppService(
            IContentListService contentListService,
            IContentListOptionService contentListOptionService)
            :base(contentListService)
        {
            _contentListService = contentListService;
            _contentListOptionService = contentListOptionService;
        }

        public IEnumerable<ContentList> GetAllBySiteNumber(int siteNumber)
        {
            return _contentListService.GetAllBySiteNumber(siteNumber);
        }

        public IEnumerable<ContentList> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return _contentListService.GetAllBySiteNumber(siteNumber, maxPosition);
        }

        public IEnumerable<ContentList> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return _contentListService.GetAllBySiteNumber(siteNumber, maxPosition, viewCod);
        }

        public IEnumerable<ContentList> GetAllByUserId(string userId)
        {
            return _contentListService.GetAllByUserId(userId);
        }

        public IEnumerable<ContentList> GetAllByUserId(string userId, int maxPosition)
        {
            return _contentListService.GetAllByUserId(userId, maxPosition);
        }

        public IEnumerable<ContentList> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return _contentListService.GetAllByUserId(userId, maxPosition, viewCod);
        }

        public ContentList GetById(Guid id, string userId)
        {
            return _contentListService.GetById(id, userId);
        }

        public ContentList GetBy(int viewCod, int position, string userId)
        {
            return _contentListService.GetBy(viewCod, position, userId);
        }

        // Async Methods
        public async Task<IEnumerable<ContentList>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _contentListService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ContentList>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await _contentListService.GetAllBySiteNumberAsync(siteNumber, maxPosition);
        }

        public async Task<IEnumerable<ContentList>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await _contentListService.GetAllBySiteNumberAsync(siteNumber, maxPosition, viewCod);
        }

        public async Task<IEnumerable<ContentList>> GetAllByUserIdAsync(string userId)
        {
            return await _contentListService.GetAllByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ContentList>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await _contentListService.GetAllByUserIdAsync(userId, maxPosition);
        }

        public async Task<IEnumerable<ContentList>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await _contentListService.GetAllByUserIdAsync(userId, maxPosition, viewCod);
        }

        public async Task<ContentList> GetByIdAsync(Guid id, string userId)
        {
            return await _contentListService.GetByIdAsync(id, userId);
        }

        public async Task<ContentList> GetByAsync(int viewCod, int position, string userId)
        {
            return await _contentListService.GetByAsync(viewCod, position, userId);
        }


        // Others Methods

        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _contentListOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, lista = obj.Lista };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<object> GetObjetoAsync(int viewCod, int position, string userId)
        {
            var obj = await _contentListService.GetByAsync(viewCod, position, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, position = obj.Position, lista = obj._Lista,  stLista = obj.ContentListOption.Lista };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int viewCod, int position, string lista, string styleLista)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var list = await _contentListService.GetByAsync(viewCod, position, userId);
            var listOption = await _contentListOptionService.PutAsync(styleLista, userId);

            if (list != null)
            {                
                list.Change(viewCod, position, lista);

                if(listOption.Id == Guid.Empty)
                {
                    if(list.ContentListOption.Default)
                    {
                        list.AddContentListOption(listOption);
                    }
                    else
                    {
                        list.ContentListOption.Change(false,styleLista);
                    }
                    _contentListService.Update(list);
                }
                else
                {
                    var optionOld = list.ContentListOptionId;
                    bool optionDefault = list.ContentListOption.Default;

                    list.ChangeContentListOption(listOption.Id);
                    _contentListService.Update(list);

                    if (!optionDefault)
                    {
                        var obj = await _contentListOptionService.GetByIdAsync(optionOld);
                        _contentListOptionService.Remove(obj);
                    }
                }
                json.Id = list.Id.ToString();
                return json;
            }
            else
            {
                if(listOption.Id == Guid.Empty)
                {
                    list = new ContentList(userId, siteNumber, listOption, viewCod, position, lista);
                    _contentListService.Add(list);
                    json.Id = list.Id.ToString();
                    return json;
                }
                else
                {
                    list = new ContentList(userId, siteNumber, listOption.Id, viewCod, position, lista);
                    _contentListService.Add(list);
                    json.Id = list.Id.ToString();
                    return json;
                }
            
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var list = await _contentListService.GetByIdAsync(_id, userId);

            if (list != null)
            {
                var optionOld = list.ContentListOptionId;
                bool optionDefault = list.ContentListOption.Default;

                _contentListService.Remove(list);

                if (!optionDefault)
                {
                    var obj = await _contentListOptionService.GetByIdAsync(optionOld);
                    _contentListOptionService.Remove(obj);
                }
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(list.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _contentListService.DeleteAll(userId);
        }
    }
}
