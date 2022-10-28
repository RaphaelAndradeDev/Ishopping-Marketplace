using Ishopping.Domain.Entities;
using System.Collections.Generic;

namespace Ishopping.Domain.Interfaces.Repositories
{
    public interface IAdminSocialNetWorkRepository : IRepositoryBase<AdminSocialNetWork>
    {
        AdminSocialNetWork GetBy(string rede, int templateCod);
        IEnumerable<AdminSocialNetWork> GetAllByTemplateId(int templateId);
        IEnumerable<string> GetAllRedeByTemplateCod(int templateCod);
    }
}
