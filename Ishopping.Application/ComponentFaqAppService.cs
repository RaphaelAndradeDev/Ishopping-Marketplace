using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentFaqAppService : AppServiceBaseT2<ComponentFaq>, IComponentFaqAppService
    {
        private readonly IComponentFaqService _componentFaqService;
        private readonly IComponentFaqOptionService _componentFaqOptionService;

        public ComponentFaqAppService(
            IComponentFaqService componentFaqService,
            IComponentFaqOptionService componentFaqOptionService)
            :base(componentFaqService)
        {
            _componentFaqService = componentFaqService;
            _componentFaqOptionService = componentFaqOptionService;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentFaqService.Search(startsWith, position, userId);
        }

        public IEnumerable<ComponentFaq> GetAllBySiteNumber(int siteNumber)
        {
            return _componentFaqService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentFaq GetBySiteNumber(int siteNumber)
        {
            return _componentFaqService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentFaq> GetAllByUserId(string userId)
        {
            return _componentFaqService.GetAllByUserId(userId);
        }

        public ComponentFaq GetById(Guid id, string userId)
        {
            return _componentFaqService.GetById(id, userId);
        }

        public ComponentFaq GetBy(string title, int position, string userId)
        {
            return _componentFaqService.GetBy(title, position, userId);
        }

        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentFaqService.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentFaq> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentFaqService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentFaq>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentFaqService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentFaq>> GetAllByUserIdAsync(string userId)
        {
            return await _componentFaqService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentFaq> GetByIdAsync(Guid id, string userId)
        {
            return await _componentFaqService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentFaq> GetByAsync(string search, int position, string userId)
        {
            return await _componentFaqService.GetByAsync(search, position, userId);
        }


        // Others Methos    
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentFaqOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, pergunta = obj.Pergunta, resposta = obj.Resposta };
            }
            else
            {
                return new JsonFileNotFound();
            } 
        }

        public async Task<object> GetObjetoAsync(string search, int position, string userId)
        {
            var obj = await _componentFaqService.GetByAsync(search, position, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, pergunta = obj._Pergunta, resposta = obj._Resposta, category = obj.Category, stPergunta = obj.ComponentFaqOption.Pergunta, stResposta = obj.ComponentFaqOption.Resposta };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string pergunta, string stylePergunta, string resposta, string styleResposta, string categoria)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var faqOption = await _componentFaqOptionService.PutAsync(stylePergunta, styleResposta, userId);

            if (_id != Guid.Empty)
            {
                var faq = await _componentFaqService.GetByIdAsync(_id, userId);
                faq.Change(faqOption.Id, pergunta, resposta, categoria, position);

                if(faqOption.Id == Guid.Empty)
                {
                    if(faq.ComponentFaqOption.Default)
                    {
                        faq.AddComponentFaqOption(faqOption);
                    }
                    else
                    {
                        faq.ComponentFaqOption.Change(false, stylePergunta, styleResposta);
                    }
                    _componentFaqService.Update(faq);
                }
                else
                {
                    var optionOld = faq.ComponentFaqOptionId;
                    bool optionDefault = faq.ComponentFaqOption.Default;

                    faq.ChangeComponentFaqOption(faqOption.Id);
                    _componentFaqService.Update(faq);

                    if (!optionDefault)
                    {
                        var obj = await _componentFaqOptionService.GetByIdAsync(optionOld);
                        _componentFaqOptionService.Remove(obj);
                    } 
                }
                json.Id = faq.Id.ToString();
                return json;
            }
            else
            {
                if(faqOption.Id == Guid.Empty)
                {
                    var faq = new ComponentFaq(userId, siteNumber, faqOption, pergunta, resposta, categoria, position);
                    _componentFaqService.Add(faq);
                    json.Id = faq.Id.ToString();
                    return json;
                }
                else
                {
                    var faq = new ComponentFaq(userId, siteNumber, faqOption.Id, pergunta, resposta, categoria, position);
                    _componentFaqService.Add(faq);
                    json.Id = faq.Id.ToString();
                    return json;
                }                          
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var faq = await _componentFaqService.GetByIdAsync(_id, userId);

            if (faq != null)
            {
                var optionOld = faq.ComponentFaqOptionId;
                bool optionDefault = faq.ComponentFaqOption.Default;

                _componentFaqService.Remove(faq);

                if (!optionDefault)
                {
                    var obj = await _componentFaqOptionService.GetByIdAsync(optionOld);
                    _componentFaqOptionService.Remove(obj);
                }
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(faq.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentFaqService.DeleteAll(userId);
        }
    }
}
