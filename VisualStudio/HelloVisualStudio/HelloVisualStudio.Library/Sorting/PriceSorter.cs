﻿
using HelloVisualStudio.Library.Sorting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace HelloVisualStudio.Library.Sorting
{
    public class PriceSorter : ISorter
    {
        public List<Product> SortProducts(List<Product> catalog)
        {
            return catalog.OrderBy(x => x.Price).ToList();
        }
    }
}
