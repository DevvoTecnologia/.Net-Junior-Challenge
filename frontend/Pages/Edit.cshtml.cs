using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace Frontend.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public AnelModel Anel { get; set; }
        private readonly IHttpClientFactory _clientFactory;

        public EditModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var client = _clientFactory.CreateClient();
client.BaseAddress = new Uri("http://backend:8080"); 

            Anel = await client.GetFromJsonAsync<AnelModel>($"api/Aneis/{id}");
            if (Anel == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
           var client = _clientFactory.CreateClient();
client.BaseAddress = new Uri("http://backend:8080"); 


            var response = await client.PutAsJsonAsync($"api/Aneis/{Anel.Id}", Anel);
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
