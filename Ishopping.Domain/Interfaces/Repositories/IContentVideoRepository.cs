using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IContentVideoRepository : IRepositoryBaseT2<ContentVideo>, IContentRepositoryBaseT1<ContentVideo>, IContentRepositoryBaseT1Async<ContentVideo>
    {
    }
}
