using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalLibrary
{
    public abstract class Mammal : IAnimal
    {
        // if it is a solid class, will have not implement exception
        public Mammal(double height)
        {
            Height = height;
        }

        public Mammal() { }

        public abstract int LegCount { get; }

        public abstract bool CanSwim { get; }

        // must have get and set if want to use Properties like a field, check public/ private as well
        public abstract double Height { get; set; }

        public virtual bool LayEggs => false;
        // C# by default, disables override
        // vitual enables overriding in parent,  override in children to override

        // how can i share some code that several classes need
        // - direct inheritance between those classes
        //       with inheritance, you have to be careful to follow Liskov substitution principle -
        //              anywhere in your code that you accept a parameter of type X, it should also work correctly
        //              if you pass any derived type of X.
        // - introduce an abstract base class for all of those classes to inherit from.
        //       only on the table if they're not already inheriting from something else
        //       can have constructors, but only for derived classes
        //       abstract class cannot itself be instantiated.
        // - composition/delegation
        //     instead of using inheritance to share code, put it on a class of its own, and those several classes
        //     that use that code can have an instance of that class. ("is-a" relationship vs "has-a" relationship)
        //         ways to improve this strategy... use interfaces, follow dependency inversion principle.

        // C# does not support multiple inheritance - one class can implement many interfaces,
        //    but one class can only inherit from one other class


    }
}
