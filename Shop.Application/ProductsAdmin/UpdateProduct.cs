﻿using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class UpdateProduct
    {
        private AppDBContext _context;

        public UpdateProduct(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Response> Do(Request request)
        {
            await _context.SaveChangesAsync();
            return new Response();
        }

        public class Request
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }
        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }

        }

    }
   
}
