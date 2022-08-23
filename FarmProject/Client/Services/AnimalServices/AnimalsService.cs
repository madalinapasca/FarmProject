using FarmProject.Shared;
using System.Net.Http.Json;

namespace FarmProject.Client.Services.AnimalServices
{
	public class AnimalsService : IAnimalService
	{
		private readonly HttpClient _http;
		public List<Quadruped> Quadrupeds { get ; set ; } = new List<Quadruped>();
		public List<Fowl> Fowls { get; set; } = new List<Fowl>();

		public AnimalsService(HttpClient http)
		{
			_http=http;
		}

		public async Task LoadFowls()
		{
			Fowls = await _http.GetFromJsonAsync<List<Fowl>>("api/Fowls");
		}

        

		public async Task LoadQuadrupeds()
		{
			Quadrupeds = await _http.GetFromJsonAsync<List<Quadruped>>("api/Animal");
        }

        
	}
}
