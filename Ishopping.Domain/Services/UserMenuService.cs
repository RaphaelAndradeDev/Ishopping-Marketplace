using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ishopping.Domain.Entities;
using Ishopping.Domain.Interfaces.Repositories;
using Ishopping.Domain.Interfaces.Services;
using Ishopping.Domain.Interfaces.Repositories.ReadOnly;

namespace Ishopping.Domain.Services
{
    public class UserMenuService : ServiceBaseT2<UserMenu>, IUserMenuService
    {
        private readonly IUserMenuRepository _userMenuRepository;
        private readonly IUserMenuDapperRepository _userMenuDapperRepository;

        public UserMenuService(
            IUserMenuRepository userMenuRepository,
            IUserMenuDapperRepository userMenuDapperRepository)
            :base(userMenuRepository)
        {
            _userMenuRepository = userMenuRepository;
            _userMenuDapperRepository = userMenuDapperRepository;
        }

        public UserMenu GetBySiteNumber(int siteNumber)
        {
            return _userMenuRepository.GetBySiteNumber(siteNumber);
        }

        public UserMenu GetByUserId(string userId)
        {
            return _userMenuRepository.GetByUserId(userId);
        }

        public UserMenu GetMenuBySiteNumber(int siteNumber)
        {
            return _userMenuRepository.GetMenuBySiteNumber(siteNumber);
        }
    }
}
