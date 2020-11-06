using System;
using System.Collections.Generic;
using System.Text;

namespace HelloVisualStudio.ConsoleApp.Sorting
{
    public interface ISorter
    {
        List<Product> SortProducts(List<Product> products);
    }
}
