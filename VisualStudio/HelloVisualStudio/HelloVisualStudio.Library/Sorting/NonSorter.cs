using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using HelloVisualStudio.Library;
// using 

namespace HelloVisualStudio.Library.Sorting
{
    public class NonSorter: ISorter
    {
        public List<Product> SortProducts(List<Product> catalog)
        {
            // no sort
            // ToList() brand new list
            return catalog.ToList();
        }
    }
}
