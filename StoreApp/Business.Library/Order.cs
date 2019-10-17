using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Library
{
    /// <summary>
    /// Order class:
    /// Makes an order for the customer that holds information for
    /// the customer's cart (product information and quantity)
    /// the current location being shopped at, date of the order.
    /// </summary>
    public class Order
    {
        private Location _location;
        private Customer _customer;
        private Product item = null;
        private DateTime _date = new DateTime();
        private int _quantity = 0;

        public Order(Location location, Customer customer)
        {
            if (location == null)
            {
                throw new ArgumentException("Location is invalid.");
            }
            else
                this._location = location;

            if (customer == null)
            {
                throw new ArgumentException("Customer is invalid.");
            }
            else
                this._customer = customer;
            Cart = new List<Product>();
            this._date = DateTime.Now;
        }

        public DateTime Date { get; }
        public int ID { get; set; }
        public decimal Total { get; set; } = 0.00m;
        public Customer OCustomer
        {
            get => _customer;
        }

        public Location OLocation
        {
            get => _location;
        }

        public int Quantity(Product product)
        {
            //item = new Product(product.Name, product.Description, product.Price);
            int index = Cart.IndexOf(product);
            return Cart[index].Amount;
        }

        public List<Product> Cart { get; set; } = null;
        

        public bool CartisEmpty()
        {
            if (Cart.Count == 0)
            {
                return true;
            }
            else
                return false;
        }
       

        public bool RemoveFromCart(Product product, int quantity)
        {
            //item = new Product(product.Name, product.Description, product.Price);
            int index = Cart.IndexOf(product);

            if (index != -1)
            {
                if (quantity >= Cart[index].Amount)
                {
                    throw new ArgumentException("The quantity you want to remove is more than your cart's.");
                }
                else if (Cart[index].Amount == 1)
                {
                    Cart.Remove(product);
                    return true;
                }
                else
                    Cart[index].Amount -= quantity;
            }
            else
                throw new ArgumentException($"The product {product.Name} you want to remove is not in your cart.");
            return false;
        }




    }
}
