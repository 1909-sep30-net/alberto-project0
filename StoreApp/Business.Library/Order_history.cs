using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Library
{
    public class Order_history
    {
        private Customer _customer = null;
        private Location _location = null;
        private Order _order = null;
        private DateTime _date = new DateTime();

        public Order_history(Customer customer, Location location, Order order)
        {
            _customer = customer;
            _location = location;
            _order = order;
            _date = DateTime.Now;
        }

        public void PrintOrderHistory(Customer customer)
        {
            Console.WriteLine("+===================+");
            Console.WriteLine($"Order history for {customer.Customername}");
            Console.WriteLine($"Date/Time || Location || Products || Total");
            Console.Write($"{_date} || {_location} || ");
            _order.PrintOrder();
            Console.Write($"|| {_order.Total}");
        }

    }
}
