using Ishopping.Domain.Communs;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Domain.Services
{
    public class ComponentSimpleProductOptionService : ServiceBaseT2<ComponentSimpleProductOption>, IComponentSimpleProductOptionService
    {
        private readonly IComponentSimpleProductOptionRepository _componentSimpleProductOptionRepository;

        public ComponentSimpleProductOptionService(IComponentSimpleProductOptionRepository componentSimpleProductOptionRepository)
            : base(componentSimpleProductOptionRepository)
        {
            _componentSimpleProductOptionRepository = componentSimpleProductOptionRepository;
        }

        public IEnumerable<ComponentSimpleProductOption> GetAllByUserId(string userId)
        {
            return _componentSimpleProductOptionRepository.GetAllByUserId(userId);
        }

        public ComponentSimpleProductOption GetById(Guid id, string userId)
        {
            return _componentSimpleProductOptionRepository.GetById(id, userId);
        }

        public ComponentSimpleProductOption GetDefault(string userId)
        {
            return _componentSimpleProductOptionRepository.GetDefault(userId);
        }

        public ComponentSimpleProductOption Put(string name, string category, string brand, string model, string description, string price, string userId)
        {
            var simpleProductOption = _componentSimpleProductOptionRepository.GetDefault(userId);

            bool alterStyle = name != simpleProductOption.Name || category != simpleProductOption.Category || brand != simpleProductOption.Brand || model != simpleProductOption.Model || description != simpleProductOption.Description || price != simpleProductOption.Price;
            if (alterStyle)
            {
                return new ComponentSimpleProductOption(userId, false, name, category, brand, model, description, price);                
            }
            else
            {
                return simpleProductOption;
            }
        }

        public void StyleReplace(string userId, string name, string replace)
        {
            var simpleProduct = GetAllByUserId(userId);

            foreach (var item in simpleProduct)
            {
                item.Change(
                    item.Default,
                    IsStyle.Rename(item.Name, name, replace),
                    IsStyle.Rename(item.Category, name, replace),
                    IsStyle.Rename(item.Brand, name, replace),
                    IsStyle.Rename(item.Model, name, replace),
                    IsStyle.Rename(item.Price, name, replace),
                    IsStyle.Rename(item.Description, name, replace)
                    );
            }
            _componentSimpleProductOptionRepository.Update(simpleProduct);
        }

        public void StyleRemove(string userId, string name)
        {
            var simpleProduct = GetAllByUserId(userId);

            foreach (var item in simpleProduct)
            {
                item.Change(
                    item.Default,
                    IsStyle.Remove(item.Name, name),
                    IsStyle.Remove(item.Category, name),
                    IsStyle.Remove(item.Brand, name),
                    IsStyle.Remove(item.Model, name),
                    IsStyle.Remove(item.Price, name),
                    IsStyle.Remove(item.Description, name)
                    );
            }
            _componentSimpleProductOptionRepository.Update(simpleProduct);
        }


        // Async Methods
        public async Task<IEnumerable<ComponentSimpleProductOption>> GetAllByUserIdAsync(string userId)
        {
            return await _componentSimpleProductOptionRepository.GetAllByUserIdAsync(userId);
        }

        public async Task<ComponentSimpleProductOption> GetByIdAsync(Guid id)
        {
            return await _componentSimpleProductOptionRepository.GetByIdAsync(id);
        }

        public async Task<ComponentSimpleProductOption> GetByIdAsync(Guid id, string userId)
        {
            return await _componentSimpleProductOptionRepository.GetByIdAsync(id, userId);
        }

        public async Task<ComponentSimpleProductOption> GetDefaultAsync(string userId)
        {
            return await _componentSimpleProductOptionRepository.GetDefaultAsync(userId);
        }
        
        public async Task<ComponentSimpleProductOption> PutAsync(string name, string category, string brand, string model, string description, string price, string userId)
        {
            var simpleProductOption = await _componentSimpleProductOptionRepository.GetDefaultAsync(userId);

            bool alterStyle = name != simpleProductOption.Name || category != simpleProductOption.Category || brand != simpleProductOption.Brand || model != simpleProductOption.Model || description != simpleProductOption.Description || price != simpleProductOption.Price;
            if (alterStyle)
            {
                return new ComponentSimpleProductOption(userId, false, name, category, brand, model, description, price);
            }
            else
            {
                return simpleProductOption;
            }
        }
    }
}
