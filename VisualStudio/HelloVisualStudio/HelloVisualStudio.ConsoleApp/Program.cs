using HelloVisualStudio.ConsoleApp.Display;
using HelloVisualStudio.Library;
using HelloVisualStudio.Library.Sorting;
using System;
using System.Collections.Generic;
using System.Threading;

namespace HelloVisualStudio.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // separation of concerns
            // different concerns in code shouldn't be tangled together

            // single responsibility principle (S in SOLID)
            // a unit of code like class method should have just one responsibility

            // DRY principle do not repeat yourself
            // KISS Keep it simple stupid

            // functionalities 
            // have a list of products
            List<Product> catalog = GetProducts();

            // user's choice of sort and display
            string userInput = null;
            while (userInput != "s" && userInput != "d")
            {
                Console.WriteLine("Enter s for simple, d for detailed");
                userInput = Console.ReadLine();
            }

            // dependency inversion principle (D in SOLID)
            // dont have classes depend on each other directly
            // instead, have them depend on 
            //  A(B)  ,  A(Interface B)
            // polymorphism
            string userInput2 = null;
            while (userInput2 != "y" && userInput2 != "n")
            {
                Console.WriteLine("Have the list sorted? y/n ");
                userInput2 = Console.ReadLine();
            }

            ISorter sorter;
            if (userInput2 == "y")
            {
                sorter = new PriceSorter();
            }
            else
            {
                sorter = new NonSorter();
            }

            // sorted catalog goes in to writer
            IWriter writer;
            if (userInput == "s")
            {
                writer = new SimpleWriter(sorter);
            }
            else
            {
                writer = new DetailedWriter(sorter);
            }

            writer.FormatAndDisplay(catalog);

        }

       

        static List<Product> CollectionDigression()
        {
            // built-in collection of C# / .net
            // most basic- array []
            // low level, less "overhead"
            // fixed size sequence of a particular data type
            

            // an array of 5 ints, initial value default to 0        
            var numbers = new int[5];
            // setting the fourth value in the array to 1
            // indexing in most language, starts from 0
            numbers[3] = 1;

            // difficult with arrays is, the fixed size
            // makes memory management simple, know advance how much we need and allocate the amount

            // System.Collection.ArrayList is an old alternative to arrays in C#
            var numbers2 = new System.Collections.ArrayList();
            numbers2.Add(1);
            numbers2.Add(2);
            numbers2.Add(3);
            numbers2.Remove(3); // remove the first instance of 3

            // arraylist supports adding all types
            numbers2.Add("abc");
            numbers2.Add(true);
            numbers2.Add(new Product("", "", 1, 1));

            // both dont do numeric conversions, user-defined conversions
            // type checking: is
            if (numbers2[0] is int)
            {
                // string is reference type, but compare values, convenient
                // "abc" = "abc";
            }

            // type conversion: as
            // explicit conversion, but if fails, returns null, not throw exception
            else
            {
                Product product = numbers2[0] as Product;
                if (product != null)
                { 
                    // casting worked
                }
            }
            // user-defined conversion : implicit(dangerous) , explicit
            // discouraged often

            // c# support overloading the [] operator indexing operator
            // randomizes the order
            // C# type system doesn't know the type in the arraylist
            // (casting) to inform the compiler that we know more about its type
            // reverse indexing ^2 second from the end
            int x = (int)numbers2[0];// get the first number in the arraylist
            x++;

            // downcasting(explicit: manual() dangerous)- the arraylist could only guarantee the value was some descendant of "object"
            // upcasting(implicit) - a specific type to a less specific type
            object o = x;
            // boxing: upcast a value type to object boxes the value in a  type container
            // unboxing: downcast from that object to the value

            // differnt "casting" neither upcasting nor downcasting
            // because int and double dont have a parent child relationship, they are siblings
            // conversion dangerous(could lose data), explicit
            // invalidCastException
            double pi = 3.14;
            int three = (int)pi;

            // 8-byte sizefloating point (double) enough to store every integer that could fit in 4-byte Int
            // cannot lose data , implicit
            int a = 4;
            double four = a;


            Product p = new Product("a", "b", 1, 1);
            ApplyDiscount(p);
            // if Product was value type, p here would not get discounted
            // a copy gets modifed and tosses away

            // don't use types like ArrayList anymore, c# supports generics
            // List<T> replaces ArrayList, flexible size and specific data type
            // type parameter, type -> <>
            var list = new List<int>();
            list.Add(4); // no upcasting
            // var list = new List<int> {4,3,2,1};
            var z = list[0]; // no downcasting, the compiler knows it must be an int

            // unsafe



            return null;
        }

        // any time you have a method that has only one statement, "return _____;",
        // use "expression-body syntax"
        static List<Product> GetProducts() =>
            // create a list of products and add 3 items to it
            new List<Product>
            {
                new Product("0001","laptop",1000.00,5),
                new Product("0003","pizza",10.00,50),
                new Product("0004","coffee",10.00,20)

            };

        // returns 3
        // static int GetThree() => 3;

        static void ApplyDiscount(Product p)
        {
            p.Price *= 0.85;

        }

    }
}
