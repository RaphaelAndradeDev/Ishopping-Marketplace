using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentPanelAppService : AppServiceBaseT2<ComponentPanel>, IComponentPanelAppService
    {
        private readonly IComponentPanelService _componentPanelService;
        private readonly IComponentPanelOptionService _componentPanelOptionService;

        public ComponentPanelAppService(
            IComponentPanelService componentPanelService,
            IComponentPanelOptionService componentPanelOptionService)
            :base(componentPanelService)
        {
            _componentPanelService = componentPanelService;
            _componentPanelOptionService = componentPanelOptionService;
        }

        public IEnumerable<string> Search(string startsWith, int position, string userId)
        {
            return _componentPanelService.Search(startsWith, position, userId);
        }

        public IEnumerable<ComponentPanel> GetAllBySiteNumber(int siteNumber)
        {
            return _componentPanelService.GetAllBySiteNumber(siteNumber);
        }

        public ComponentPanel GetBySiteNumber(int siteNumber)
        {
            return _componentPanelService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentPanel> GetAllByUserId(string userId)
        {
            return _componentPanelService.GetAllByUserId(userId);
        }

        public ComponentPanel GetById(Guid id, string userId)
        {
            return _componentPanelService.GetById(id, userId);
        }

        public ComponentPanel GetBy(string title, int position, string userId)
        {
            return _componentPanelService.GetBy(title, position, userId);
        }


        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, int position, string userId)
        {
            return await _componentPanelService.SearchAsync(startsWith, position, userId);
        }

        public async Task<ComponentPanel> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentPanelService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPanel>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentPanelService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPanel>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPanelService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPanel> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPanelService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPanel> GetByAsync(string search, int position, string userId)
        {
            return await _componentPanelService.GetByAsync(search, position, userId);
        }


        // Others Methods
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentPanelOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, title = obj.Title, text = obj.Text };
            }
            else
            {
                return new JsonFileNotFound();
            } 
        }

        public async Task<object> GetObjetoAsync(string search, int position, string userId)
        {
            var obj = await _componentPanelService.GetByAsync(search, position, userId);
            if (obj != null)
            {
                return new { FileFound = true, id = obj.Id, title = obj._Title, icon = obj.Icon, text = obj._Text, stTitle = obj.ComponentPanelOption.Title, stText = obj.ComponentPanelOption.Text };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, int position, string title, string styleTitle, string text, string styleText, string icon)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var panelOption = await _componentPanelOptionService.PutAsync(styleTitle, styleText, userId);

            if (_id != Guid.Empty)
            {
                var panel = await _componentPanelService.GetByIdAsync(_id, userId);
                panel.Change(title, text, icon, position);

                if(panelOption.Id == Guid.Empty)
                {
                    if(panel.ComponentPanelOption.Default)
                    {
                        panel.AddComponentPanelOption(panelOption);
                    }
                    else
                    {
                        panel.ComponentPanelOption.Change(false, styleTitle, styleText);
                    }
                    _componentPanelService.Update(panel);
                }
                else
                {
                    var optionOld = panel.ComponentPanelOptionId;
                    bool optionDefault = panel.ComponentPanelOption.Default;

                    panel.ChangeComponentPanelOption(panelOption.Id);
                    _componentPanelService.Update(panel);

                    if (!optionDefault)
                    {
                        var obj = await _componentPanelOptionService.GetByIdAsync(optionOld);
                        _componentPanelOptionService.Remove(obj);
                    }
                }
                json.Id = panel.Id.ToString();
                return json;
            }
            else
            {
                 if(panelOption.Id == Guid.Empty)
                 {
                     var panel = new ComponentPanel(userId, siteNumber, panelOption, title, text, icon, position);
                     _componentPanelService.Add(panel);
                     json.Id = panel.Id.ToString();
                     return json;
                 }
                 else
                 {
                     var panel = new ComponentPanel(userId, siteNumber, panelOption.Id, title, text, icon, position);
                     _componentPanelService.Add(panel);
                     json.Id = panel.Id.ToString();
                     return json;
                 }          
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var panel = await _componentPanelService.GetByIdAsync(_id, userId);

            if (panel != null)
            {
                var optionOld = panel.ComponentPanelOptionId;
                bool optionDefault = panel.ComponentPanelOption.Default;

                _componentPanelService.Remove(panel);

                if (!optionDefault)
                {
                    var obj = await _componentPanelOptionService.GetByIdAsync(optionOld);
                    _componentPanelOptionService.Remove(obj);
                }
                return new JsonDelete();
            }
            else
            {
                return new JsonDelete(panel.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentPanelService.DeleteAll(userId);
        }
    }
}
