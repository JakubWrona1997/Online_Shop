using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Database;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Shop.Application.Products;
using Shop.Application.ProductsAdmin;

namespace Shop.UI.Pages
{
    public class IndexModel : PageModel
    {
        
        private AppDBContext _ctx;

        public IndexModel(AppDBContext context)
        {
            _ctx = context;
        }
        [BindProperty]
        public CreateProduct.Request Product { get; set; }
   
        public IEnumerable<Application.ProductsAdmin.GetProducts.ProductViewModel> Products { get; set; }
        public void OnGet()
        {
            Products = new Application.ProductsAdmin.GetProducts(_ctx).Do();
        }
        public async Task<IActionResult> OnPost()
        {
            await new CreateProduct(_ctx).Do(Product);

            return RedirectToPage("Index");
        }
       
    }
}
