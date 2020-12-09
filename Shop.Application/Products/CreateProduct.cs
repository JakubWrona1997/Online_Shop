using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Products
{
    public class CreateProduct
    {
        private AppDBContext _context;

        public CreateProduct(AppDBContext context)
        {
            _context = context;
        }

        public void Do(int id, string name, string description, decimal price)
        {
            _context.Products.Add(new Product
            {
                Id=id,
                Name=name,
                Description=description,
                Price=price
            }
            );
        }
    }
}
