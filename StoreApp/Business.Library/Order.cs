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
        private List<Product> _cart = null;
        private int _quantity = 0;

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
            _cart = new List<Product>();
            this._date = DateTime.Now;
        }
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
            int index = _cart.IndexOf(product);
            return _cart[index].Amount;
        }

        public void OCart()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("***************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Cart for {_customer.Customername}");
            Console.WriteLine($"Product : Quantity");

            foreach (Product item in _cart)
            {
                Console.WriteLine($"{item.Name} : {Quantity(item)}");
                Total += item.Price * Quantity(item);
            }
            Console.WriteLine("Total = $" + Total);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("***************************");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool CartisEmpty()
        {
            if (_cart.Count == 0)
            {
                return true;
            }
            else
                return false;
        }

        public void PrintOrder()
        {
            int i = 0;
            int index;
            foreach (Product p in _cart)
            {
                index = _location.Inventory.IndexOf(p);
                Console.Write($"{p.Name}, ");
                i++;
            }
        }
        public bool AddToCart(Product product, int quantity)
        {
            try 
            {
                item = new Product(product.Name, product.Description, product.Price);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Product does not exist try again.");
                return false;
            }
            int index;
            //Console.WriteLine($"Location: {_location.LocationName}");
            //Console.WriteLine($"Index => {index}");
            //Console.WriteLine($"Item {item.Name}, quantity: {_location.Inventory[index].Amount} ");
            //Console.WriteLine(_location.Quantity(product));
            //Console.WriteLine("Removing item from inventory");
            //_location.RemoveItem(product, quantity);
            //Console.WriteLine($"Quantity now {_location.Quantity(product)}");
            if (_location.Quantity(product) >= quantity)
            {
                
                _cart.Add(item);
                Console.WriteLine($"Added {product.Name} to cart.");
                index = _cart.IndexOf(item);
                _cart[index].Amount += quantity;

                _location.RemoveItem(product, quantity);
                return true;
            }
            else if (_location.Quantity(product) == 0)
            {
                Console.WriteLine($"{product} is sold out!");
                return false;
            }
            else
            {
                Console.WriteLine($"There is only {_location.Quantity(product)} left. " +
                    $"Please decrease quantity.");
                return false;

            }

        }

        public bool RemoveFromCart(Product product, int quantity)
        {
            //item = new Product(product.Name, product.Description, product.Price);
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
