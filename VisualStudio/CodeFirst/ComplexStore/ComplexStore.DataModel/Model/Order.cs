using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexStore.DataModel.Model
{
    public class Order
    {
        // tap tap
        // 
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public double TotalCost { get; set; }

        public string LocationId { get; set; }
        public Location StoreLocation { get; set; }



    }
}
