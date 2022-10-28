
using System;
using System.Collections.Generic;
namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IEntityOptionRepository 
    {
        void AddEntityOption(int entityOption, string userId);
        void AddEntityOption(IEnumerable<int> listEntityOption, string userId);       
    }
}
