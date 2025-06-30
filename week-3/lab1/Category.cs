using System.Collections.Generic;

namespace lab1
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
