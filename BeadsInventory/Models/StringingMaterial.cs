using System;

namespace BeadsInventory.Models {

    public class StringingMaterial {

        public int ID { get; set; }
        public string Category { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public double Price_Per_Foot { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
    }
}
