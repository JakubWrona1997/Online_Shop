﻿using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
    public class DeleteStock
    {
        private AppDBContext _ctx;

        public DeleteStock(AppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Do(int id)
        {
            var stock = _ctx.Stock.FirstOrDefault(x => x.Id == id);

            _ctx.Stock.Remove(stock);

            await _ctx.SaveChangesAsync();

            return true;
            
        }
   
    }
}
