using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IContentSliderService : IServiceBaseT2<ContentSlider>, IContentServiceBaseT1<ContentSlider>, IContentServiceBaseT1Async<ContentSlider>
    {        
        List<ContentSlider> GetAllByViewCod(int viewCod, int sliderPosition, string userId);
        ContentSlider GetByImageId(Guid imageId);
        void AddRanger(IEnumerable<ContentSlider> contentSlider);

        // Async Methods
        Task<List<ContentSlider>> GetAllByViewCodAsync(int viewCod, int sliderPosition, string userId);
        Task<ContentSlider> GetByImageIdAsync(Guid imageId);
    }
}
