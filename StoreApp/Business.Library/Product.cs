using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Library
{
    public class Product
    {
        private string _name;
        private string _description;
        private int _amount;

        public string Name
        {
            get => this._name;
        }

        public string Description
        {
            get => this._description;
        }

        public int Amount
        {
            get => this._amount;
            set => this._amount = value;
        }

        public Product(string name, string description)
        {
            if(name.Length == 0) 
            {
                throw new ArgumentException("Product name is empty.");
            }
            else if (description.Length == 0)
            {
                throw new ArgumentException("Product description is empty.");
            }
            else
            {
                this._name = name;
                this._description = description;
            }
        }
    }
}
