using System;
using System.Collections.Generic;
using System.Text;

namespace HelloVisualStudio.ConsoleApp
{
    /// <summary>
    /// Responsible for formatting and printing
    /// (General purpose of class)
    /// XML style format
    /// java doc
    /// 
    /// </summary>
    /// <remarks>
    /// more detailed info, like implementation decisions
    /// </remarks>
    /// <example>
    /// </example>
    
    class SimpleWriter : IWriter
    {
        private readonly ISorter sorter;

        // constructor here
        public SimpleWriter(ISorter sorter)
        {
            this.sorter = sorter;
        }

        public void FormatAndDisplay(List<Product> catalog)
        {
            foreach (var product in this.sorter.SortProducts(catalog))
            {
                Console.WriteLine(product.Id);
            }

    }
    }
}
