using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalLibrary
{
    public class Cats: Mammal
    {
        // first step of a constructor- call one of the parent class's constructors.
        // by default, calls the zero-parameter one; if there isn't one, compile error.
        // : choose a different parent's constructor

        // can have your own additional parameters
        // default value moves to the right, 
        public Cats(double height, bool canSwim) : base(height)
        {
            CanSwim = canSwim;
        }

        // have a more comlicated constructor builds on top of a simple one
        // cant have this refer to another this, inf loop
        public Cats(double height): this(height,true)
        { }

        public override int LegCount => 4;


        // c# supports "nullable" versions of all the value types (struct).
        // like "bool?"
        // this is a syntactic sugar for a special generic type: Nullable<bool>
        // user null as a return value
        public override bool CanSwim { get; }

        public override double Height { get; set; }
        
    }
}
