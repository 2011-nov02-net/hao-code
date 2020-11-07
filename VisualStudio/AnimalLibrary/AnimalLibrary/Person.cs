using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace AnimalLibrary
{


    public class Person: Mammal
    {
        public Person(string name, string occupation, double height)
        {
            Name = name;
            Job = occupation;
            Height = height;
        }
        public string Name{get; set;}
        public string Job { get; set; }

        public override int LegCount => 2;



        public override bool CanSwim => true;

        public override double Height { get; set; }
    }
}
