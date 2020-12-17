using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products
{
    public class CreateProduct
    {
        private AppDBContext _context;

        public CreateProduct(AppDBContext context)
        {
            _context = context;
        }

        public async Task Do(ProductViewModel vM)
        {
            _context.Products.Add(new Product
            {
                Name=vM.Name,
                Description=vM.Description,
                Price=vM.Price
            }
            );

            await _context.SaveChangesAsync();
        }
       
    }
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
