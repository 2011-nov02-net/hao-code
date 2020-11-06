using HelloVisualStudio.Library;
using HelloVisualStudio.Library.Sorting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloVisualStudio.ConsoleApp.Display
{
    /// <summary>
    /// General purpose of class
    /// Responsible for formatting and printing a collection of products
    /// XML comment/style format
    /// like java doc
    /// </summary>
    /// 
    /// <remarks>
    /// more detailed info, like implementation decisions
    /// </remarks>
    /// 
    /// <example>
    /// </example>
 

    public class SimpleWriter : IWriter
    {
        // takes an interface as parameter, not NonSorter/PriceSorter object, more flexible
        // readonly when declaring or constructing
        private readonly ISorter sorterField;
        public SimpleWriter(ISorter sorter)
        {
            sorterField = sorter;
        }

        public void FormatAndDisplay(List<Product> catalog)
        {
            foreach (var product in sorterField.SortProducts(catalog))
            {
                Console.WriteLine(product.Id);
            }

    }
    }
}
