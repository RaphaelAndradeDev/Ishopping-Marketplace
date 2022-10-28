using Ishopping.Common.Resources;
using Ishopping.Common.Validation;
using System;
using System.Collections.Generic;

/* 
 * Essa classe contem os dados do usuário que serão enviados a operadora financeira
 * Esses são os dados do usuário que efetuara o pagamento e pode ser diferente do usuário do profile
 * Essa classe não possuí qualquer dado referente a pagamento 
 * Qualquer transação devera ser arquivada na classe UserFinancialHistory
 */

namespace Ishopping.Domain.Entities
{
    public class UserFinancial
    {
        public Guid Id { get; private set; }
        public string IdUser { get; private set; }
        public int SiteNumber { get; private set; }      
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string AreaCod { get; private set; }
        public string Phone { get; private set; }
        public string Cpf { get; private set; }       
      
   
        // Relacionamento
        public virtual ICollection<UserFinancialHistory> UserFinancialHistory { get; private set; }

        // Ctor
        protected UserFinancial() { }
    
        public UserFinancial(string userId, int siteNumber)
        {
            CommonValidate.Validate(userId, siteNumber);
     
            this.IdUser = userId;
            this.SiteNumber = siteNumber;                  
        }


        // Methods
        public void Change(int company, string name, string email, string areaCod, string phone, string cpf)
        {
            Validate(company, name, email, areaCod, phone, cpf);
                       
            this.Name = name;
            this.Email = email;
            this.AreaCod = areaCod;
            this.Phone = phone;
            this.Cpf = cpf; 
        }

        public void AddHistory(UserFinancialHistory userFinancialHistory)
        {
            this.UserFinancialHistory.Add(userFinancialHistory);
        }
           
        private void Validate(int company, string name, string email, string areaCod, string phone, string cpf)
        {      
            AssertionConcern.AssertArgumentNotNull(name, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(name, 32, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(email, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(email, 128, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(areaCod, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(areaCod, 3, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(phone, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(phone, 16, Errors.MaxLength);

            AssertionConcern.AssertArgumentNotNull(cpf, Errors.IsNull);
            AssertionConcern.AssertArgumentLength(cpf, 12, Errors.MaxLength);
        }
    }
}
