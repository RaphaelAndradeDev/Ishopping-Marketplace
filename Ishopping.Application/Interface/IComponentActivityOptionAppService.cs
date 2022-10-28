using Ishopping.Application.Common;
using Ishopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IComponentActivityOptionAppService : IAppServiceBaseT2<ComponentActivityOption>, IOptionAppServiceBaseT1<ComponentActivityOption>, IOptionAppServiceBaseT1Async<ComponentActivityOption>
    {
        Task<JsonResponse> AppUpdateAsync(string title, string description, string userId);
    }
}
