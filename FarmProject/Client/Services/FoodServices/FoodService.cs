using FarmProject.Shared;
using System.Net.Http.Json;

namespace FarmProject.Client.Services.FoodServices
{
    public class FoodService : IFoodService
    {
        private readonly HttpClient _http;

        public List<Barn> Barn { get; set; } = new List<Barn>();
        public FoodService(HttpClient http)
        {
           _http = http;
        }
        public async Task LoadFood()
        {
            Barn = await _http.GetFromJsonAsync<List<Barn>>("api/Barn");
        }
    }
}
