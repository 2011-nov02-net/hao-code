using System.Collections.Generic;

namespace ComplexStore.DataModel.Model
{
    public class Location
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public int Stock { get; set; }

        // one order has one location, but one location can have many orders
        // 
        public ICollection<Order> Orders { get; set; }


    }
}