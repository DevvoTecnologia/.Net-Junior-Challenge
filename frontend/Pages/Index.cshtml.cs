using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using Frontend.Models;

namespace Frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public List<AnelModel> Aneis { get; set; } = new List<AnelModel>();

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGet()
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("http://backend:8080"); // Corrigida para porta correta
            Aneis = await client.GetFromJsonAsync<List<AnelModel>>("api/Aneis");
        }
    }
}
