using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ContentSliderService : ServiceBaseT2<ContentSlider>, IContentSliderService
    {
         private readonly IContentSliderRepository _contentSliderRepository;
         private readonly IContentSliderDapperRepository _contentSliderDapperRepository;

         public ContentSliderService(
             IContentSliderRepository contentSliderRepository,
             IContentSliderDapperRepository contentSliderDapperRepository)
            : base(contentSliderRepository)
        {
            _contentSliderRepository = contentSliderRepository;
            _contentSliderDapperRepository = contentSliderDapperRepository;
        }

         public IEnumerable<ContentSlider> GetAllBySiteNumber(int siteNumber)
         {
             return _contentSliderDapperRepository.GetAllBySiteNumber(siteNumber);
         }

         public IEnumerable<ContentSlider> GetAllBySiteNumber(int siteNumber, int maxPosition)
         {
             return _contentSliderDapperRepository.GetAllBySiteNumber(siteNumber, maxPosition);
         }

        public IEnumerable<ContentSlider> GetAllBySiteNumber(int siteNumber, int maxPosition, int viewCod)
        {
            return _contentSliderDapperRepository.GetAllBySiteNumber(siteNumber, maxPosition, viewCod);
        }

        public IEnumerable<ContentSlider> GetAllByUserId(string userId)
         {
             return _contentSliderRepository.GetAllByUserId(userId);
         }

         public IEnumerable<ContentSlider> GetAllByUserId(string userId, int maxPosition)
         {
             return _contentSliderRepository.GetAllByUserId(userId, maxPosition);
         }

        public IEnumerable<ContentSlider> GetAllByUserId(string userId, int maxPosition, int viewCod)
        {
            return _contentSliderRepository.GetAllByUserId(userId, maxPosition, viewCod);
        }

        public ContentSlider GetById(Guid id, string userId)
         {
             return _contentSliderRepository.GetById(id, userId);
         }

         public ContentSlider GetBy(int viewCod, int position, string userId)
         {
             return _contentSliderRepository.GetBy(viewCod, position, userId);
         }

         public List<ContentSlider> GetAllByViewCod(int viewCod, int sliderPosition, string userId)
         {
             return _contentSliderRepository.GetAllByViewCod(viewCod, sliderPosition, userId);
         }

         public ContentSlider GetByImageId(Guid imageId)
         {
             return _contentSliderRepository.GetByImageId(imageId);
         }

         public void DeleteAll(string userId)
         {
             _contentSliderRepository.DeleteAll(userId);
         }         

         public void AddRanger(IEnumerable<ContentSlider> contentSlider)
         {
             _contentSliderRepository.AddRanger(contentSlider);
         }


        // Async Methods
         public async Task<IEnumerable<ContentSlider>> GetAllBySiteNumberAsync(int siteNumber)
         {
             return await _contentSliderDapperRepository.GetAllBySiteNumberAsync(siteNumber);
         }

         public async Task<IEnumerable<ContentSlider>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition)
         {
             return await _contentSliderDapperRepository.GetAllBySiteNumberAsync(siteNumber, maxPosition);
         }

         public async Task<IEnumerable<ContentSlider>> GetAllBySiteNumberAsync(int siteNumber, int maxPosition, int viewCod)
         {
            return await _contentSliderDapperRepository.GetAllBySiteNumberAsync(siteNumber, maxPosition, viewCod);
         }

        public async Task<IEnumerable<ContentSlider>> GetAllByUserIdAsync(string userId)
         {
             return await _contentSliderRepository.GetAllByUserIdAsync(userId);
         }

         public async Task<IEnumerable<ContentSlider>> GetAllByUserIdAsync(string userId, int maxPosition)
         {
             return await _contentSliderRepository.GetAllByUserIdAsync(userId, maxPosition);
         }

        public async Task<IEnumerable<ContentSlider>> GetAllByUserIdAsync(string userId, int maxPosition, int viewCod)
        {
            return await _contentSliderRepository.GetAllByUserIdAsync(userId, maxPosition, viewCod);
        }

        public async Task<ContentSlider> GetByIdAsync(Guid id, string userId)
         {
             return await _contentSliderRepository.GetByIdAsync(id, userId);
         }

         public async Task<ContentSlider> GetByAsync(int viewCod, int position, string userId)
         {
             return await _contentSliderRepository.GetByAsync(viewCod, position, userId);
         }

         public async Task<List<ContentSlider>> GetAllByViewCodAsync(int viewCod, int sliderPosition, string userId)
         {
             return await _contentSliderRepository.GetAllByViewCodAsync(viewCod, sliderPosition, userId);
         }

         public async Task<ContentSlider> GetByImageIdAsync(Guid imageId)
         {
             return await _contentSliderRepository.GetByImageIdAsync(imageId);
         }
    }
}
