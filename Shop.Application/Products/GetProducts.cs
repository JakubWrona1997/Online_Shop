using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.GetProducts
{
    public class GetProducts
    {
        private AppDBContext _ctx;

        public GetProducts(AppDBContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<ProductViewModel> Do() => _ctx.Products.ToList().Select(x => new ProductViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Price=$"PLN {x.Price.ToString("N2")}", // 1100.50 => 1,100.50
            });
    }
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
