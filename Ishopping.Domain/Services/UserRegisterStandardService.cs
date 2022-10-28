using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;

namespace Ishopping.Domain.Services
{
    public class UserRegisterStandardService : ServiceBaseT2<UserRegisterStandard>, IUserRegisterStandardService
    {
        private readonly IUserRegisterStandardRepository _userRegisterStandardRepository;

        public UserRegisterStandardService(IUserRegisterStandardRepository userRegisterStandardRepository)
            :base(userRegisterStandardRepository)
        {
            _userRegisterStandardRepository = userRegisterStandardRepository;
        }
    }
}
