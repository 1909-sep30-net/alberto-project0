using System;
using System.Collections.Generic;
using System.Text;
using Business.Library;
using Xunit;

namespace Business.Test
{
    public class CustomerTest
    {
        /// <summary>
        /// Testing Customer class constructor and methods.
        /// </summary>
        [Fact]
        public void Customer_Empty_Name_Check()
        {
            Assert.ThrowsAny<ArgumentException>(() => new Customer(string.Empty, "Miller"));
        }

        [Fact]
        public void Customername_Should_Return_True()
        {
            Customer c = new Customer("Bob", "Miller");
            Assert.Contains("Bob Miller", c.Customername);
        }

    }
}
