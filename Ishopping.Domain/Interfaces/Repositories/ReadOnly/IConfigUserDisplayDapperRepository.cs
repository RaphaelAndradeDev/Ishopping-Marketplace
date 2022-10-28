using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IConfigUserDisplayDapperRepository
    {
        Task<IEnumerable<ConfigUserDisplay>> GetAllByGeolocationAsync(double latitude, double longitude);
        Task<IEnumerable<BasicDisplay>> GetAllBasicByGeolocationAsync(double latitude, double longitude);    
        Task<IEnumerable<ConfigUserDisplay>> GetBySearchAsync(string semantic, string address);
        Task<IEnumerable<ConfigUserDisplay>> GetSpecificAsync(string specific);
        Task<IEnumerable<string>> SearchBySemanticAsync(string term);
        Task<IEnumerable<string>> SearchByAddressAsync(string term);
        Task<IEnumerable<string>> SearchSpecificAsync(string term);
        Task<IEnumerable<string>> SearchSpecificAdressAsync(string term);
    }
}
