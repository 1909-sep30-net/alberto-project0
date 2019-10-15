using System;
using System.Collections.Generic;
using System.Threading;
using Business.Library;

namespace UserInterface.App
{
    class UI
    {
        public static void ChangeColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static List<Customer> customers = new List<Customer>()
        {
            new Customer("Alberto", "Acevedo"),
            new Customer("Alex", "Rodriguez"),
            new Customer("Timmithy", "Xenomorph")
        };



        public static List<Location> locations = new List<Location>()
        {
            new Location("Starbucks"),
            new Location("Chick-Fil-A"),
            new Location("BurgerIM")

        };

        public static List<Product> s_products = new List<Product>()
        {
            new Product("Caramel Frappachino", "Venti", 7.50m),
            new Product("White Mocha Hot", "Grande", 5.20m),
            new Product("Pumpkin Spice Machiatto", "Venti", 7.50m)
        };

        public static List<Product> c_products = new List<Product>()
        {
            new Product("Chicken Sandwich", "Meal", 8.75m),
            new Product("Grilled Nuggets", "Meal", 5.20m),
            new Product("Spicy Chicken Sandwhich", "Meal", 5.50m)
        };

        public static List<Product> b_products = new List<Product>()
        {
            new Product("Mini Trio", "Meal", 8.75m),
            new Product("Angus Beef", "Single", 6.99m),
            new Product("Wings", "Wednesday Special", 0.75m)
        };

        public static void Initialize()
        {
            foreach (Product p in s_products)
                locations[0].AddItem(p, 20);
            foreach (Product p in c_products)
                locations[1].AddItem(p, 20);
            foreach (Product p in b_products)
                locations[2].AddItem(p, 20);
        }

        public static void AddNewCustomer()
        {
            ChangeColor(ConsoleColor.Green);
            Console.WriteLine("Please enter first name:");
            ChangeColor(ConsoleColor.White);
            string fname = Console.ReadLine();

            ChangeColor(ConsoleColor.Green);
            Console.WriteLine("Please enter last name:");
            ChangeColor(ConsoleColor.White);
            string lname = Console.ReadLine();

            try
            {
                Customer customer = new Customer(fname, lname);
                customers.Add(customer);
            }
            catch (ArgumentException e)
            {

            }
        }

        public static Order_history SelectProducts(Location location, Customer customer, out Order_history order_history)
        {
            int index = 1;
            int quantity = 0;
            List<Product> cart = new List<Product>();
            Order order = new Order(location, customer, location.Inventory);
            Order_history submitted_order = null;
            Product item = null;
            string option = null;
            order_history = null;

            while (option != "c" && option != "r")
            {
                Console.Write($"Hello ");
                Console.WriteLine($"{customer.Customername}");
                Console.WriteLine($"Welcome to {location.LocationName}!  ");
                Console.WriteLine($"| Product || Description || Price || Quantity         ");
                ChangeColor(ConsoleColor.Blue);
                Console.WriteLine("====================================================");
                ChangeColor(ConsoleColor.White);
                foreach (Product p in location.Inventory)
                {
                    Console.WriteLine($"| {p.Name} || {p.Description} || ${p.Price} || {p.Amount}");
                    index++;
                }
                ChangeColor(ConsoleColor.Blue);
                Console.WriteLine("====================================================");
                ChangeColor(ConsoleColor.White);
                Console.WriteLine($"| [R] Return to previous menu    ");
                Console.WriteLine($"| [M] Return to main menu    ");
                ChangeColor(ConsoleColor.Blue);
                Console.WriteLine($"+-----------------------------------------------+  \n");
                ChangeColor(ConsoleColor.White);
                Console.Write("Select product names or R/Q: ");
                option = Console.ReadLine();

                if (option.ToLower() == "r")
                {
                    Console.WriteLine("Returning to previous menu...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    SelectStore(option, customer, out order_history);
                    return null;
                }
                else if (option.ToLower() == "m")
                {
                    Console.WriteLine("Returning to main menu...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    submitted_order = order_history;
                    return null;
                }

                else
                {
                    item = location.Inventory.Find(x => x.Name.Contains(option));
                    Console.Write("How many: ");
                    option = Console.ReadLine();
                    int.TryParse(option, out quantity);
                    order.AddToCart(item, quantity);

                    if (!order.CartisEmpty())
                    {
                        Console.WriteLine("\n");
                        order.OCart();
                    }
                }
                Console.WriteLine("Press C to checkout or any other key to add more. ");
                option = Console.ReadLine().ToLower();
                Console.Clear();
            }
            submitted_order = new Order_history(customer, location, order);
            return submitted_order;



        }

        public static void GetOrderHistory(Customer customer)
        {
            Order_history oh = null;
        }

        public static void SelectStore(string selection, Customer customer, out Order_history order_history)
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
            order_history = SelectProducts(location, customer, out order_history);
        }

        static void Main(string[] args)
        {

            Customer customer = null;
            Order_history order_history = null;
            int customerID = -1;
            string selection = "";
            string menu = "Main";
            int index = 0;

            Initialize();

            while (selection != "q")
            {

                switch (menu)
                {
                    case "Main":
                        //Console.WriteLine("DEBUG MODE: \n");

                        //Order order = new Order(locations[0], customers[0], locations[0].Inventory);
                        //locations[0].PrintInventory(locations[0].Inventory[1]);
                        //Console.WriteLine("Orders:");
                        //order.PrintLocationInventory();

                        //Console.WriteLine($"Adding {locations[0].Inventory[1].Name} into cart");
                        //order.AddToCart(locations[0].Inventory[1], 23);
                        //order.AddToCart(locations[0].Inventory[0], 2);
                        //Console.WriteLine("Below is cart:");
                        //order.OCart();
                        //order.PrintLocationInventory();

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
                        Console.WriteLine("| [3] Select customers        |");
                        if (customer != null)
                        {
                            Console.WriteLine($"| [4] Order history           |");
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
                                AddNewCustomer();
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
                                    SelectStore(selection, customer, out order_history);
                                    Console.Clear();
                                }
                                break;
                            case "3":
                                Console.WriteLine("Select Customer:");
                                foreach (Customer c in customers)
                                {
                                    Console.WriteLine($"+ Customer {c.Customername} ");
                                }
                                Console.Write("Type name: ");
                                selection = Console.ReadLine();
                                customer = customers.Find(x => x.Customername.Contains(selection));
                                Console.Clear();
                                break;
                            case "4":
                                if (order_history == null)
                                {
                                    ChangeColor(ConsoleColor.Red);
                                    Console.WriteLine($"No order history for {customer.Customername}");
                                    ChangeColor(ConsoleColor.White);
                                }
                                break;

                        }
                        break;

                }


            }

        }




    }
}
