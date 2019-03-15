using System;

namespace BeadsInventory.Models {

    public class Bead {

        public int ID {get; set;}
        public string Material {get; set;}
        public string Shape {get; set;}
        public string Color {get; set;}
        public int Size_MM {get; set;}
        public int Quantity {get; set;}
        public decimal Price_Point {get; set;}

    }
}
