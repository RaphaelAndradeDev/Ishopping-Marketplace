﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ishopping.Domain.Entities;

namespace Ishopping.Application.Interface
{
    public interface IECommerceProductAppService : IAppServiceBaseT2<ECommerceProduct>
    {
        ECommerceProduct GetByImageId(string imageId);
    }
}
