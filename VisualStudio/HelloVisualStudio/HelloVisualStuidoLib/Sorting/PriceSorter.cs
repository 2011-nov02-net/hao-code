using HelloVisualStudio.ConsoleApp.Sorting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace HelloVisualStudio.ConsoleApp.Sorting
{
    public class PriceSorter : ISorter
    {
        public List<Product> SortProducts(List<Product> catalog)
        {
            return catalog.OrderBy(x => x.Price).ToList();
        }
    }
}
