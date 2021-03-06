﻿using AutoFixture.Xunit2;
using EShopOnPromotionEngineeRule.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EShopOnPromotionRuleEnginee.test
{
    public class CartTests
    {
        public CartTests()
        {

        }

        [Fact]
        public void Cart_Without_Any_CartItems_Should_Throw_Exception()
        {
            // arrange
            var lineItems = new List<CartItem>();
            var exceptionMessage = "Atleast one item needs to be added to cart.";
            var ex = new Exception("");

            // Act
            Action sut = () => Cart.CreateCart(lineItems);
            var exception = Assert.Throws<Exception>(sut);

            // Assert
            Assert.Throws<Exception>(sut);
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Theory]
        [AutoData]
        public void Cart_With_CartItems_Should_Create_Cart(List<CartItem> cartItems)
        {
            // Act
            var sut = Cart.CreateCart(cartItems);

            // Assert
            Assert.IsType<Cart>(sut);
            Assert.NotEmpty(sut.CartItems);
        }

        [Theory]
        [AutoData]
        public void Add_Item_To_Cart_Increases_Item_Count_In_CartItems(List<CartItem> cartItems)
        {
            var sut = Cart.CreateCart(cartItems);

            var newCartItem = new CartItem("A", 20M, 4);
            sut.AddItemToCart(newCartItem);

            Assert.NotEmpty(sut.CartItems);
            Assert.Equal(sut.CartItems.Count, cartItems.Count + 1);
        }

        [Theory]
        [AutoData]
        public void Add_Item_To_Cart_With_Negative_Quantity_Throws_Exception(List<CartItem> cartItems)
        {
            var sut = Cart.CreateCart(cartItems);
            var exceptionMessage = "Quantity for cart item can not be less than 1.";
            var cartItem = new CartItem("A", 20M, -1);
            // Act
            var exception = Assert.Throws<Exception>(() => sut.AddItemToCart(cartItem));

            // Assert
            Assert.Equal(exceptionMessage, exception.Message);
        }
    }
}
