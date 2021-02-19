using Microsoft.EntityFrameworkCore;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.Products
{
    public class GetProduct
    {
        private AppDBContext _ctx;

        public GetProduct(AppDBContext ctx)
        {
            _ctx = ctx;
        }
        public ProductViewModel Do(string name) => _ctx.Products
            .Include(x => x.Stock)
            .Where(x => x.Name == name)
            .Select(x => new ProductViewModel
        {
            Name = x.Name,
            Description = x.Description,
            Price = $"PLN {x.Price.ToString("N2")}", // 1100.50 => 1,100.50
            Stock = x.Stock.Select(y => new StockViewModel
            {
                Id = y.Id,
                Descritpion = y.Description,
                InStock = y.Quantity > 0
            })
        }).FirstOrDefault();
        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Price { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
        }
        public class StockViewModel
        {
            public int Id { get; set; }
            public string Descritpion { get; set; }
            public bool InStock { get; set; }
        }
    }
}
