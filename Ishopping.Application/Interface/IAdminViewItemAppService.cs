using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ishopping.Domain.Entities;

namespace Ishopping.Application.Interface
{
    public interface IAdminViewItemAppService : IAppServiceBase<AdminViewItem>
    {
        IEnumerable<AdminViewItem> GetAllByViewDataId(int viewDataId);
    }
}
