using System;
using Xunit;
using Business.Library;

namespace Business.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Empty_location()
        {
            Assert.ThrowsAny<ArgumentException>(() => new Location(string.Empty));

        }
    }
}
