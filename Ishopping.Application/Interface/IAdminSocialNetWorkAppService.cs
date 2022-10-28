using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Application.Interface
{
    public interface IAdminSocialNetWorkAppService : IAppServiceBase<AdminSocialNetWork>
    {
        AdminSocialNetWork GetBy(string rede, int templateCod);
        IEnumerable<AdminSocialNetWork> GetAllByTemplateId(int templateId);
    }
}
