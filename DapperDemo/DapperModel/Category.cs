using System;
using System.Collections.Generic;

namespace DapperModel
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Product> Products { get; set; }

        public Category()
        {
            Id = Guid.NewGuid();
            Products = new List<Product>();
        }
    }
}
