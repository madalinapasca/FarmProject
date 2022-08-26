using FarmProject.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FarmProject.Client.Services.FoodServices
{
    public class FoodService : IFoodService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<Barn> Barn { get; set; } = new List<Barn>();
        public FoodService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public async Task LoadFood()
        {
            Barn = await _http.GetFromJsonAsync<List<Barn>>("api/Barn");
        }

        private async Task SetFood(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Barn>>();
            Barn = response;
            _navigationManager.NavigateTo("addfood");
        }

        public async Task<Barn> GetSpecificFood(int id)
        {
            var result = await _http.GetFromJsonAsync<Barn>($"api/Barn/{id}");
            if (result != null)
                return result;
            throw new Exception("Food not found!");

            
            
        }

        public async Task UpdateFood(Barn food)
        {
            var result = await _http.PutAsJsonAsync($"api/Barn/{food.Id}", food);
            await SetFood(result);
        }

       
    }
}
