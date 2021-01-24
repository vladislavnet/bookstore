using System;
using Xunit;

namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            Assert.False(Book.IsIsbn(null));
        }

        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            Assert.False(Book.IsIsbn("    "));
        }

        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            Assert.False(Book.IsIsbn("ISBN 123"));
        }

        [Fact]
        public void IsIsbn_WithIsbn10_ReturnTrue()
        {
            Assert.True(Book.IsIsbn("IsBN 123-123-123 0"));
        }
    }
}
