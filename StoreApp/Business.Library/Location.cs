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


        public Location(string name, string address)
        {
            if (name.Length == 0)
            {
                throw new ArgumentException("Location name is invalid.");
            }
            else
                this._name = name;

            if (address.Length == 0)
            {
                throw new ArgumentException("Location address is invalid.");
            }
            else
                this._address = address;

            this._inventory = new List<Product> { };
        }

        public int Quantity(Product product)
        {
            int index = _inventory.IndexOf(product);
            return _inventory[index].Amount;
        }

        public void AddItem(Product product, int quantity)
        {
            int index;

            if (_inventory.Contains(product))
            {
                index = _inventory.IndexOf(product);
                _inventory[index].Amount += quantity;
            }
            else
            {
                _inventory.Add(product);
                index = _inventory.IndexOf(product);
                _inventory[index].Amount+= quantity;
            }

        }

        public void RemoveItem(Product product, int quantity)
        {
            int index = _inventory.IndexOf(product);
            if (index == -1)
            {
                throw new ArgumentException($"Item {product.Name} is not found in inventory.");
            }
            else if (_inventory[index].Amount == 1)
            {
                _inventory.Remove(product);
            }
            else
            {
                _inventory[index].Amount -= quantity;
            }
        }




    }
}
