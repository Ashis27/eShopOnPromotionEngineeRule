﻿using EShopOnPromotionEngineeRule.API.Dtos;
using EShopOnPromotionEngineeRule.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopOnPromotionEngineeRule.API.Interfaces
{
    public interface ICheckoutService
    {
        CartDto Checkout(CartDto cart);
    }
}
