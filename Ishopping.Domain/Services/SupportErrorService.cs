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
    public class SupportErrorService : ServiceBase<SupportError>, ISupportErrorService
    {
        private readonly ISupportErrorRepository _supportErrorRepository;

        public SupportErrorService(ISupportErrorRepository supportErrorRepository)
            :base(supportErrorRepository)
        {
            _supportErrorRepository = supportErrorRepository;
        }
    }
}
