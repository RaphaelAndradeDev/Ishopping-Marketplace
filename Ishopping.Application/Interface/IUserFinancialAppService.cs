using Ishopping.Application.Common;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ishopping.Application.Interface
{
    public interface IUserFinancialAppService : IAppServiceBaseT2<UserFinancial>
    {
        UserFinancial GetByUserId(string userId);
        void AddFinancialToDefaultPlan(UserRegisterProfile userRegisterProfile, int group);
        BasicFinancialHistory Simulator(string userId, int group, int plan);
        void PlanUpdate(UserRegisterProfile userRegisterProfile, int group, int plan);
        bool PlanUpdateValidate(string userId, int group, int plan, out string messege);
        JsonResponse NewPayment(string userId, int company, string name, string email, string areaCod, string phone, string cpf);

        // Async Methods
        Task<string> SetStatusFromNotification(string financialHistoryId, int status);
        Task<IEnumerable<string>> BlockProfile();
    }
}
