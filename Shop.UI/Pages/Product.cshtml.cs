using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Products;
using Shop.Database;

namespace Shop.UI.Pages
{
    public class ProductModel : PageModel
    {
        private AppDBContext _ctx;
        public ProductModel(AppDBContext ctx)
        {
            _ctx = ctx;
        }

        public GetProduct.ProductViewModel Product { get; set; }
        public void OnGet(string name)
        {
            Product = new GetProduct(_ctx).Do(name.Replace(" ", ""));
        }
    }
}