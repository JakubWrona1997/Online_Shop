using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
    public class CreateStock
    {
        private AppDBContext _ctx;

        public CreateStock(AppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var stock = new Stock                       //Relate it to the stock object  
            {
                Description = request.Description,
                Quantity = request.Quantity,
                ProductId = request.ProductId           //Reassigning ID
            };

            _ctx.Stock.Add(stock);
            await _ctx.SaveChangesAsync();

            return new Response
            {
                Id = stock.Id,
                Description = stock.Description,
                Quantity = stock.Quantity
            };
            
        }
        public class Request
        {
            public int ProductId { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }
        }
        public class Response //copy of the stock object
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Quantity { get; set; }

        }
    }
}
