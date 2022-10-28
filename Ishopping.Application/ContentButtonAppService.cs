using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ContentButtonAppService : AppServiceBaseT2<ContentButton>, IContentButtonAppService
    {
        private readonly IContentButtonService _contentButtonService;
        private readonly IContentButtonOptionService _contentButtonOptionService;

        public ContentButtonAppService(
            IContentButtonService contentButtonService,
            IContentButtonOptionService contentButtonOptionService)
            :base(contentButtonService)
        {
            _contentButtonService = contentButtonService;
            _contentButtonOptionService = contentButtonOptionService;
        }

        public IEnumerable<string> Search(string startsWith, int viewCod, string userId)
        {
            return _contentButtonService.Search(startsWith, viewCod, userId);
        }

        public IEnumerable<ContentButton> GetAllBySiteNumber(int siteNumber)
        {
            return _contentButtonService.GetAllBySiteNumber(siteNumber);
        }

        public IEnumerable<ContentButton> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return _contentButtonService.GetAllBySiteNumber(siteNumber, maxPosition);
        }

        public IEnumerable<ContentButton> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return _contentButtonService.GetAllBySiteNumber(siteNumber, maxPosition, viewCod);
        }

        public IEnumerable<ContentButton> GetAllByUserId(string userId)
        {
            return _contentButtonService.GetAllByUserId(userId);
        }

        public IEnumerable<ContentButton> GetAllByUserId(string userId, int maxPosition)
        {
            return _contentButtonService.GetAllByUserId(userId, maxPosition);
        }

        public IEnumerable<ContentButton> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return _contentButtonService.GetAllByUserId(userId, maxPosition, viewCod);
        }

        public ContentButton GetById(Guid id, string userId)
        {
            return _contentButtonService.GetById(id, userId);
        }

        public ContentButton GetBy(int viewCod, int position, string userId)
        {
            return _contentButtonService.GetBy(viewCod, position, userId);
        }

        public ContentButton GetBy(int viewCod, string term, string userId)
        {
            return _contentButtonService.GetBy(viewCod, term, userId);
        }

        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int viewCod, string userId)
        {
            return await _contentButtonService.SearchAsync(startsWith, viewCod, userId);
        }
        
        public async Task<IEnumerable<ContentButton>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _contentButtonService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ContentButton>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await _contentButtonService.GetAllBySiteNumberAsync(siteNumber, maxPosition);
        }

        public async Task<IEnumerable<ContentButton>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await _contentButtonService.GetAllBySiteNumberAsync(siteNumber, maxPosition, viewCod);
        }

        public async Task<IEnumerable<ContentButton>> GetAllByUserIdAsync(string userId)
        {
            return await _contentButtonService.GetAllByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ContentButton>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await _contentButtonService.GetAllByUserIdAsync(userId, maxPosition);
        }

        public async Task<IEnumerable<ContentButton>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await _contentButtonService.GetAllByUserIdAsync(userId, maxPosition, viewCod);
        }

        public async Task<ContentButton> GetByIdAsync(Guid id, string userId)
        {
            return await _contentButtonService.GetByIdAsync(id, userId);
        }

        public async Task<ContentButton> GetByAsync(int viewCod, int position, string userId)
        {
            return await _contentButtonService.GetByAsync(viewCod, position, userId);
        }

        public async Task<ContentButton> GetByAsync(int viewCod, string term, string userId)
        {
            return await _contentButtonService.GetByAsync(viewCod, term, userId);
        }


        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _contentButtonOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, textBtn = obj.TextBtn };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<object> GetObjetoAsync(int viewCod, int position, string userId)
        {
            var obj = await _contentButtonService.GetByAsync(viewCod, position, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, position = obj.Position, textBtn = obj._TextBtn, textUrl = obj.TextURL, stTextBtn = obj.ContentButtonOption.TextBtn };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<object> GetObjetoAsync(int viewCod, string search, string userId)
        {
            var obj = await _contentButtonService.GetByAsync(viewCod, search, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, position = obj.Position, textBtn = obj._TextBtn, textUrl = obj.TextURL, stTextBtn = obj.ContentButtonOption.TextBtn };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int viewCod, int position, string textButton, string styleTextButton, string textURL)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var button = await _contentButtonService.GetByAsync(viewCod, position, userId);
            var buttonOption = await _contentButtonOptionService.PutAsync(styleTextButton, userId);

            if (button != null)
            {                
                button.Change(viewCod, position, textButton, textURL);

                if(buttonOption.Id == Guid.Empty)
                {
                    if(button.ContentButtonOption.Default)
                    {
                        button.AddContentButtonOption(buttonOption);
                    }
                    else
                    {
                        button.ContentButtonOption.Change(false, styleTextButton);
                    }
                    _contentButtonService.Update(button);
                }
                else
                {
                    var optionOld = button.ContentButtonOptionId;
                    bool optionDefault = button.ContentButtonOption.Default;

                    button.ChangeContentButtonOption(buttonOption.Id);
                    _contentButtonService.Update(button);

                    if (!optionDefault)
                    {
                        var obj = await _contentButtonOptionService.GetByIdAsync(optionOld);
                        _contentButtonOptionService.Remove(obj);
                    } 
                }
                json.Id = button.Id.ToString();
                return json;
            }
            else
            {
                if(buttonOption.Id == Guid.Empty)
                {
                    button = new ContentButton(userId, siteNumber, buttonOption, viewCod, position, textButton, textURL);
                    _contentButtonService.Add(button);
                    json.Id = button.Id.ToString();
                    return json;
                }
                else
                {
                    button = new ContentButton(userId, siteNumber, buttonOption.Id, viewCod, position, textButton, textURL);
                    _contentButtonService.Add(button);
                    json.Id = button.Id.ToString();
                    return json;
                }             
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var button = await _contentButtonService.GetByIdAsync(_id, userId);

            if (button != null)
            {
                var optionOld = button.ContentButtonOptionId;
                bool optionDefault = button.ContentButtonOption.Default;

                _contentButtonService.Remove(button);

                if (!optionDefault)
                {
                    var obj = await _contentButtonOptionService.GetByIdAsync(optionOld);
                    _contentButtonOptionService.Remove(obj);
                }
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(button.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _contentButtonService.DeleteAll(userId);
        }
            
    }
}
