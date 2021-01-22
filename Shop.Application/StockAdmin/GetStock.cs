using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Application.StockAdmin
{
    public class GetStock
    {
        private AppDBContext _ctx;

        public GetStock(AppDBContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<StockViewModel> Do(int productID)
        {
            var stock = _ctx.Stock.Where(x => x.ProductId == productID).Select(x => new StockViewModel {
                Id = x.Id,
                Description = x.Description,
                Quantity = x.Quantity
            }).ToList();

            return stock;
        }
        public class StockViewModel
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
        }
    }
}
