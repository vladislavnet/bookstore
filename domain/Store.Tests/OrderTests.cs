﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WithNullItems_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                new Order(1, null);
            });
        }

        [Fact]
        public void TotalCount_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(1, new List<OrderItem>());
            Assert.Equal(0, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(1, new List<OrderItem>());
            Assert.Equal(0m, order.TotalPrice);
        }

        [Fact]
        public void TotalCount_WithNonEmptyItems_CalculatesTotalCount()
        {
            var order = new Order(1, new List<OrderItem>() 
            { 
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });
            Assert.Equal(3 + 5, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithNonEmptyItems_CalculatesTotalPrice()
        {
            var order = new Order(1, new List<OrderItem>()
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });
            Assert.Equal(3 * 10m + 5 * 100m, order.TotalPrice);
        }

        [Fact]
        public void Get_WithExistingItem_ReturnsItem()
        {
            var order = new Order(1, new List<OrderItem>()
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            var orderItem = order.Get(1);

            Assert.Equal(3, orderItem.Count);
        }


        [Fact]
        public void Get_WithNoneExistingItem_ThrowsInvalidOperationException()
        {
            var order = new Order(1, new List<OrderItem>()
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m),
            });

            Assert.Throws<InvalidOperationException>(() => order.Get(10));
        }
    }
}
