﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Domain.CategoryAgg.Services
{
    public interface ICategoryDomainService
    {
        public bool IsSlugExist(string slug);
    }
}
