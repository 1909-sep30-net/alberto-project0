using System;
using System.Collections.Generic;
using System.Text;
using Business.Library;
using Xunit;

namespace Business.Test
{
    public class ProductTest
    {
        //-----------------------------------------------------------------------------------------------\
        //-----------------------------------------------------------------------------------------------\
        /// <summary>
        /// Testing Product constructor and methods
        /// </summary>
        [Fact]

        public void Product_Constructor_Name_Check()
        {
            Assert.ThrowsAny<ArgumentException>(() => new Product(string.Empty, "Mocha flavored"));
        }
        [Fact]

        public void Product_Constructor_Description_Check()
        {
            Assert.ThrowsAny<ArgumentException>(() => new Product("Frappachino", string.Empty));
        }

        Product drink = new Product("Machiato", "Mocha Vanilla");
        [Fact]
        public void Product_Name_Check()
        {
            Assert.Contains("Machiato", drink.Name);
        }
        [Fact]
        public void Product_Description_Check()
        {
            Assert.Contains("Mocha Vanilla", drink.Description);
        }
        [Fact]
        public void Product_Amount_Check()
        {

            Product p = new Product("Steak", "Medium rare");
            Product p2 = new Product("Milk Shake", "Oreo");

            p.Amount += 56;
            p2.Amount += 99;
            p.Amount -= 30;
            p2.Amount -= 60;


            Assert.Equal<int>(26, p.Amount);
            Assert.Equal<int>(39, p2.Amount);

        }
    }
}
