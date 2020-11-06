using System;
using System.Collections.Generic;
using System.Text;

namespace HelloVisualStudio.ConsoleApp
{
    public class DetailedWriter: IWriter
    {
        public void FormatAndDisplay(List<Product> catalog)
        {
            foreach (var product in catalog)
            {
                // string interpolation syntax $"{}"
                // c currency
                Console.WriteLine($"{product.Id} {product.Price:c}");
            }

        }
    }
}
