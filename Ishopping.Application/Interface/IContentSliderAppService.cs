using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IContentSliderAppService : IAppServiceBaseT2<ContentSlider>, IContentAppServiceBaseT1<ContentSlider>, IContentAppServiceBaseT1Async<ContentSlider>
    {
        // Sync Methods
        List<ContentSlider> GetAllByViewCod(int viewCod, int sliderPosition, string userId);
        ContentSlider GetByImageId(Guid imageId);
        void AddRanger(IEnumerable<ContentSlider> contentSlider);
        
        // Async Methods
        Task<List<ContentSlider>> GetAllByViewCodAsync(int viewCod, int sliderPosition, string userId);
        Task<ContentSlider> GetByImageIdAsync(Guid imageId);
        Task<JsonResponse> AppUpdateAsync(string userId, ContentSlider contentSlider);
        Task<JsonDelete> AppDeleteAsync(string id, string userId);
    }
}
