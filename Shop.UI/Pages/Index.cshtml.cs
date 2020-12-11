using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Shop.Database;
using Shop.Application.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private AppDBContext _ctx;

        public IndexModel(ILogger<IndexModel> logger, AppDBContext context)
        {
            _logger = logger;
            _ctx = context;
        }
        [BindProperty]
        public ProductViewModel Product { get; set; }
        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            await new CreateProduct(_ctx).Do(Product.Name, Product.Description, Product.Price);

            return RedirectToPage("Index");
        }
    }
}
