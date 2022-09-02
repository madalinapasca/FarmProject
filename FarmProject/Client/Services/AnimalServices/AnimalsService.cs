using FarmProject.Client.Pages;
using FarmProject.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FarmProject.Client.Services.AnimalServices
{
	public class AnimalsService : IAnimalService
	{
		private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<Quadruped> Quadrupeds { get ; set ; } = new List<Quadruped>();
		public List<Fowl> Fowls { get; set; } = new List<Fowl>();

        public double? QuadrupedsCorn { get; set; }

        public double? QuadrupedsHey { get; set; }

        public double? FowlsCorn { get; set; }

        public AnimalsService(HttpClient http, NavigationManager navigationManager)
		{
			_http=http;
            _navigationManager = navigationManager;
        }
    

		public async Task LoadFowls()
		{
			Fowls = await _http.GetFromJsonAsync<List<Fowl>>("api/Fowls");
		}

        

		public async Task LoadQuadrupeds()
		{
			Quadrupeds = await _http.GetFromJsonAsync<List<Quadruped>>("api/Animal");
        }

        private async Task SetQuadruped(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Quadruped>>();
            Quadrupeds = response;
            //_navigationManager.NavigateTo("addanimals");
        }

        private async Task SetFowl(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Fowl>>();
            Fowls = response;
           // _navigationManager.NavigateTo("addanimals");
        }

        public async Task<Quadruped> GetSpecificQuadruped(int id)
        {
            var result = await _http.GetFromJsonAsync<Quadruped>($"api/Animal/{id}");
            if (result != null)
                return result;
            throw new Exception("Animal not found!");



        }

        public async Task UpdateQuadruped(Quadruped animal)
        {
            var result = await _http.PutAsJsonAsync($"api/Animal/{animal.Id}", animal);
            await SetQuadruped(result);
        }

        public async Task DecreaseQuadrupedsNumber(Quadruped animal)
        {
            var result = await _http.PutAsJsonAsync($"api/Animal/decreasequadrupeds/{animal.Id}", animal);
            await SetQuadruped(result);
        }

        public async Task<Fowl> GetSpecificFowl(int id)
        {
            var result = await _http.GetFromJsonAsync<Fowl>($"api/Fowls/{id}");
            if (result != null)
                return result;
            throw new Exception("Animal not found!");
        }

        public async Task UpdateFowl(Fowl animal)
        {
            var result = await _http.PutAsJsonAsync($"api/Fowls/{animal.Id}", animal);
            await SetFowl(result);
        }

        public async Task DecreaseFowlsNumber(Fowl animal)
        {
            var result = await _http.PutAsJsonAsync($"api/Fowls/decreasefowls/{animal.Id}", animal);
            await SetFowl(result);
        }

        public async Task<double?> QuadrupedsCornNeeds()
        {
            var result = await _http.GetFromJsonAsync<double?>($"api/Animal/cornquantity");
            if (result == null)
                return null;
            else
                QuadrupedsCorn = result;
            return QuadrupedsCorn;
        }

        public async Task<double?> QuadrupedsHeyNeeds()
        {
            var result = await _http.GetFromJsonAsync<double?>($"api/Animal/heyquantity");
            if (result == null)
                return null;
            else
                QuadrupedsHey = result;
            return QuadrupedsHey;
        }

        public async Task<double?> FowlsCornNeeds()
        {
            var result = await _http.GetFromJsonAsync<double?>($"api/Fowls/cornquantity");
            if (result == null)
                return null;
            else
                FowlsCorn = result;
            return FowlsCorn;
        }
    }
}
