using Dapper;
using DemoEF;
using System;
using System.Diagnostics;
using System.Linq;

namespace DapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();

            // 1 - uses Dapper
            watch.Restart();

            using (var accessor = new StoreConnectionAccessor())
            {
                var results = accessor.Connection.Query<ProductDto>(new CommandDefinition("select * from [store].[Product]"));
                Console.WriteLine("Total: " + results.Count());
            }

            watch.Stop();
            var time = watch.ElapsedMilliseconds;

            // 2 - uses EF
            watch.Restart();
            using (var context = new StoreContext())
            {
                var items = context.Categories.SelectMany(x => x.Products).Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Description = p.Description,
                    Model = p.Model,
                    Name = p.Name,
                    Price = p.Price,
                    Stocks = p.Stocks
                });
            }
            watch.Stop();

            var time2 = watch.ElapsedMilliseconds;

            Console.WriteLine("Dapper time: " + time);
            Console.WriteLine("EF time: " + time2);
            Console.WriteLine("EF / Dapper: " + (double)time2 / time);

            Console.ReadLine();
        }
    }
}
