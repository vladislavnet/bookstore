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
    }
}
