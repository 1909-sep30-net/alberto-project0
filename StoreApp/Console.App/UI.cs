using System;
using System.Collections.Generic;
using System.Threading;
using Business.Library;
using Data.Access;
using Data.Access.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace UserInterface.App
{
    class UI
    {
        public static void ChangeColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        //public static List<Business.Library.Customer> customers = new List<Business.Library.Customer>()
        //{
        //    new Business.Library.Customer("Alberto", "Acevedo"),
        //    new Business.Library.Customer("Alex", "Rodriguez"),
        //    new Business.Library.Customer("Timmithy", "Xenomorph")
        //};



        //public static List<Business.Library.Location> locations = new List<Business.Library.Location>()
        //{
        //    new Business.Library.Location("Starbucks"),
        //    new Business.Library.Location("Chick-Fil-A"),
        //    new Business.Library.Location("BurgerIM")

        //};

        //public static List<Business.Library.Product> s_products = new List<Business.Library.Product>()
        //{
        //    new Business.Library.Product("Caramel Frappachino", "Venti", 7.50m),
        //    new Business.Library.Product("White Mocha Hot", "Grande", 5.20m),
        //    new Business.Library.Product("Pumpkin Spice Machiatto", "Venti", 7.50m)
        //};

        //public static List<Business.Library.Product> c_products = new List<Business.Library.Product>()
        //{
        //    new Business.Library.Product("Chicken Sandwich", "Meal", 8.75m),
        //    new Business.Library.Product("Grilled Nuggets", "Meal", 5.20m),
        //    new Business.Library.Product("Spicy Chicken Sandwhich", "Meal", 5.50m)
        //};

        //public static List<Business.Library.Product> b_products = new List<Business.Library.Product>()
        //{
        //    new Business.Library.Product("Mini Trio", "Meal", 8.75m),
        //    new Business.Library.Product("Angus Beef", "Single", 6.99m),
        //    new Business.Library.Product("Wings", "Wednesday Special", 0.75m)
        //};

        //public static void Initialize()
        //{
        //    foreach (Business.Library.Product p in s_products)
        //        locations[0].AddItem(p, 20);
        //    foreach (Business.Library.Product p in c_products)
        //        locations[1].AddItem(p, 20);
        //    foreach (Business.Library.Product p in b_products)
        //        locations[2].AddItem(p, 20);
        //}

        public static Customer AddNewCustomer(Repository data)
        {
            ChangeColor(ConsoleColor.Green);
            Console.WriteLine("Please enter first name:");
            ChangeColor(ConsoleColor.White);
            string fname = Console.ReadLine();

            ChangeColor(ConsoleColor.Green);
            Console.WriteLine("Please enter last name:");
            ChangeColor(ConsoleColor.White);
            string lname = Console.ReadLine();


            Customer customer = new Customer(fname, lname);
            data.AddCustomer(customer);
            data.Save();
            return customer;


        }

        public static List<Product> AddToCart(Business.Library.Inventory invItem, int quantity, Location location, Repository data, List<Product> cart)
        {
            Business.Library.OrderDetails od = new Business.Library.OrderDetails();
            try
            {

                invItem.Product = new Product(invItem.Product.Name, invItem.Product.Description, invItem.Product.Price);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Product does not exist try again.");
                return cart;
            }
            int index;
            //Console.WriteLine($"Location: {_location.LocationName}");
            //Console.WriteLine($"Index => {index}");
            //Console.WriteLine($"Item {item.Name}, quantity: {_location.Inventory[index].Amount} ");
            //Console.WriteLine(_location.Quantity(product));
            //Console.WriteLine("Removing item from inventory");
            //_location.RemoveItem(product, quantity);
            //Console.WriteLine($"Quantity now {_location.Quantity(product)}");
            if (location.Quantity(invItem) >= quantity)
            {

                cart.Add(invItem.Product);
                Console.WriteLine($"Added {invItem.Product.Name} to cart.");
                index = cart.IndexOf(invItem.Product);
                invItem.quantity -= quantity;


                data.UpdateLocationInventory(invItem);
                data.Save();
                cart[index].Amount += quantity;
                return cart;
            }
            else if (location.Quantity(invItem) == 0)
            {
                Console.WriteLine($"{invItem.Product.Name} is sold out!");
                return cart;
            }
            else
            {
                Console.WriteLine($"There is only {location.Quantity(invItem)} left. " +
                    $"Please decrease quantity.");
                return cart;

            }

        }

        public static void SelectProducts(Location location, Customer customer, Repository data, List<Location> locations)
        {
            decimal total = 0;
            int quantity = 0;
            List<Product> cart = new List<Product>();
            List<Business.Library.Inventory> inventory = null;
            Order order = new Order(location, customer);

            Business.Library.Inventory item = null;
            string option = null;
            //order_history = null;

            while (option != "c" && option != "r")
            {
                Console.Write($"Hello ");
                Console.WriteLine($"{customer.Customername}");
                Console.WriteLine($"Welcome to {location.LocationName}!  ");
                Console.WriteLine($"| Product || Description || Price || Quantity         ");
                ChangeColor(ConsoleColor.Blue);
                Console.WriteLine("====================================================");
                ChangeColor(ConsoleColor.White);

                inventory = PrintLocationInventory(data, location);
                ChangeColor(ConsoleColor.Blue);
                Console.WriteLine("====================================================");
                ChangeColor(ConsoleColor.White);
                Console.WriteLine($"| [R] Return to previous menu    ");
                Console.WriteLine($"| [M] Return to main menu    ");
                ChangeColor(ConsoleColor.Blue);
                Console.WriteLine($"+-----------------------------------------------+  \n");
                ChangeColor(ConsoleColor.White);
                Console.Write("Select product names or R/M: ");
                option = Console.ReadLine();

                if (option.ToLower() == "r")
                {
                    Console.WriteLine("Returning to previous menu...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    SelectStore(option, customer, locations, data);
                    //return null;
                }
                else if (option.ToLower() == "m")
                {
                    Console.WriteLine("Returning to main menu...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    //submitted_order = order_history;
                    return;
                }

                else
                {
                    item = inventory.Find(x => x.Product.Name.Contains(option));
                    Console.Write("How many: ");
                    option = Console.ReadLine();
                    int.TryParse(option, out quantity);
                    cart = AddToCart(item, quantity, location, data, cart);
                    if (cart.Count != 0)
                    {
                        Console.WriteLine("\n");
                        //List<Business.Library.OrderDetails> orderCart = data.GetCurrentCart(order);
                        order.Total = PrintCart(customer, cart);
                        Console.WriteLine("Press C to checkout or any other key to add more. ");
                        option = Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        SelectProducts(location, customer, data, locations);
                    }
                }
            }
            //data.AddNewOrder(order);
            //data.Save();
            //UpdateOrder(data, order, item);

            return;



        }

        public static void UpdateOrder(Repository data, Order order, Business.Library.Inventory inv)
        {
            //List<Business.Library.Order> entityOrder = data.GetOrders(order.OCustomer, order.OLocation);


            Business.Library.OrderDetails od = new Business.Library.OrderDetails();
            //od.order_id = entityOrder[0].ID;
            //od.Order = entityOrder[0];
            od.product_id = inv.Product.ID;
            od.Quantity = inv.quantity;
            od.Product = inv.Product;
            Console.WriteLine($"Updating od: order_id = {od.order_id}, product_id = {od.product_id}, quantity = {od.Quantity}");
            data.AddNewOrderDetail(od);
            data.Save();

        }
        public static decimal PrintCart(Customer customer, List<Product> cart)
        {
            decimal total = 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("***************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Cart for {customer.Customername}");
            Console.WriteLine($"Product : Quantity");

            foreach (Product item in cart)
            {
                Console.WriteLine($"{item.Name} : {item.Amount}");
                total += item.Price * item.Amount;
            }
            Console.WriteLine("Total = $" + total);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("***************************");
            Console.ForegroundColor = ConsoleColor.White;
            return total;
        }

        //public void PrintOrder()
        //{
        //    int i = 0;
        //    int index;
        //    foreach (Product p in Cart)
        //    {
        //        index = _location.Inventory.IndexOf(p);
        //        Console.Write($"{p.Name}, ");
        //        i++;
        //    }
        //}

        public static void GetOrderHistory(Customer customer, Repository data)
        {

            List<Order> orders = data.GetOrders(customer);

            Console.WriteLine($"Orders for Customer {customer.Customername}");
            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.OLocation} --");
                List<Business.Library.OrderDetails> od = data.GetOrderDetais(order);
                foreach(Business.Library.OrderDetails o in od)
                {

                    Console.WriteLine($"{o.Product.Name} || {o.Product.Description} || {o.Quantity}"); 
                }
                Console.WriteLine("===============================");
                Console.WriteLine($"Total: {order.Total}");
            }
            
            
            
        }

        public static void SelectStore(string selection, Customer customer, List<Location> locations, Repository data)
        {
            int index = 1;
            Location location = null;

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"+----------STORE MENU---------+  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"|      Select a store            ");
            foreach (Location l in locations)
            {
                Console.WriteLine($"+ {l.LocationName} ");
            }
            Console.WriteLine($"| [R] Return to previous menu    ");
            Console.WriteLine($"| [Q] Quit                       ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"+-----------------------------+  \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter store name: ");
            selection = Console.ReadLine();
            location = locations.Find(x => x.LocationName.Contains(selection));
            Console.Clear();
            SelectProducts(location, customer, data, locations);
        }

        public static List<Business.Library.Inventory> PrintLocationInventory(Repository data, Location location)
        {
            List<Business.Library.Inventory> inventories = data.GetInventoryforLocation(location);

            foreach (Business.Library.Inventory p in inventories)
            {
                Console.WriteLine($"| {p.Product.Name} || {p.Product.Description} || ${p.Product.Price} || {p.quantity}");
                Log.Information($"Printing Inventory: {p.Product.Name} || {p.Product.Description} || ${p.Product.Price} || {p.quantity}");
            }

            
            return inventories;
        }

        public static void PrintAllCustomers(Repository data)
        {
            List<Customer> customers = data.GetAllCustomers();

            foreach (Customer c in customers)
            {
                Console.WriteLine($"-> {c.Customername}");
            }
        }
        public static void PrintAllLocations(Repository data)
        {
            List<Location> locations = data.GetAllLocationProducts();

            foreach (Location l in locations)
            {
                Console.WriteLine($"-> {l.LocationName}");
            }
        }

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("../../../serilog.txt")
                .CreateLogger();

            Log.Information("Logger started:");
            string connectionString = SecretConfiguration.connectionString;

            DbContextOptions<StoreContext> options = new DbContextOptionsBuilder<StoreContext>()
                .UseSqlServer(connectionString)
                //.UseLoggerFactory(AppLoggerFactory)
                .Options;

            using var context = new StoreContext(options);
            using Repository data = new Repository(context);


            List<Location> locations = data.GetAllLocationProducts();
            List<Customer> customers = data.GetAllCustomers();


            Customer customer = null;
            int customerID = -1;
            string selection = "";
            string menu = "Main";
            int index = 0;

            //Initialize();

            while (selection != "q")
            {

                switch (menu)
                {
                    case "Main":

                        Console.WriteLine("\n\n");
                        ChangeColor(ConsoleColor.Blue);
                        Console.WriteLine("+----------MAIN MENU----------+");
                        ChangeColor(ConsoleColor.White);
                        if (customer != null)
                        {
                            Console.WriteLine($"            Hello \n" +
                                $"       {customer.Customername}!");
                        }
                        Console.WriteLine("|      Select an option       |");
                        Console.WriteLine("| [1] Sign up new customer    |");
                        Console.WriteLine("| [2] Make an order           |");
                        Console.WriteLine("| [3] Search customers        |");
                        if (customer != null)
                        {
                            Console.WriteLine($"| [4] Customer Order history   |");
                        }
                        Console.WriteLine("| [Q] Quit                    |");
                        ChangeColor(ConsoleColor.Blue);
                        Console.WriteLine("+-----------------------------+\n");
                        ChangeColor(ConsoleColor.White);

                        selection = Console.ReadLine();
                        Console.Clear();

                        switch (selection.ToLower())
                        {
                            case "1":
                                customer = AddNewCustomer(data);
                                Console.Clear();
                                break;

                            case "2":
                                if (customer == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Please select a customer first! \n");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    SelectStore(selection, customer, locations, data);
                                    Console.Clear();
                                }
                                break;
                            case "3":
                                Console.WriteLine("Select Customer:");
                                //foreach (Customer c in customers)
                                //{
                                //    Console.WriteLine($"+ Customer {c.Customername} ");
                                //}
                                Console.Write("Type a name: ");
                                selection = Console.ReadLine();
                                customer = customers.Find(x => x.Customername.Contains(selection));
                                if (customer == null)
                                {
                                    Console.WriteLine("Customer doesn't exist.");
                                }
                                Console.Clear();
                                break;
                            case "4":
                                if (customer == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Please select a customer first! \n");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    GetOrderHistory(customer, data);
                                    //Console.Clear();
                                }
                                //if (order_history == null)
                                //{
                                //    ChangeColor(ConsoleColor.Red);
                                //    Console.WriteLine($"No order history for {customer.Customername}");
                                //    ChangeColor(ConsoleColor.White);
                                //}
                                break;


                        }
                        break;

                }


            }

        }




    }
}
