using System;
using System.Collections.Generic;
using System.Text;

namespace HelloVisualStudio.ConsoleApp
{

    // access modifier in C#
    // default is the most restrictive possible
    // default on a type like class is internal

    // internal - only code in the same project can see it
    // public - everyone code can access
    // private - code only in this class can access
    // protected - code in dervied types is allowed, even in other projects

    // private proectected - in the subclass and the same project
    // protected internal - in the subclass or the same project
    public class Product
    {
        // id
        // further restriction
        public string  Id { get; private set; }

        // name
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        // price
        private double price;

        public double Price
        {
            get { return price; }
            set 
            {
                if (value < 0)
                {
                    // more specific 
                    throw new ArgumentOutOfRangeException("value","Price must be positive");
                }
                price = value; 
            }
        }


        // quantity
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set 
            {
                if (value < 0)
                    // used when argument invalid
                    throw new ArgumentException(" cannot have negative quantity");
                quantity = value; 
            }
        }


        // constructor

        // compiler generates a default constructor if not provided 
        // public Product()
        // {    
        // }

        // must have constructor if the object requires some data to exist
        public Product(string id, string name, double price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;

        }

        public void AddInventory(int count)
        {
            // getter a value and setter the updated value
            //Quantity += count;
            quantity += count;
        }
    }
}
