using System;
using DapperModel;

namespace DemoEF.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            var clothers = new Category()
            {
                Code = "clothers",
                Name = "Clothers",
                Description = "Men Clothers"
            };

            var food = new Category()
            {
                Code = "foods",
                Name = "Foods",
                Description = "All foods"
            };

            CreateProducts(clothers);
            CreateProducts(food);

            context.Categories.AddOrUpdate(clothers, food);
        }

        private void CreateProducts(Category category)
        {
            int max = new Random().Next(1000, 2000);
            for (int index = 0; index < max; index++)
            {
                var product = new Product()
                {
                    Name = "Product " + (index + 1),
                    Description = "About the product index " + index,
                    Model = new Random().Next(1999, 2015),
                    Price = Convert.ToDecimal(new Random().NextDouble())
                };
                category.Products.Add(product);
            }
        }
    }
}
