﻿using EShopOnPromotionEngineeRule.API.Dtos;
using EShopOnPromotionEngineeRule.API.DTOs;
using EShopOnPromotionEngineeRule.API.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EShopOnPromotionEngineeRule.API.Infrastructure.Services
{
    public class CartService : ICartService
    {
        public CartDto AddItemToCart(Guid cartId, CartItemDto cartItem)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get basket items from static json file
        /// </summary>
        /// <returns></returns>
        public List<CartItemDto> GetCartItems()
        {
            var cartDir = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"SeedData\\basket.json"}");
            var cartJson = System.IO.File.ReadAllText(cartDir);
            var cartDto = Newtonsoft.Json.JsonConvert.DeserializeObject<CartDto>(cartJson);
            return cartDto.CartItems;
        }
    }
}
