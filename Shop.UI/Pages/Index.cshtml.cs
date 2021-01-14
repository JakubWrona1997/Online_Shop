using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Database;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Shop.Application.Products;

namespace Shop.UI.Pages
{
    public class IndexModel : PageModel
    {
        
        private AppDBContext _ctx;

        public IndexModel(AppDBContext context)
        {
            _ctx = context;
        }
   
        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }
        public void OnGet()
        {
            Products = new GetProducts(_ctx).Do();
        }
       
    }
}
