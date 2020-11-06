using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
// using 

namespace HelloVisualStudio.ConsoleApp.Sorting
{
    public class NonSorter: ISorter
    {
        public List<Product> SortProducts(List<Product> catalog)
        {
            // does not sort
            // what's the point of ToList()
            return catalog.ToList();
        }
    }
}
