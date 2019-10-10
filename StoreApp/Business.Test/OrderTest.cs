using System;
using System.Collections.Generic;
using System.Text;
using Business.Library;
using Xunit;

namespace Business.Test
{
    public class OrderTest
    {
        /// <summary>
        /// Testing Order class constructor and methods.
        /// </summary>
        Location l = new Location("Starbucks", "101 S Center Street");
        Customer c = new Customer("Alberto", "Acevedo");
        Product p = new Product("Frappachino", "Mocha drizzle");
        Product p2 = new Product("Machiatto", "Caramel drizzle");
        List<Product> list = new List<Product>();

        


        Location l_null;
        Customer c_null;
        List<Product> empty_list;


        [Fact]

        public void Order_Constructor_Empty_Location_Check()
        {
            list.Add(p);
            list.Add(p2);
            Assert.ThrowsAny<ArgumentException>(() => new Order(l_null, c, list));
        }
        [Fact]

        public void Order_Constructor_Empty_Customer_Check()
        {
            list.Add(p);
            list.Add(p2);

            Assert.ThrowsAny<ArgumentException>(() => new Order(l_null, c, list));
            Assert.ThrowsAny<ArgumentException>(() => new Order(l, c_null, list));
            Assert.ThrowsAny<ArgumentException>(() => new Order(l, c, empty_list));
        }
        [Fact]

        public void Order_Constructor_Empty_List_Check()
        {
            //list.Add(p);
            //list.Add(p2);
            Assert.ThrowsAny<ArgumentException>(() => new Order(l, c, empty_list));
        }
        [Fact]

        public void Order_Get_Customer_Check()
        {
            list.Add(p);
            list.Add(p2);
            Order o = new Order(l,c,list);

            Assert.Equal(c, o.OCustomer);
        }
        [Fact]

        public void Order_Get_Location_Check()
        {
            list.Add(p);
            list.Add(p2);
            Order o = new Order(l, c, list);

            Assert.Equal(l, o.OLocation);

        }
        [Fact]

        public void Order_Cart_Check()
        {
            list.Add(p);
            list.Add(p2);
            Order o = new Order(l, c, list);

            string test = "------------------\n" +
                "Product : Quantity\n" +
                "Frappachino : Mocha drizzle\n" +
                "Machiatto : Caramel drizzle\n" +
                "------------------\n";

            Assert.Contains(test, o.OCart());

        }

        /// <summary>
        /// Add to cart checks:
        /// 1. Test when requested amount of item is higher than available in location's inventory.
        /// 2. Test when location's inventory is already sold out of requested item.
        /// 3. Test adding into cart when successful.
        /// </summary>
        [Fact]

        public void Order_AddtoCart_Check1()
        {
            list.Add(p);
            list.Add(p2);
            Order o = new Order(l, c, list);

            Assert.ThrowsAny<ArgumentException>(() => o.AddToCart(p, 2));

        }
        [Fact]

        public void Order_AddtoCart_Check2()
        {
            
            list.Add(p2);
            Order o = new Order(l, c, list);

            Assert.ThrowsAny<ArgumentException>(() => o.AddToCart(p, 1));

        }
        [Fact]

        public void Order_AddtoCart_Check3()
        {
           
            list.Add(p2);
            Order o = new Order(l, c, list);

            Assert.True(o.AddToCart(p2, 1));

        }









    }
}
