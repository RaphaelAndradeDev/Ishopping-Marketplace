using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IComponentPortofolioRepository : IRepositoryBaseT2<ComponentPortofolio>, IComponentRepositoryBaseT1<ComponentPortofolio>, IComponentRepositoryBaseT1Async<ComponentPortofolio>
    {
        ComponentPortofolio GetByImageId(Guid imageId);
        Task<ComponentPortofolio> GetByImageIdAsync(Guid imageId);

        // Async Methods for AppPortfolio
        Task<SimplePortfolio> GetByIdAsync(Guid id);
        Task<IEnumerable<SimplePortfolio>> GetBySiteNumberAsync(int siteNumber, int take);
        Task<IEnumerable<SimplePortfolio>> GetByTitleAsync(int siteNumber, string title, int take);
        Task<IEnumerable<SimplePortfolio>> GetByCategoryAsync(int siteNumber, string categoy, int take);
        Task<IEnumerable<SimplePortfolio>> GetByCategoryAsync(int siteNumber, string categoy, string subCategory, int take);
        Task<IEnumerable<SimplePortfolio>> GetAllBySiteNumberAsync(IEnumerable<int> siteNumber, int take);
        Task<IEnumerable<SimplePortfolio>> GetAllByTitleAsync(string title, int take);
        Task<IEnumerable<SimplePortfolio>> GetAllByCategoryAsync(string categoy, int take);
        Task<IEnumerable<SimplePortfolio>> GetAllByCategoryAsync(string categoy, string subCategory, int take);       
    }
}
