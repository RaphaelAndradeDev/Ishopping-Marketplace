using Ishopping.Application.Common;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentPostAppService : IAppServiceBaseT2<ComponentPost>, IComponentAppServiceBaseT2<ComponentPost>, IComponentAppServiceBaseT2Async<ComponentPost>
    {        
        ComponentPost GetByImageId(Guid imageId);
        ComponentPost GetPostById(Guid Id);
        IEnumerable<ComponentPost> GetOrderByDate(int siteNumber, int take);        
        void AddBy(ComponentPost componentPost);
        void UpdateBy(ComponentPost componentPost); 
        

        // Async Methods
        Task<IEnumerable<string>> SearchAsync(string startsWith);
        Task<ComponentPost> GetByImageIdAsync(Guid imageId);
        Task<IEnumerable<SimplePost>> GetAllByTermAsync(string term);
        Task<object> GetDefaoutStyleAsync(string userId);
        Task<JsonResponse> AppUpdateAsync(string id, string userId, int siteNumber, bool isBlock, bool displayOnPage, bool displayOnlyPage, string model, string title, string styleTitle, string autor, string styleAutor, string categoria, string styleCategoria, string subTitulo1, string styleSubTitle, string paragrafo1, string styleParagrafo, string subTitulo2, string paragrafo2, string subTitulo3, string paragrafo3, string img1, string img2, string img3, string video, string tags);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
        Task<IEnumerable<string>> GetAllCategoryAsync();

        // Async Methods for SinglePost
        Task<SinglePost> GetSinglePostByIdAsync(Guid id);

        // Async Methods for SimplePost
        Task<IEnumerable<SimplePost>> GetAllBySiteNumberAsync(int siteNumber, int take);
        Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(int take);
        Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(int siteNumber, int take);
        Task<IEnumerable<SimplePost>> GetAllByLastDateAsync(string category, int take);
        Task<IEnumerable<SimplePost>> GetAllByCategoryAsync(string category, int take);
        Task<IEnumerable<SimplePost>> GetAllByCategoryAsync(string category, int siteNumber, int take);
        Task<IEnumerable<SimplePost>> GetAllByViewsAsync(int take);
        Task<IEnumerable<SimplePost>> GetAllByViewsAsync(int siteNumber, int take);
    }
}
