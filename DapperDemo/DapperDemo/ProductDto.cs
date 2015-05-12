using System;

namespace DapperDemo
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Model { get; set; }
        public decimal Price { get; set; }
        public int Stocks { get; set; }
    }
}
