using HelloVisualStudio.Library.Sorting;
using HelloVisualStudio.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloVisualStudio.ConsoleApp.Display
{
    public class DetailedWriter : IWriter
    {
        private readonly ISorter sorterField;
        public DetailedWriter(ISorter sorter)
        {
            sorterField = sorter;
        }

        public void FormatAndDisplay(List<Product> catalog)
        {
            foreach (var product in sorterField.SortProducts(catalog))
            {
                // string interpolation syntax $"{}"
                // embed c# expression into string automatically convert to string
                // c currency, only works with string interpolation in {}
                Console.WriteLine($"{product.Id} {product.Name} {product.Price:c} ({product.Quantity})");
            }

        }
    }
}
