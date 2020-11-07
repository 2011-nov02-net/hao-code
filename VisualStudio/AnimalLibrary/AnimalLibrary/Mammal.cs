using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalLibrary
{
    public abstract class Mammal : IAnimal
    {
        // if it is a solid class, will have not implement exception
        public abstract int LegCount { get; }

        public abstract bool CanSwin { get; }

        public abstract double Height { get; }

        public virtual bool LayEggs => false;
        // C# by default, disables override
        // vitual enables overriding in parent,  override in children to override
    }
}
