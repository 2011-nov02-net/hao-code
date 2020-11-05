using System;
using System.Collections.Generic;

namespace HelloVisualStudio.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // separation of concerns
            // different concerns in code shouldn't be tangled together

            // single responsibility principle
            // a unit of code like class method should have just one responsibility

            // DRY principle do not repeat yourself

            // have a list of products
            
            // display them to the user

            // allow for some customization of that display to the user
            
        }

        static List<Product> GetProduct()
        {
            // built-in collection of C# / .net
            // most basic array
            // low level, less overhead
            // fixed size sequence of a particular data type

            // initial value default to 0
            // indexing starts at 0
            var numbers = new int[5];
            numbers[3] = 1;
            return null;
        }

    }
}
