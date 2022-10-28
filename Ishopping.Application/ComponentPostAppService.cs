using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class ComponentPostAppService : AppServiceBaseT2<ComponentPost>, IComponentPostAppService
    {
        private readonly IComponentPostService _componentPostService;
        private readonly IComponentPostOptionService _componentPostOptionService;
        private readonly IUserImageGalleryService _userImageGalleryService;   

        public ComponentPostAppService(
            IComponentPostService componentPostService,
            IComponentPostOptionService componentPostOptionService,
            IUserImageGalleryService userImageGalleryService)
            :base(componentPostService)
        {
            _componentPostService = componentPostService;
            _componentPostOptionService = componentPostOptionService;
            _userImageGalleryService = userImageGalleryService;
        }

        public IEnumerable<string> Search(string startsWith, string userId)
        {
            return _componentPostService.Search(startsWith, userId);
        }

        public ComponentPost GetByImageId(Guid imageId)
        {
            return _componentPostService.GetByImageId(imageId);
        }

        public IEnumerable<ComponentPost> GetAllBySiteNumber(int siteNumber)
        {
            return _componentPostService.GetAllBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentPost> GetOrderByDate(int siteNumber, int take)
        {
            return _componentPostService.GetOrderByDate(siteNumber, take);
        }

        public ComponentPost Get(string title, string userId)
        {
            return _componentPostService.GetByTerm(title, userId);
        }
                
        public ComponentPost GetBySiteNumber(int siteNumber)
        {
            return _componentPostService.GetBySiteNumber(siteNumber);
        }

        public IEnumerable<ComponentPost> GetAllByUserId(string userId)
        {
            return _componentPostService.GetAllByUserId(userId);
        }

        public ComponentPost GetById(Guid id, string userId)
        {
            return _componentPostService.GetById(id, userId);
        }

        public ComponentPost GetByTerm(string title, string userId)
        {
            return _componentPostService.GetByTerm(title, userId);
        }
               
        
        // Async Methods
        public async Task<IEnumerable<string>> SearchAsync(string startsWith, string userId)
        {
            return await _componentPostService.SearchAsync(startsWith, userId);
        }

        public async Task<IEnumerable<string>> SearchAsync(string startsWith)
        {
            return await _componentPostService.SearchAsync(startsWith);
        }

        public async Task<ComponentPost> GetByImageIdAsync(Guid imageId)
        {
            return await _componentPostService.GetByImageIdAsync(imageId);
        }

        public async Task<ComponentPost> GetBySiteNumberAsync(int siteNumber)
        {
            return await _componentPostService.GetBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPost>> GetAllBySiteNumberAsync(int siteNumber)
        {
            return await _componentPostService.GetAllBySiteNumberAsync(siteNumber);
        }

        public async Task<IEnumerable<ComponentPost>> GetAllByUserIdAsync(string userId)
        {
            return await _componentPostService.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentPost> GetByIdAsync(Guid id, string userId)
        {
            return await _componentPostService.GetByIdAsync(id, userId);
        }

        public async Task<ComponentPost> GetByTermAsync(string term, string userId)
        {
            return await _componentPostService.GetByTermAsync(term, userId);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByTermAsync(string term)
        {
            return await _componentPostService.GetAllByTermAsync(term);
        }

        public async Task<IEnumerable<string>> GetAllCategoryAsync()
        {
            return await _componentPostService.GetAllCategoryAsync();
        }


        // Other Methods
        public ComponentPost GetPostById(Guid id)
        {             
            if (id != Guid.Empty)
            {
                var componentPost = _componentPostService.GetBy(id);
                componentPost.AddView(); // adiciona uma visualização mas ta muito pesado 
                _componentPostService.Update(componentPost);  
                return componentPost;
            }
            return null;
        }          
                
        public void AddBy(ComponentPost componentPost)
        {
            _componentPostService.AddBy(componentPost);
        }
        
        public void UpdateBy(ComponentPost componentPost)
        {
            _componentPostService.UpdateBy(componentPost);
        }


        // Async Methods for SinglePost
        public async Task<SinglePost> GetSinglePostByIdAsync(Guid id)
        {
            return await _componentPostService.GetSinglePostByIdAsync(id);
        }

        // Async Methods for SimplePost
        public async Task<IEnumerable<SimplePost>> GetAllBySiteNumberAsync(int siteNumber, int take)
        {
            return await _componentPostService.GetAllBySiteNumberAsync(siteNumber, take);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(int take)
        {
            return await _componentPostService.GetAllByLastDateAsync(take);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(int siteNumber, int take)
        {
            return await _componentPostService.GetAllByLastDateAsync(siteNumber, take);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(string category, int take)
        {
            return await _componentPostService.GetAllByLastDateAsync(category, take);
        }               

        public async Task<IEnumerable<SimplePost>> GetAllByCategoryAsync(string category, int take)
        {
            return await _componentPostService.GetAllByCategoryAsync(category, take);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByCategoryAsync(string category, int siteNumber, int take)
        {
            return await _componentPostService.GetAllByCategoryAsync(category, siteNumber, take);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByViewsAsync(int take)
        {
            return await _componentPostService.GetAllByViewsAsync(take);
        }

        public async Task<IEnumerable<SimplePost>> GetAllByViewsAsync(int siteNumber, int take)
        {
            return await _componentPostService.GetAllByViewsAsync(siteNumber, take);
        }               

        
        // Methods for Persist
        public async Task<object> GetDefaoutStyleAsync(string userId)
        {
            var obj = await _componentPostOptionService.GetDefaultAsync(userId);
            if (obj != null)
            {
                return new { FileFound = true, autor = obj.Autor, categoria = obj.Categoria, paragrafo = obj.Paragrafo, subTitulo = obj.SubTitulo, titulo = obj.Titulo };
            }
            else
            {
                return new JsonFileNotFound();
            }
        }

        public async Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, bool isBlock, bool displayOnPage, bool displayOnlyPage, string model, string title, string styleTitle, string autor, string styleAutor, string categoria, string styleCategoria, string subTitulo1, string styleSubTitle, string paragrafo1, string styleParagrafo, string subTitulo2, string paragrafo2, string subTitulo3, string paragrafo3, string img1, string img2, string img3, string video, string tags)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            JsonResponse json = new JsonResponse();

            var listImg = new List<string>() { img1, img2, img3 };

            var listImageGallery = await _userImageGalleryService.GetAllisContainAsync(listImg, 10, userId);

            if (listImageGallery.Count() == 0)         
            {
                json.Redirect = false;
                json.Message = "Imagem não encontrada";
                return json;
            }

            var postOption = await _componentPostOptionService.PutAsync(styleAutor, styleCategoria, styleTitle, styleSubTitle, styleParagrafo, userId);

            if (_id != Guid.Empty)
            {
                var post = await _componentPostService.GetByIdAsync(_id, userId);
                List<string> listImg2 = post.UserImageGallery.Select(x => x.FileName).ToList();
                json.Redirect = listImg.Except(listImg2).Any();
                post.Change(listImageGallery.ToList(), displayOnPage, displayOnlyPage, model, title, paragrafo1, autor, categoria, subTitulo1, subTitulo2, paragrafo2, subTitulo3, paragrafo3, video, tags);             

                if(postOption.Id == Guid.Empty)
                {
                    if(post.ComponentPostOption.Default)
                    {
                        post.AddComponentPostOption(postOption);
                    }
                    else
                    {
                        post.ComponentPostOption.Change(false, styleAutor, styleCategoria, styleTitle, styleSubTitle, styleParagrafo);
                    }
                    _componentPostService.UpdateBy(post);
                }
                else
                {
                    var optionOld = post.ComponentPostOptionId;
                    bool optionDefault = post.ComponentPostOption.Default;

                    post.ChangeComponentPostOption(postOption.Id);
                    _componentPostService.UpdateBy(post);

                    if (!optionDefault)
                    {
                        var obj = await _componentPostOptionService.GetByIdAsync(optionOld);
                        _componentPostOptionService.Remove(obj);
                    }
                }          
                json.Id = post.Id.ToString();
                return json;
            }
            else
            {
                if(postOption.Id == Guid.Empty)
                {
                    var post = new ComponentPost(userId, siteNumber, isBlock, listImageGallery.ToList(), postOption, displayOnPage, displayOnlyPage, model, title, paragrafo1, autor, categoria, subTitulo1, subTitulo2, paragrafo2, subTitulo3, paragrafo3, video, tags);
                    _componentPostService.AddBy(post);
                }
                else
                {
                    var post = new ComponentPost(userId, siteNumber, isBlock, listImageGallery.ToList(), postOption.Id, displayOnPage, displayOnlyPage, model, title, paragrafo1, autor, categoria, subTitulo1, subTitulo2, paragrafo2, subTitulo3, paragrafo3, video, tags);
                    _componentPostService.AddBy(post);
                }           
                json.Redirect = true;
                return json;
            }
        }

        public async Task<JsonDelete> AppDeleteAsync(string id, string userId)
        {
            Guid _id = new Guid();
            Guid.TryParse(id, out _id);

            var post = await _componentPostService.GetByIdAsync(_id, userId);

            if (post != null)
            {
                var optionOld = post.ComponentPostOptionId;
                bool optionDefault = post.ComponentPostOption.Default;

                _componentPostService.Remove(post);

                if (!optionDefault)
                {
                    var obj = await _componentPostOptionService.GetByIdAsync(optionOld);
                    _componentPostOptionService.Remove(obj);
                }
                return new JsonDelete(true);
            }
            else
            {
                return new JsonDelete(post.Id.ToString());
            }
        }

        public void DeleteAll(string userId)
        {
            _componentPostService.DeleteAll(userId);
        }
                
    }
}
