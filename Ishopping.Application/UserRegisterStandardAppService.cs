using System;
using System.Collections.Generic;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Entities;
using Ishopping.Application.Interface;

namespace Ishopping.Application
{
    public class UserRegisterStandardAppService : AppServiceBaseT2<UserRegisterStandard>, IUserRegisterStandardAppService
    {
        private readonly IUserRegisterStandardService _userRegisterStandardService;

        public UserRegisterStandardAppService(IUserRegisterStandardService userRegisterStandardService)
            :base(userRegisterStandardService)
        {
            _userRegisterStandardService = userRegisterStandardService;
        }
    }
}
