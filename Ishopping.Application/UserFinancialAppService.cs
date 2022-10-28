using Ishopping.Application.AppService;
using Ishopping.Application.Common;
using Ishopping.Application.Interface;
using Ishopping.Common.Constants;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ishopping.Application
{
    public class UserFinancialAppService : AppServiceBaseT2<UserFinancial>, IUserFinancialAppService
    {
        private readonly IAdminFinancialPlanService _adminFinancialPlanService;
        private readonly IConfigUserDisplayService _configUserDisplayService;    
        private readonly IUserFinancialService _userFinancialService;
        private readonly IUserFinancialHistoryService _userFinancialHistoryService;        
        private readonly IUserRegisterProfileService _userRegisterProfile;
        private readonly IUserSerializeViewDataService _userSerializeViewDataService;

        public UserFinancialAppService(
            IAdminFinancialPlanService adminFinancialPlanService,
            IConfigUserDisplayService configUserDisplayService,     
            IUserFinancialService userFinancialService,
            IUserFinancialHistoryService userFinancialHistoryService,            
            IUserRegisterProfileService userRegisterProfile,
            IUserSerializeViewDataService userSerializeViewDataService)
            :base(userFinancialService)
        {
            _adminFinancialPlanService = adminFinancialPlanService;
            _configUserDisplayService = configUserDisplayService;       
            _userFinancialService = userFinancialService;
            _userFinancialHistoryService = userFinancialHistoryService;            
            _userRegisterProfile = userRegisterProfile;
            _userSerializeViewDataService = userSerializeViewDataService;
        }

        public UserFinancial GetByUserId(string userId)
        {
            return _userFinancialService.GetByUserId(userId);
        }               

        public void AddFinancialToDefaultPlan(UserRegisterProfile userRegisterProfile, int group)
        {
            // Usado somente ao se criar um novo profile  
            int plan = GetPlan(group);              
            AddUserFinancial(userRegisterProfile, plan);                     
        }

        public BasicFinancialHistory Simulator(string userId, int group, int plan)
        {
            plan = plan == 0 ? group : plan;            
            var userFinancial = _userFinancialService.GetByUserId(userId);
            return GetBasicFinancialHistorySimulator(userFinancial, 0, GetPlan(plan));         
        }

        public void PlanUpdate(UserRegisterProfile userRegisterProfile, int group, int plan)
        {
            plan = plan == 0 ? group : plan;
            plan = GetPlan(plan);

            if (userRegisterProfile.Plan == plan) return;

            userRegisterProfile.ChangePlan(plan);

            var userFinancial = _userFinancialService.GetByUserId(userRegisterProfile.IdUser);
            var financialHistory = GetFinancialHistoryForPlanUpdate(userFinancial, 0, userRegisterProfile.Plan);

            if (financialHistory != null)
            {
                if (financialHistory.Id == Guid.Empty)
                {                  
                    _userFinancialHistoryService.Persist(financialHistory, true);
                }
                else
                {
                    _userFinancialHistoryService.Persist(financialHistory, false);
                }

                if (TransactionIsAproved(financialHistory.Status))
                {                   
                    userRegisterProfile.SetBlockForInsufficientValue(false);
                }
                else
                {
                    userRegisterProfile.SetBlockForInsufficientValue(true);
                }
            }
        }

        public JsonResponse NewPayment(string userId, int company, string name, string email, string areaCod, string phone, string cpf)
        {
            var profile = _userRegisterProfile.GetByUserId(userId);
            var userFinancial = _userFinancialService.GetByUserId(userId);            
         
            userFinancial.Change(company, name, email, areaCod, phone, cpf);

            bool pay = false;
            string transactionId = string.Empty;
            string message = "Existe uma transação pendente de aprovação";

            var financialHistory = GetFinancialHistoryForPayment(userFinancial, company, profile.Plan);

            if(financialHistory != null)
            {
                if (financialHistory.Status == (int)ConstantFinancial.Transaction.Approved)
                {                   
                    pay = false;
                    message = "Transação aprovada automaticamente";   
                }
                else
                {
                    pay = true;            
                }

                if(financialHistory.Id == Guid.Empty)
                {                    
                    _userFinancialHistoryService.Persist(financialHistory, true);
                }
                else
                {
                    _userFinancialHistoryService.Persist(financialHistory, false);
                }

                transactionId = financialHistory.Id.ToString();
                userFinancial.UserFinancialHistory.Add(financialHistory);                
            }

            _userFinancialService.Persist(userFinancial);
            
            return Payment(profile, userFinancial, company, transactionId, pay, message);                          
        }

        public async Task<string> SetStatusFromNotification(string financialHistoryId, int status)
        {
            var financialHistory = await _userFinancialHistoryService.GetByAsync(Guid.Parse(financialHistoryId));
            var profile = await _userRegisterProfile.GetByUserIdAsync(financialHistory.UserFinancial.IdUser);

            FinancialHistoryUpdate(financialHistory, profile.HasInsufficientValue, status);
            return ProfileStatusUpdate(profile, status); 
        }

        public bool PlanUpdateValidate(string userId, int group, int plan, out string messege)
        {
            plan = plan == 0 ? group : plan;
            plan = GetPlan(plan);

            messege = string.Empty;
            var userFinancial = _userFinancialService.GetByUserId(userId);              
            if(HasChangePlan(userFinancial, plan))
            {
                if(!PlanUpdateIsValidateByStatus(userFinancial, plan, out messege))
                {
                    return false;
                }

                if (!PlanUpdateIsValidateByMinValue(userFinancial, plan, out messege))
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<IEnumerable<string>> BlockProfile()
        {
            var listFinancialHistory = _userFinancialHistoryService.GetAllDueDate();

            List<string> listUserId = new List<string>();
            var listFinancialId = listFinancialHistory.Select(x => x.UserFinancialId).Distinct().ToArray();

            foreach (var financialId in listFinancialId)
            {
                var financialHistory = listFinancialHistory.Where(x => x.UserFinancialId == financialId).OrderBy(x => x.DueDate).Last();
                               
                if (DateTime.Now > financialHistory.DueDate)
                {                    
                    listUserId.Add(financialHistory.UserFinancial.IdUser);
                }
            }                                    
            _userRegisterProfile.BlockProfiles(listUserId);
            _userFinancialHistoryService.SetHistoryBlock(listFinancialHistory.Select(x => x.Id));
            return await _userRegisterProfile.GetEmailAsync(listUserId);
        }


        // private methods
        private bool HasChangePlan(UserFinancial userFinancial, int plan)
        {
            // Retorna verdadeiro se houve alteração de plano
            // Retorna falso se não existe algum registro para UserFinancialHistory
            var lastFinancialHistory = userFinancial.UserFinancialHistory.OrderBy(x => x.Date).LastOrDefault();
            if (lastFinancialHistory != null)   
                return lastFinancialHistory.AdminFinancialPlan.Cod != plan;            
            return false;
        }

        private bool PlanUpdateIsValidateByStatus(UserFinancial userFinancial, int plan, out string messege)
        {
            messege = "Não foi possível alterar o plano porque existe um pagamento pendente de aprovação";

            // Retorna falso se houver alguma restrição para alteração do plano baseado no último status.
            var lastFinancialHistory = userFinancial.UserFinancialHistory.OrderBy(x => x.Date).LastOrDefault();
            if (IsWaitingReturn(lastFinancialHistory.Status))
                return false;
            else
                return true;                          
        }

        private bool IsWaitingReturn(int status)
        {
            switch (status)
            {
                case (int)ConstantFinancial.Transaction.PreApproved:
                    return true;
                case (int)ConstantFinancial.Transaction.Contested:
                    return true;
                case (int)ConstantFinancial.Transaction.Retained:
                    return true;
                default:
                    return false;
            }
        }

        private bool IsPaymentConfirmed(int status)
        {
            switch (status)
            {
                case (int)ConstantFinancial.Transaction.Approved:
                    return true;
                case (int)ConstantFinancial.Transaction.Deducted:
                    return true;            
                default:
                    return false;
            }
        }

        private bool PlanUpdateIsValidateByMinValue(UserFinancial userFinancial, int plan, out string messege)
        {
            const decimal minValue = 5;
            messege = "Não foi possível alterar o plano porque o pagamento mínimo deve ser igual ou superior a " + minValue.ToString("C");

            // Retorna falso se o valor de pagamento for abaixo de x;    
            var historySimulator = GetFinancialHistorySimulator(userFinancial, 0, plan);
            return historySimulator.Payment > minValue || historySimulator.Payment == 0;
        }                
        
        private void FinancialHistoryUpdate(UserFinancialHistory userFinancialHistory, bool hasInsufficientValue, int status)
        {
            if(hasInsufficientValue && status == (int)ConstantFinancial.Transaction.Approved)
            {
                int month = userFinancialHistory.AdminFinancialPlan.Month;
                userFinancialHistory.SetDueDate(DateTime.Now.AddMonths(month));
            }          
            userFinancialHistory.SetStatus(status);
            _userFinancialHistoryService.Update(userFinancialHistory);
        }

        private string ProfileStatusUpdate(UserRegisterProfile userRegisterProfile, int status)
        {           
            bool block = status == (int)ConstantFinancial.Transaction.Approved ? false : userRegisterProfile.HasInsufficientValue;
            userRegisterProfile.SetBlockForInsufficientValue(block);                                                        
            _userRegisterProfile.Update(userRegisterProfile);
            return userRegisterProfile.Email;
        }

        private void AddUserFinancial(UserRegisterProfile userRegisterProfile, int plan)
        {            
            UserFinancial userFinancial = new UserFinancial(userRegisterProfile.IdUser, userRegisterProfile.SiteNumber);
            _userFinancialService.Add(userFinancial);

            var adminFinancialPlan = _adminFinancialPlanService.GetByCod(ConstantFinancial.GetDefaultPlan(plan));
            var userFinancialHistory = new UserFinancialHistory(userFinancial.Id, adminFinancialPlan);
            _userFinancialHistoryService.Persist(userFinancialHistory, true);

            userRegisterProfile.ChangePlan(plan);
            if (TransactionIsAproved(userFinancialHistory.Status))
            {
                userRegisterProfile.SetBlockForInsufficientValue(false);
            }
            else
            {
                userRegisterProfile.SetBlockForInsufficientValue(true);
            }
        }
        
        private UserFinancialHistory GetFinancialHistorySimulator(UserFinancial userFinancial, int company, int plan)
        {
            var adminFinancialPlan = _adminFinancialPlanService.GetByCod(ConstantFinancial.GetDefaultPlan(plan));
            if (adminFinancialPlan == null)
                throw new InvalidOperationException("Alguns padrões não foram definidos");

            // Busca a última transação
            var lastFinancialHistory = userFinancial.UserFinancialHistory.Where(x => x.Group != 0).OrderBy(x => x.Date).LastOrDefault();

            if (lastFinancialHistory != null)
            {                           
                if (IsPaymentConfirmed(lastFinancialHistory.Status))
                {
                    return new UserFinancialHistory(userFinancial, adminFinancialPlan, company, 0);
                }
                else
                {
                    return GetFinancialHistoryForNotAproved(userFinancial, lastFinancialHistory.Group, adminFinancialPlan, company, 0);
                }
            }
            else
            {
                return new UserFinancialHistory(userFinancial, 1, adminFinancialPlan, company, false);
            }
        }
        
        private BasicFinancialHistory GetBasicFinancialHistorySimulator(UserFinancial userFinancial, int company, int plan)
        {
            return GetBasicFinancialHistory(GetFinancialHistorySimulator(userFinancial, company, plan));                                               
        }

        private UserFinancialHistory GetFinancialHistoryForPayment(UserFinancial userFinancial, int company, int plan)
        {
            var adminFinancialPlan = _adminFinancialPlanService.GetByCod(ConstantFinancial.GetDefaultPlan(plan));
            if (adminFinancialPlan == null)
                throw new InvalidOperationException("Alguns padrões não foram definidos");

            // Busca a última transação
            var lastFinancialHistory = userFinancial.UserFinancialHistory.Where(x => x.Group != 0).OrderBy(x => x.Date).LastOrDefault();

            if (lastFinancialHistory != null)
            {                
                if (IsWaitingReturn(lastFinancialHistory.Status))
                {
                    return null;
                }      
                else
                {
                    return new UserFinancialHistory(userFinancial, lastFinancialHistory.Group, adminFinancialPlan, company, true);
                }
            }
            else
            {                
                return new UserFinancialHistory(userFinancial, 1, adminFinancialPlan, company, false);        
            }
        }

        private UserFinancialHistory GetFinancialHistoryForPlanUpdate(UserFinancial userFinancial, int company, int plan)
        {
            var adminFinancialPlan = _adminFinancialPlanService.GetByCod(ConstantFinancial.GetDefaultPlan(plan));
            if (adminFinancialPlan == null)
                throw new InvalidOperationException("Alguns padrões não foram definidos");

            // Busca a última transação
            var lastFinancialHistory = userFinancial.UserFinancialHistory.Where(x => x.Group != 0).OrderBy(x => x.Date).LastOrDefault();
                        
            if (lastFinancialHistory != null)
            {           
                if (IsWaitingReturn(lastFinancialHistory.Status))
                {
                    return null;
                }
                else if (IsPaymentConfirmed(lastFinancialHistory.Status))
                {
                    return new UserFinancialHistory(userFinancial, adminFinancialPlan, company, 0);                                      
                }                    
                else 
                {
                    return GetFinancialHistoryForNotAproved(userFinancial, lastFinancialHistory.Group, adminFinancialPlan, company, 0);          
                }                
            }
            else
            {
                return new UserFinancialHistory(userFinancial, 1, adminFinancialPlan, company, false);
            }           
        }

        private UserFinancialHistory GetFinancialHistoryForNotAproved(UserFinancial userFinancial, int group, AdminFinancialPlan adminFinancialPlan, int company, int daysLocked)
        {
            var histrory = userFinancial.UserFinancialHistory.LastOrDefault(x => x.Status == (int)ConstantFinancial.Transaction.Approved || x.Status == (int)ConstantFinancial.Transaction.Deducted);
            if (histrory != null)
                return new UserFinancialHistory(userFinancial, adminFinancialPlan, company, daysLocked);
            return new UserFinancialHistory(userFinancial, group, adminFinancialPlan, company, false);
        }

        private JsonResponse Payment(UserRegisterProfile userRegisterProfile, UserFinancial userFinancial, int company, string transactionId, bool pay, string message)
        {
            JsonResponse json = new JsonResponse();  

            if(!pay)
            {
                json.Redirect = false;
                json.Message = message;
                return json;
            }             
                
            switch (company)
            {
                case 1:
                    var adminPagSeguro = new AdminPagSeguro(userRegisterProfile, userFinancial, transactionId);
                    json.Redirect = true;
                    json.RedirectUrl = adminPagSeguro.NewPayment();
                    break;
                default:
                    throw new InvalidOperationException("Alguns padrões não foram definidos");
            }

            return json;
        }

        private BasicFinancialHistory GetBasicFinancialHistory(UserFinancialHistory userFinancialHistory)
        {
            return new BasicFinancialHistory(userFinancialHistory.AdminFinancialPlan.Name, userFinancialHistory.AdminFinancialPlan.Month, userFinancialHistory.PlanValue, userFinancialHistory.Balance, userFinancialHistory.AddDayToPlan, userFinancialHistory.DueDate, userFinancialHistory.Payment);
        }   
        
        private bool TransactionIsAproved(int status)
        {
            return status == (int)ConstantFinancial.Transaction.Approved || status == (int)ConstantFinancial.Transaction.Deducted || status == (int)ConstantFinancial.Transaction.Warranted;
        }

        private int GetPlan(int plan)
        {
            var adminPlan = _adminFinancialPlanService.GetByCod(ConstantFinancial.GetDefaultPlan(plan));
            if (adminPlan == null)
                throw new InvalidOperationException("Alguns padrões não foram definidos");
            return adminPlan.Cod;
        }

    }
}
