using Business.Library;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Business.Test
{
    public class LocationTest
    {
        //-----------------------------------------------------------------------------------------------\
        //-----------------------------------------------------------------------------------------------\
        /// <summary>
        /// Testing Location constructor and methods
        /// </summary>
        [Fact]
        public void Location_Empty_Name_Check()
        {
            Assert.ThrowsAny<ArgumentException>(() => new Location(string.Empty));
        }
        [Fact]
        public void Location_Empty_Address_Check()
        {
            Assert.ThrowsAny<ArgumentException>(() => new Location("Starbucks"));
        }
        [Fact]
        public void Location_Get_Checks()
        {
            Location l = new Location("Starbucks");

            Assert.Contains("Starbucks", l.LocationName);

        }

        Location l = new Location("Starbucks");
        Product p = new Product("Frappachino", "Caramel drizzle",2.00m);
        [Fact]
        public void Location_Add_Check()
        {
            Assert.True(l.AddItem(p, 2));
        }

        //[Fact]
        //public void Location_Remove_Check()
        //{
        //    l.AddItem(p, 2);
        //    Assert.True(l.RemoveItem(p, 1));
        //    Assert.ThrowsAny<ArgumentException>(() => l.RemoveItem(p, 3));
        //}
        //[Fact]
        //public void Location_Quantity_Check()
        //{
        //    Product p = new Product("Cookie", "Choclate",2.00m);
        //    Product p2 = new Product("Frappchino", "Mocha drizzle", 2.00m);
        //    l.AddItem(p, 5);
        //    l.AddItem(p2, 10);
        //    l.RemoveItem(p, 3);
        //    l.RemoveItem(p2, 5);
        //    Assert.Equal(2, l.Quantity(p));
        //    Assert.Equal(5, l.Quantity(p2));
        //}
    }
}
