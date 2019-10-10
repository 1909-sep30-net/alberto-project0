using System;
using System.Collections.Generic;
using Business.Library;

namespace UserInterface.App
{
    class UI
    {
        public static List<Customer> customers = new List<Customer>();
        public static List<Location> location = new List<Location>();

        public void AddNewCustomer()
        {
            Console.WriteLine("Please enter first name:");
            string fname = Console.ReadLine();

            Console.WriteLine("Please enter last name:");
            string lname = Console.ReadLine();

            try
            {
                Customer customer = new Customer(fname, lname);
                customers.Add(customer);
            }
            catch(ArgumentException e)
            {

            }
        }
        static void Main(string[] args)
        {
            string selection = "";
            string menu = "Main";

            while(selection != "Q")
            { 
                
                //switch (menu)
                //{
                //    case "Menu":
                //        Console.WriteLine("+----------MAIN MENU----------+");
                //        Console.WriteLine("|      Select an option       |");
                //        Console.WriteLine("| [1] Sign up new customer    |");
                //        Console.WriteLine("| [2] Select store location   |");
                //        Console.WriteLine("| [Q] Quit                    |");
                //        Console.WriteLine("+-----------------------------+");

                //        selection = Console.ReadLine();
                //        if (selection == "1")
                //        {
                            
                            
                //        }

                //}

                
            }
           
        }



        
    }
}
