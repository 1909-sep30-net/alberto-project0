using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Library
{
    public class Location
    {
        private List<Product> _inventory;
        private string _name;
        private string _address;
        private string _quantity;
        private Product item = null;

        public string LocationName
        {
            get => this._name;
        }

        public string LocationAddress
        {
            get => this._address;
        }

        public List<Product> Inventory
        {
            get => this._inventory;
        }

        public void PrintInventory(Product product)
        {
            int i = 0;
            foreach(Product p in Inventory)
            {
                Console.WriteLine($"Index: {_inventory.IndexOf(product)}, {p.Name}");
                i++;
            }

        }


        public Location(string name)
        {
            if (name.Length == 0)
            {
                throw new ArgumentException("Location name is invalid.");
            }
            else
                this._name = name;

            this._inventory = new List<Product> { };
        }

        public int Quantity(Product product)
        {
            //item = new Product(product.Name, product.Description, product.Price);
            int index = _inventory.IndexOf(product);
            try
            {
                return _inventory[index].Amount;
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Index is {index}!!!!!!!");
                return -1;
            }
        }

        public bool AddItem(Product product, int quantity)
        {
            item = new Product(product.Name, product.Description, product.Price);
            int index;

            if (_inventory.Contains(item))
            {
                index = _inventory.IndexOf(item);
                _inventory[index].Amount += quantity;
                return true;
            }
            else
            {
                _inventory.Add(item);
                index = _inventory.IndexOf(item);
                _inventory[index].Amount+= quantity;
                return true;
            }

        }

        public bool RemoveItem(Product product, int quantity)
        {
            //item = new Product(product.Name, product.Description, product.Price);
            int index = _inventory.IndexOf(product);
            if (index == -1)
            {
                throw new ArgumentException($"Item {item.Name} is not found in inventory.");
            }
            else if(_inventory[index].Amount < quantity)
            {
                throw new ArgumentException($"Cannot remove the amount requested.");
                           
            }
            else if (_inventory[index].Amount == 1)
            {
                _inventory.Remove(item);
                return true;
            }
            else
            {
                _inventory[index].Amount -= quantity;
                return true;
            }
            
        }




    }
}
