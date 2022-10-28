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
    public class SupportInfoService : ServiceBase<SupportInfo>, ISupportInfoService
    {
        private readonly ISupportInfoRepository _supportInfoRepository;

        public SupportInfoService(ISupportInfoRepository supportInfoRepository)
            :base(supportInfoRepository)
        {
            _supportInfoRepository = supportInfoRepository;
        }
    }
}
