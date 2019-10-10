using System;

namespace Business.Library
{
    public class Customer
    {
        private string _firstname;
        private string _lastname;

        public Customer(string fname, string lname)
        {
            if ((fname.Length == 0) || (lname.Length == 0))
            {
                throw new ArgumentException("Please enter first and last name.");
            }
            else
            {
                this._firstname = fname;
                this._lastname = lname;
            }
        }

        public string Customername 
        { 
            get { return this._firstname + " " + this._lastname; }
            //set { this._firstname = value; }
        }



        

    }
}
