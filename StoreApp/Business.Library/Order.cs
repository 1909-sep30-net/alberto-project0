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
        private DateTime _date = new DateTime();
        private List<Product> _cart;
        private int _quantity;

        public Order(Location location, Customer customer, List<Product> products)
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
            if (products == null)
            {
                throw new ArgumentException("products is invalid.");
            }
            else
                this._cart = products;
            this._date = DateTime.Now;
        }

        public Customer OCustomer
        {
            get => _customer;
        }

        public Location OLocation
        {
            get => _location;
        }


        public string OCart()
        {
            string cart = null;

            cart += "------------------\n";
            cart += "Product : Quantity\n";

            foreach (Product item in _cart)
            {
                cart = item.Name + " : " + item.Amount + "\n";
            }

            cart += "------------------\n";
            return cart;
        }

        public bool AddToCart(Product product, int quantity)
        {
            int index;

            if (_location.Quantity(product) >= quantity)
            {
                _cart.Add(product);
                index = _cart.IndexOf(product);
                _cart[index].Amount += quantity;

                _location.RemoveItem(product, quantity);
                return true;
            }
            else if (_location.Quantity(product) == 0)
            {
                throw new ArgumentException("Item is sold out.");
            }
            else
            {
                throw new ArgumentException($"There is only {_location.Quantity(product)} left. " +
                    $"Please decrease quantity.");
            }

        }

        public bool RemoveFromCart(Product product, int quantity)
        {
            int index = _cart.IndexOf(product);

            if (index != -1)
            {
                if (quantity >= _cart[index].Amount)
                {
                    throw new ArgumentException("The quantity you want to remove is more than your cart's.");
                }
                else if (_cart[index].Amount == 1)
                {
                    _cart.Remove(product);
                    return true;
                }
                else
                    _cart[index].Amount -= quantity;
            }
            else
                throw new ArgumentException($"The product {product.Name} you want to remove is not in your cart.");
            return false;
        }




    }
}
