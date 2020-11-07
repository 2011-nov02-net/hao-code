using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace AnimalLibrary
{
    public class Person: Mammal
    {
        public string Name{get; set;}
        public string Job { get; set; }

        public override int LegCount => 2;

        

        public override bool CanSwin => throw new NotImplementedException();

        public override double Height => throw new NotImplementedException();
    }
}
