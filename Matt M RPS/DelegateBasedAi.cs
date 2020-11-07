using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RPS
{
    // can have a delegate here
    public class DelegateBasedAi : IAI
    {
        // c# can pass around function/methods as though they were just another form of data
        // attitude from functional programming, differernt from object oriented programming(data and behaviors)
        // 
        // delegates
        // defines a type just like a class
        // a variable of type of int can hold any int as its value
        // a variable of type MoveChooser can hold any function that takes one string and returns one string
        // a variable of a delegate type can contain any delegate that matches the type's signature
        // like a function pointer in , like a callback function in JS

        // transformation

        public delegate string MoveChooser(string lastPlay);
        // private readonly Func<string, string> chooserField;
        

        // basically store a method
         private readonly MoveChooser chooserField;
        // public DelegateBasedAi(Func<string,string> chooser)
        // Func logic wise more straight forward, but less soft documenting(name of variable MoveChooser)

        // event
        // when this event happens, send 3 ints to eventhandlers that subscribes
        public event Action<int, int, int> Progress;

        public DelegateBasedAi(MoveChooser chooser){
            // still an object
            // cant instantiate it, but can construct value that will fit into it
            // through static method or lambda expression
            // reflection
            chooser.GetMethodInfo();
            chooserField = chooser;
            // Progress += chooserField; wrong type
            // every time the progress event gets fired, this function will run with augements provided
            Progress += (a, b, c) => { Console.WriteLine("Some action!"); };

        }
        public string ChooseRPS(string lastPlay)
        {
            return chooserField(lastPlay);
        }
        // each instance of this class could do something totally different - depends on what delegat
        // was provided to the constructor

        // defining your own delegate doesnt happen often
        // using it happen all the time
        // lambda expression is a delegate
        // lINQ is 
        // one way to do polymsimilar like interface

        static void Delegatestuff(Func<int,int> func)
        {
            func(1);
            // depends on the func was passed to this method

            // dont have to define delegate type this way
            // use some built-in generic ones
            // Func
            // Action
            // has many formats
            
            // first part is delegate, public delegate int methodx(int a, int b)
            // second part is the method as arugment,  add takes int a and int b, return a+b
            // no void return type
            Func<int, int, int> add = (a,b) => a + b;
            Func<int, int, string> sum = (a, b) => (a + b).ToString();

            // int x, string y, return void
            Action<int, string> nl = (a, b) => { Console.WriteLine(a + b); };

            string three = sum(1, 2); // "3"
            nl(12, "a"); // prints "12a"
        }
    }
}
