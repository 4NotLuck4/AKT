using DbLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApiServices;

namespace WebApp.Pages
{
    public class IndexModel(ReviewsApiService service) : PageModel
    {
        private readonly ReviewsApiService _service = service;

        public IEnumerable<Review> Reviews { get; set; }

        public async Task OnGetAsync()
        {

        }
    }
}
