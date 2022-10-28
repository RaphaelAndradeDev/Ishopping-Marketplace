using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ConfigUserStyleClassAppService : AppServiceBaseT2<ConfigUserStyleClass>, IConfigUserStyleClassAppService
    {
        private readonly IConfigUserStyleClassService _configUserStyleClassService;
        private readonly IComponentActivityOptionService _componentActivityOptionService;
        private readonly IComponentBrandOptionService _componentbrandOptionService;
        private readonly IComponentClientOptionService _componentClientOptionService;
        private readonly IComponentExtraLinkOptionService _componentExtraLinkOptionService;
        private readonly IComponentFaqOptionService _componentFaqOptionService;
        private readonly IComponentFeaturesOptionService _componentFeaturesOptionService;
        private readonly IComponentMenuOptionService _componentMenuOptionService;
        private readonly IComponentPanelOptionService _componentPanelOptionService;
        private readonly IComponentPortfolioOptionService _componentPortfolioOptionService;
        private readonly IComponentPostOptionService _componentPostOptionService;
        private readonly IComponentPresentationOptionService _componentPresentationOptionService;
        private readonly IComponentPricingOptionService _componentPricingOptionService;
        private readonly IComponentProjectOptionService _componentProjectOptionService;
        private readonly IComponentScopeOptionService _componentScopeOptionService;
        private readonly IComponentServiceOptionService _componentServiceOptionService;
        private readonly IComponentSimpleProductOptionService _componentSimpleProductOptionService;
        private readonly IComponentSkillOptionService _componentSkillOptionService;
        private readonly IComponentSummaryOptionService _componentSummaryOptionService;
        private readonly IComponentTeamOptionService _componentTeamOptionService;
        private readonly IContentButtonOptionService _contentButtonOptionService;
        private readonly IContentListOptionService _contentListOptionService;
        private readonly IContentTextOptionService _contentTextOptionService;
        private readonly IConfigUserViewItemService _configUserViewItemService;
        private readonly IUserRegisterProfileService _userRegisterProfileService;
   

        public ConfigUserStyleClassAppService(
            IConfigUserStyleClassService configUserStyleClassService,
            IComponentActivityOptionService componentActivityOptionService,
            IComponentBrandOptionService componentbrandOptionService,
            IComponentClientOptionService componentClientOptionService,
            IComponentExtraLinkOptionService componentExtraLinkOptionService,
            IComponentFaqOptionService componentFaqOptionService,
            IComponentFeaturesOptionService componentFeaturesOptionService,
            IComponentMenuOptionService componentMenuOptionService,
            IComponentPanelOptionService componentPanelOptionService,
            IComponentPortfolioOptionService componentPortfolioOptionService,
            IComponentPostOptionService componentPostOptionService,
            IComponentPresentationOptionService componentPresentationOptionService,
            IComponentPricingOptionService componentPricingOptionService,
            IComponentProjectOptionService componentProjectOptionService,
            IComponentScopeOptionService componentScopeOptionService,
            IComponentServiceOptionService componentServiceOptionService,
            IComponentSimpleProductOptionService componentSimpleProductOptionService,
            IComponentSkillOptionService componentSkillOptionService,
            IComponentSummaryOptionService componentSummaryOptionService,
            IComponentTeamOptionService componentTeamOptionService,
            IContentButtonOptionService contentButtonOptionService,
            IContentListOptionService contentListOptionService,
            IContentTextOptionService contentTextOptionService,
            IConfigUserViewItemService configUserViewItemService,
            IUserRegisterProfileService userRegisterProfileService
            )
            :base(configUserStyleClassService)
        {
            _configUserStyleClassService = configUserStyleClassService;
            _componentActivityOptionService = componentActivityOptionService;
            _componentbrandOptionService = componentbrandOptionService;
            _componentClientOptionService = componentClientOptionService;
            _componentExtraLinkOptionService = componentExtraLinkOptionService;
            _componentFaqOptionService = componentFaqOptionService;
            _componentFeaturesOptionService = componentFeaturesOptionService;
            _componentMenuOptionService = componentMenuOptionService;
            _componentPanelOptionService = componentPanelOptionService;
            _componentPortfolioOptionService = componentPortfolioOptionService;
            _componentPostOptionService = componentPostOptionService;
            _componentPresentationOptionService = componentPresentationOptionService;
            _componentPricingOptionService = componentPricingOptionService;
            _componentProjectOptionService = componentProjectOptionService;
            _componentScopeOptionService = componentScopeOptionService;
            _componentServiceOptionService = componentServiceOptionService;
            _componentSimpleProductOptionService = componentSimpleProductOptionService;
            _componentSkillOptionService = componentSkillOptionService;
            _componentSummaryOptionService = componentSummaryOptionService;
            _componentTeamOptionService = componentTeamOptionService;
            _contentButtonOptionService = contentButtonOptionService;
            _contentListOptionService = contentListOptionService;
            _contentTextOptionService = contentTextOptionService;
            _configUserViewItemService = configUserViewItemService;
            _userRegisterProfileService = userRegisterProfileService;
        }

        public void AddRanger(IEnumerable<ConfigUserStyleClass> configUserStyleClass)
        {
            _configUserStyleClassService.AddRanger(configUserStyleClass);
        }

        public ConfigUserStyleClass GetById(Guid id, string userId)
        {
            return _configUserStyleClassService.GetById(id, userId);
        }        

        public IEnumerable<ConfigUserStyleClass> GetAllByUserId(string userId)
        {
            return _configUserStyleClassService.GetAllByUserId(userId);
        }

        public ConfigUserStyleClass GetByClassName(string className, string userId)
        {
            return _configUserStyleClassService.GetByClassName(className, userId);
        }


        // Async Methods 
        public async Task<IEnumerable<string>> GetAllClassNameAsync(string userId)
        {
            return await _configUserStyleClassService.GetAllClassNameAsync(userId);
        }

        public async Task<ConfigUserStyleClass> GetByIdAsync(Guid id, string userId)
        {
            return await _configUserStyleClassService.GetByIdAsync(id, userId);
        }

        public async Task<IEnumerable<ConfigUserStyleClass>> GetAllByUserIdAsync(string userId)
        {
            return await _configUserStyleClassService.GetAllByUserIdAsync(userId);
        }

        public async Task<ConfigUserStyleClass> GetByClassNameAsync(string className, string userId)
        {
            return await _configUserStyleClassService.GetByClassNameAsync(className, userId);
        }


        // Other Methods
        public JsonResponse AppUpdate(string userId, int siteNumber, string oldGoogleFonts, string googleFonts, string oldName, ConfigUserStyleClass configUserStyleClass)
        {        
            var _id = configUserStyleClass.Id;

            JsonResponse json = new JsonResponse();
            json.Serialize = false;

            if(configUserStyleClass.ClassName == "SemEstilo")
            {
                json.Message = "Já existe uma classe com o nome SemEstilo";
                json.Serialize = false;
                return json;
            }
                       
            configUserStyleClass.IdUser = userId;
            configUserStyleClass.SiteNumber = siteNumber;                    

            if (_id != Guid.Empty)
            {
                if (oldName != configUserStyleClass.ClassName)
                {
                    StyleReplace(userId, oldName, configUserStyleClass.ClassName);
                    json.Serialize = true;
                }
                _configUserStyleClassService.Update(configUserStyleClass);
                json.Id = configUserStyleClass.Id.ToString();
            }
            else
            {
                _configUserStyleClassService.Add(configUserStyleClass);
                json.Id = configUserStyleClass.Id.ToString();
            }

            if (oldGoogleFonts != googleFonts)
            {
                _userRegisterProfileService.SetGoogleFonts(userId, googleFonts);
                json.Serialize = true;
            }                        

            var styles = _configUserStyleClassService.GetAllByUserId(userId);
            json.Response = StyleGenerate(styles);          
            return json;
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var json = new JsonDelete(redirect: true);

            var styleClass = await _configUserStyleClassService.GetByIdAsync(_id, userId);

            if (styleClass != null)
            {
                StyleRemove(userId, styleClass.ClassName);
                _configUserStyleClassService.Remove(styleClass);
                var styles = await _configUserStyleClassService.GetAllByUserIdAsync(userId);
                json.Response = StyleGenerate(styles);
                return json;
            }
            else
            {
                return new JsonDelete(styleClass.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _configUserStyleClassService.DeleteAll(userId);
        }


        // Private methods
        private void StyleReplace(string userId, string name, string replace)
        {
            _componentActivityOptionService.StyleReplace(userId, name, replace);
            _componentbrandOptionService.StyleReplace(userId, name, replace);
            _componentClientOptionService.StyleReplace(userId, name, replace);
            _componentExtraLinkOptionService.StyleReplace(userId, name, replace);
            _componentFaqOptionService.StyleReplace(userId, name, replace);
            _componentFeaturesOptionService.StyleReplace(userId, name, replace);
            _componentMenuOptionService.StyleReplace(userId, name, replace);
            _componentPanelOptionService.StyleReplace(userId, name, replace);
            _componentPortfolioOptionService.StyleReplace(userId, name, replace);
            _componentPostOptionService.StyleReplace(userId, name, replace);
            _componentPresentationOptionService.StyleReplace(userId, name, replace);
            _componentPricingOptionService.StyleReplace(userId, name, replace);
            _componentProjectOptionService.StyleReplace(userId, name, replace);
            _componentScopeOptionService.StyleReplace(userId, name, replace);
            _componentServiceOptionService.StyleReplace(userId, name, replace);
            _componentSimpleProductOptionService.StyleReplace(userId, name, replace);
            _componentSkillOptionService.StyleReplace(userId, name, replace);
            _componentSummaryOptionService.StyleReplace(userId, name, replace);
            _componentTeamOptionService.StyleReplace(userId, name, replace);
            _contentButtonOptionService.StyleReplace(userId, name, replace);
            _contentListOptionService.StyleReplace(userId, name, replace);
            _contentTextOptionService.StyleReplace(userId, name, replace);
            _configUserViewItemService.StyleReplace(userId, name, replace);
        }

        private void StyleRemove(string userId, string name)
        {
            _componentActivityOptionService.StyleRemove(userId, name);
            _componentbrandOptionService.StyleRemove(userId, name);
            _componentClientOptionService.StyleRemove(userId, name);
            _componentExtraLinkOptionService.StyleRemove(userId, name);
            _componentFaqOptionService.StyleRemove(userId, name);
            _componentFeaturesOptionService.StyleRemove(userId, name);
            _componentMenuOptionService.StyleRemove(userId, name);
            _componentPanelOptionService.StyleRemove(userId, name);
            _componentPortfolioOptionService.StyleRemove(userId, name);
            _componentPostOptionService.StyleRemove(userId, name);
            _componentPresentationOptionService.StyleRemove(userId, name);
            _componentPricingOptionService.StyleRemove(userId, name);
            _componentProjectOptionService.StyleRemove(userId, name);
            _componentScopeOptionService.StyleRemove(userId, name);
            _componentServiceOptionService.StyleRemove(userId, name);
            _componentSimpleProductOptionService.StyleRemove(userId, name);
            _componentSkillOptionService.StyleRemove(userId, name);
            _componentSummaryOptionService.StyleRemove(userId, name);
            _componentTeamOptionService.StyleRemove(userId, name);
            _contentButtonOptionService.StyleRemove(userId, name);
            _contentListOptionService.StyleRemove(userId, name);
            _contentTextOptionService.StyleRemove(userId, name);
            _configUserViewItemService.StyleRemove(userId, name);
        }

        private static string StyleGenerate(IEnumerable<ConfigUserStyleClass> configUserStyleClass)
        {
            string styleClass = string.Empty;

            foreach (var item in configUserStyleClass)
            {
                if (item.UserDefault)
                {
                    bool[] alter = { 
                                         item.DefaultAlterText,
                                         item.DefaultAlterBorder,
                                         item.DefaultAlterBoxShadow,
                                         item.DefaultAlterSize,
                                         item.DefaultAlterTextShadow,
                                         item.DefaultUserTransform,
                                         item.DefaultUserTransition
                                     };

                    string[] style = { 
                                        item.ClassName,
                                        item.ClassFor,
                                        item.DefaultFontSize,
                                        item.DefaultFontFamily,
                                        item.DefaultFontWeight,
                                        item.DefaultFontStyle,
                                        item.DefaultLetterSpacing,
                                        item.DefaultLineHeight,
                                        item.DefaultColor,
                                        item.DefaultBackgroundColor,
                                        item.DefaultBorder,
                                        item.DefaultBoxShadow,
                                        item.DefaultBorderRadius,
                                        item.DefaultTextShadow,
                                        item.DefaultPadding,

                                        item.DefaultTransformRotate,
                                        item.DefaultTransformScaleX,
                                        item.DefaultTransformScaleY,
                                        item.DefaultTransformSkew,
                                        item.DefaultTransformTranslateX,
                                        item.DefaultTransformTranslateY,
                                                                                
                                        item.DefaultTransitionProperty,
                                        item.DefaultTransitionFunction,
                                        item.DefaultTransitionDelay                                        
                                     };

                    styleClass += StyleClassGenerate(1, alter, style, null);
                }

                if (item.UserHover)
                {
                    bool[] alter = { 
                                        item.HoverAlterText,
                                        item.HoverAlterBorder,
                                        item.HoverAlterBoxShadow,
                                        item.HoverAlterSize,
                                        item.HoverAlterTextShadow,
                                        item.HoverUserTransform
                                     };

                    string[] style = { 
                                        item.ClassName,
                                        item.ClassFor,
                                        item.HoverFontSize,
                                        item.HoverFontFamily,
                                        item.HoverFontWeight,
                                        item.HoverFontStyle,
                                        item.HoverLetterSpacing,
                                        item.HoverLineHeight,
                                        item.HoverColor,
                                        item.HoverBackgroundColor,
                                        item.HoverBorder,
                                        item.HoverBoxShadow,
                                        item.HoverBorderRadius,
                                        item.HoverTextShadow,
                                        item.HoverPadding,

                                        item.HoverTransformRotate,
                                        item.HoverTransformScaleX,
                                        item.HoverTransformScaleY,
                                        item.HoverTransformSkew,
                                        item.HoverTransformTranslateX,
                                        item.HoverTransformTranslateY
                                     };
                    styleClass += StyleClassGenerate(2, alter, style, "hover");
                }

                if (item.UserActive)
                {
                    bool[] alter = { 
                                        item.ActiveAlterText,
                                        item.ActiveAlterBorder,
                                        item.ActiveAlterBoxShadow,
                                        item.ActiveAlterSize,
                                        item.ActiveAlterTextShadow,
                                        item.ActiveUserTransform
                                     };

                    string[] style = { 
                                        item.ClassName,
                                        item.ClassFor,
                                        item.ActiveFontSize,
                                        item.ActiveFontFamily,
                                        item.ActiveFontWeight,
                                        item.ActiveFontStyle,
                                        item.ActiveLetterSpacing,
                                        item.ActiveLineHeight,
                                        item.ActiveColor,
                                        item.ActiveBackgroundColor,
                                        item.ActiveBorder,
                                        item.ActiveBoxShadow,
                                        item.ActiveBorderRadius,
                                        item.ActiveTextShadow,
                                        item.ActivePadding,

                                        item.ActiveTransformRotate,
                                        item.ActiveTransformScaleX,
                                        item.ActiveTransformScaleY,
                                        item.ActiveTransformSkew,
                                        item.ActiveTransformTranslateX,
                                        item.ActiveTransformTranslateY
                                     };
                    styleClass += StyleClassGenerate(3, alter, style, "active");
                }

                if (item.UserSpan)
                {
                    bool[] alter = { 
                                        item.SpanAlterText,
                                        item.SpanAlterBorder,
                                        item.SpanAlterBoxShadow,
                                        item.SpanAlterSize,
                                        item.SpanAlterTextShadow,
                                        item.SpanUserTransform
                                     };

                    string[] style = { 
                                        item.ClassName,
                                        item.ClassFor + "span",
                                        item.SpanFontSize,
                                        item.SpanFontFamily,
                                        item.SpanFontWeight,
                                        item.SpanFontStyle,
                                        item.SpanLetterSpacing,
                                        item.SpanLineHeight,
                                        item.SpanColor,
                                        item.SpanBackgroundColor,
                                        item.SpanBorder,
                                        item.SpanBoxShadow,
                                        item.SpanBorderRadius,
                                        item.SpanTextShadow,
                                        item.SpanPadding,

                                        item.SpanTransformRotate,
                                        item.SpanTransformScaleX,
                                        item.SpanTransformScaleY,
                                        item.SpanTransformSkew,
                                        item.SpanTransformTranslateX,
                                        item.SpanTransformTranslateY
                                     };
                    styleClass += StyleClassGenerate(4, alter, style, null);
                }
            }
            return styleClass;
        }

        private static string StyleClassGenerate(int type, bool[] alter, string[] style, string forEvent)
        {
            bool exItem = false;
            const string end = "!important;";
            string styleClass = string.Empty;

            // Nome da class 
            if (!string.IsNullOrEmpty(forEvent))
            {
                styleClass = "." + style[0] + ":" + forEvent + " " + style[1];
                styleClass = styleClass.Trim() + "{";
            }
            else
            {
                styleClass = "." + style[0] + " " + style[1];
                styleClass = styleClass.Trim() + "{";
            }

            if (alter[0]) // AlterText
            {
                if (IsNotZero(style[2]))
                {
                    styleClass += "font-size:" + style[2].Replace(",", "").Trim() + end;
                    exItem = true;
                }

                if (IsNotDefault(style[3]))
                {
                    styleClass += "font-family:'" + style[3] + "'" + end;
                    exItem = true;
                }

                if (IsNotDefault(style[4]))
                {
                    styleClass += "font-weight:" + style[4] + end;
                    exItem = true;
                }

                if (IsNotDefault(style[5]))
                {
                    styleClass += "font-style:" + style[5] + end;
                    exItem = true;
                }

                if (IsNotNullOrNotZero(style[6]))
                {
                    styleClass += "letter-spacing:" + style[6] + "px " + end;
                    exItem = true;
                }

                if (IsNotNullOrNotZero(style[7]))
                {
                    styleClass += "line-height:" + style[7] + "% " + end;
                    exItem = true;
                }

                if (!string.IsNullOrEmpty(style[8]))
                {
                    styleClass += "color:" + style[8] + end;
                    exItem = true;
                }

                if (!string.IsNullOrEmpty(style[9]))
                {
                    styleClass += "background-color:" + style[9] + end;
                    exItem = true;
                }
            }

            if (alter[1])
            {
                styleClass += "border:" + style[10].Replace(",", "px ") + end;
                exItem = true;
            }

            if (alter[2])
            {
                styleClass += "box-shadow:" + style[11].Replace(",", "px ") + end;
                exItem = true;
            }

            if (alter[1])
            {
                styleClass += "border-radius:" + style[12] + "px;";
                exItem = true;
            }

            if (alter[4])
            {
                styleClass += "text-shadow:" + style[13].Replace(",", "px ") + end;
                exItem = true;
            }

            if (alter[3])
            {
                styleClass += "padding:" + style[14].Replace(",", "px ") + "px" + end;
                exItem = true;
            }


            // transform
            if (alter[5])
            {
                string transform = string.Empty;

                if (IsNotNullOrNotZero(style[15]))
                    transform += "rotate(" + style[15] + "deg)";                

                if (IsNotNullOrNotZero(style[16]))
                    transform += "scaleX(" + style[16] + ")";

                if (IsNotNullOrNotZero(style[17]))
                    transform += "scaleY(" + style[17] + ")";

                if (IsNotNullOrNotZero(style[18]))
                    transform += "skew(" + style[18] + "deg)";

                if (IsNotNullOrNotZero(style[19]))
                    transform += "translateX(" + style[19] + "px)";

                if (IsNotNullOrNotZero(style[20]))
                    transform += "translateY(" + style[20] + "px)";

                styleClass += "transform:" + transform + end;
                exItem = true;
            }

            // transition
            if (type == 1 && alter[6])
            {
                styleClass += "transition:" + style[21] + " " + style[22] + " " + style[23] +"s" + end;
                exItem = true;
            }

            styleClass += "}";

            if (exItem)
                return styleClass;
            return null;
        }

        private static bool IsNotNullOrNotZero(string value)
        {
            int x;
            if (int.TryParse(value, out x))
                return x != 0;
            return false;                         
        }

        private static bool IsNotZero(string value)
        {
            string[] v = value.Split(',');
            return IsNotNullOrNotZero(v[0]);
        }

        private static bool IsNotDefault(string value)
        {            
            return !((value.ToLower() == "padrão")||(value.ToLower() == ""));
        }     
                 
    }
}
