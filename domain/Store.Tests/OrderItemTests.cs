using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_ThrowsArgumentOutOfRangeExeption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new OrderItem(1, 0, 0m);
            });
        }

        [Fact]
        public void OrderItem_WithNegativeCount_ThrowsArgumentOutOfRangeExeption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new OrderItem(1, -2, 0m);
            });
        }

        [Fact]
        public void OrderItem_WithPositiveCount_ThrowsArgumentOutOfRangeExeption()
        {
            OrderItem order = new OrderItem(1, 2, 10m);
            Assert.Equal(1, order.BookId);
            Assert.Equal(2, order.Count);
            Assert.Equal(10m, order.Price);
        }

        [Fact]
        public void Count_WithNegativeValue_ThrowsArgumentOutOfRangeExeption()
        {
            var orderItem = new OrderItem(2, 10, 10m);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderItem.Count = -10;
            });
        }

        [Fact]
        public void Count_WithZeroValue_ThrowsArgumentOutOfRangeExeption()
        {
            var orderItem = new OrderItem(2, 10, 10m);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderItem.Count = 0;
            });
        }

        [Fact]
        public void Count_WithPositiveValue_ThrowsArgumentOutOfRangeExeption()
        {
            var orderItem = new OrderItem(2, 10, 10m);
            var positiveCount = 10;

            orderItem.Count = positiveCount;

            Assert.Equal(positiveCount, orderItem.Count);    
        }
    }
}
