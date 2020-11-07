using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalLibrary
{
    public interface IAnimal
    {
        int LegCount { get; }
        bool CanSwin { get; }
        double Height { get; }
    }
}
