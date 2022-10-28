using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ContentTextAppService : AppServiceBaseT2<ContentText>, IContentTextAppService
    {
        private readonly IContentTextService _contentTextService;
        private readonly IContentTextOptionService _contentTextOptionService;

        public ContentTextAppService(
            IContentTextService contentTextService,
             IContentTextOptionService contentTextOptionService)
            :base(contentTextService)
        {
            _contentTextService = contentTextService;
            _contentTextOptionService = contentTextOptionService;
        }

        public IEnumerable<string> Search(string startsWith, int viewCod, string userId)
        {
            List<string> listText = new List<string>();
            var text = _contentTextService.Search(startsWith, viewCod, userId);
            listText.AddRange(text.Where(x => x.Search32 != "").Select(x => x.Search32).ToList());
            listText.AddRange(text.Where(x => x.Search512 != "").Select(x => x.Search512).ToList());
            listText.AddRange(text.Where(x => x.Search5120 != "").Select(x => x.Search5120).ToList());
            return listText;
        }

        public IEnumerable<ContentText> GetAllBySiteNumber(int siteNumber)
        {
            return _contentTextService.GetAllBySiteNumber(siteNumber);
        }

        public IEnumerable<ContentText> GetAllBySiteNumber(int siteNumber, int maxPosition)
        {
            return _contentTextService.GetAllBySiteNumber(siteNumber, maxPosition);
        }

        public IEnumerable<ContentText> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return _contentTextService.GetAllBySiteNumber(siteNumber, maxPosition, viewCod);
        }

        public IEnumerable<ContentText> GetAllByUserId(string userId)
        {
            return _contentTextService.GetAllByUserId(userId);
        }

        public IEnumerable<ContentText> GetAllByUserId(string userId, int maxPosition)
        {
            return _contentTextService.GetAllByUserId(userId, maxPosition);
        }

        public IEnumerable<ContentText> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return _contentTextService.GetAllByUserId(userId, maxPosition, viewCod);
        }

        public ContentText GetById(Guid id, string userId)
        {
            return _contentTextService.GetById(id, userId);
        }

        public ContentText GetBy(int viewCod, int position, string userId)
        {
            return _contentTextService.GetBy(viewCod, position, userId);
        }

        public ContentText GetBy(int viewCod, string term, string userId)
        {
            return _contentTextService.GetBy(viewCod, term, userId);
        }

        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int viewCod, string userId)
        {
            List<string> listText = new List<string>();
            var text = await _contentTextService.SearchAsync(startsWith, viewCod, userId);
            listText.AddRange(text.Where(x => x.Search32 != "").Select(x => x.Search32).ToList());
            listText.AddRange(text.Where(x => x.Search512 != "").Select(x => x.Search512).ToList());
            listText.AddRange(text.Where(x => x.Search5120 != "").Select(x => x.Search5120).ToList());
            return listText;
        }
               
        public async Task<IEnumerable<ContentText>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _contentTextService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ContentText>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
        {
            return await _contentTextService.GetAllBySiteNumberAsync(siteNumber, maxPosition);
        }

        public async Task<IEnumerable<ContentText>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
        {
            return await _contentTextService.GetAllBySiteNumberAsync(siteNumber, maxPosition, viewCod);
        }

        public async Task<IEnumerable<ContentText>> GetAllByUserIdAsync(string userId)
        {
            return await _contentTextService.GetAllByUserIdAsync(userId);
        }

        public async Task<IEnumerable<ContentText>> GetAllByUserIdAsync(string userId, int maxPosition)
        {
            return await _contentTextService.GetAllByUserIdAsync(userId, maxPosition);
        }

        public async Task<IEnumerable<ContentText>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await _contentTextService.GetAllByUserIdAsync(userId, maxPosition, viewCod);
        }

        public async Task<ContentText> GetByIdAsync(Guid id, string userId)
        {
            return await _contentTextService.GetByIdAsync(id, userId);
        }

        public async Task<ContentText> GetByAsync(int viewCod, int position, string userId)
        {
            return await _contentTextService.GetByAsync(viewCod, position, userId);
        }

        public async Task<ContentText> GetByAsync(int viewCod, string term, string userId)
        {
            return await _contentTextService.GetByAsync(viewCod, term, userId);
        }

        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _contentTextOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, text32 = obj.Text32, text512 = obj.Text512, text5120 = obj.Text5120 };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<object> GetObjetoAsync(int viewCod, int position, string userId)
        {
            var obj = await _contentTextService.GetByAsync(viewCod, position, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, position = obj.Position, text32 = obj._Text32, text512 = obj._Text512, text5120 = obj._Text5120, stText32 = obj.ContentTextOption.Text32, stText512 = obj.ContentTextOption.Text512, stText5120 = obj.ContentTextOption.Text5120 };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<object> GetObjetoAsync(int viewCod, string search, string userId)
        {
            var obj = await _contentTextService.GetByAsync(viewCod, search, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, position = obj.Position, text32 = obj._Text32, text512 = obj._Text512, text5120 = obj._Text5120, stText32 = obj.ContentTextOption.Text32, stText512 = obj.ContentTextOption.Text512, stText5120 = obj.ContentTextOption.Text5120 };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int viewCod, int position, string text32, string styleText32, string text512, string styleText512, string text5120, string styleText5120)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var text = await _contentTextService.GetByAsync(viewCod, position, userId);
            var textOption = await _contentTextOptionService.PutAsync(styleText32, styleText512, styleText5120, userId);

            if (text != null)
            {
               
                text.Change(viewCod, position, text32, text512, text5120);

                if(textOption.Id == Guid.Empty)
                {
                    if(text.ContentTextOption.Default)
                    {
                        text.AddContentTextOption(textOption);
                    }
                    else
                    {
                        text.ContentTextOption.Change(false, styleText32, styleText512, styleText5120);
                    }
                    _contentTextService.Update(text);
                }
                else
                {
                    var optionOld = text.ContentTextOptionId;
                    bool optionDefault = text.ContentTextOption.Default;

                    text.ChangeContentTextOption(textOption.Id);
                    _contentTextService.Update(text);

                    if (!optionDefault)
                    {
                        var obj = await _contentTextOptionService.GetByIdAsync(optionOld);
                        _contentTextOptionService.Remove(obj);
                    }
                }
                json.Id = text.Id.ToString();
                return json;
            }
            else
            {
                if(textOption.Id == Guid.Empty)
                {
                    text = new ContentText(userId, siteNumber, textOption, viewCod, position, text32, text512, text5120);
                    _contentTextService.Add(text);
                    json.Id = text.Id.ToString();
                    return json;
                }
                else
                {
                    text = new ContentText(userId, siteNumber, textOption.Id, viewCod, position, text32, text512, text5120);
                    _contentTextService.Add(text);
                    json.Id = text.Id.ToString();
                    return json;
                }          
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var text = await _contentTextService.GetByIdAsync(_id, userId);

            if (text != null)
            {
                var optionOld = text.ContentTextOptionId;
                bool optionDefault = text.ContentTextOption.Default;

                _contentTextService.Remove(text);

                if (!optionDefault)
                {
                    var obj = await _contentTextOptionService.GetByIdAsync(optionOld);
                    _contentTextOptionService.Remove(obj);
                }
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(text.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _contentTextService.DeleteAll(userId);
        }                   
    }
}
