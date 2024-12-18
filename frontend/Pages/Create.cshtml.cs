using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace Frontend.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public AnelModel Anel { get; set; } = new AnelModel();
        private readonly IHttpClientFactory _clientFactory;

        public CreateModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _clientFactory.CreateClient();
client.BaseAddress = new Uri("http://backend:8080");

            var response = await client.PostAsJsonAsync("api/Aneis", Anel);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, error);
                return Page();
            }
        }
    }
}
