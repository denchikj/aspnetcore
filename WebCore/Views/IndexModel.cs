using Microsoft.AspNetCore.Mvc.RazorPages;
using WebCore.Services;

namespace WebCore.Views
{
    public class IndexModel : PageModel
    {
        private readonly MyDependency _dependency = new MyDependency();

        public void OnGet()
        {
            _dependency.WriteMessage("IndexModel.OnGet");
        }
    }
}
