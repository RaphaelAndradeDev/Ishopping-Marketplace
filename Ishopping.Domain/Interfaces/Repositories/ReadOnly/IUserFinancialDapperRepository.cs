using Ishopping.Domain.Entities;

namespace Ishopping.Domain.Interfaces.Repositories.ReadOnly
{
    public interface IUserFinancialDapperRepository
    {
        void Persist(UserFinancial userFinancial);
    }
}
