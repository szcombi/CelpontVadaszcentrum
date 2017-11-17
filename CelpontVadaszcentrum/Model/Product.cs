using System.Collections.Generic;

namespace CelpontVadaszcentrum.Model
{
    public class Product
    {
        public Product()
        {
            
        }

        public string Description { get; set; }

        public string Description_Short { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public List<string> Images { get; set;}



    }
}