using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Services
{
    public interface IAdminViewItemService : IServiceBase<AdminViewItem>
    {
        IEnumerable<AdminViewItem> GetAllByViewDataId(int viewDataId);
        IEnumerable<int> GetAllViewItemCod(int templateCod);
    }
}
