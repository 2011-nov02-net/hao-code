using System;
using System.Collections.Generic;
using System.Text;

namespace HelloVisualStudio.ConsoleApp
{
    public interface IWriter
    {
        // can contain methods and properties
        // just signature not implementation
        // cannot contain constructor fields
        
        void FormatAndDisplay(List<Product> catalog);
        // all members use the same access modifier as the whole interface
        // not make sense to have one different


    }
}
