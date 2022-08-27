using FarmProject.Shared;
using System.Threading.Tasks;

namespace FarmProject.Client.Services.AnimalServices
{
	public interface IAnimalService
	{
		List<Quadruped> Quadrupeds { get; set; }

		List<Fowl> Fowls	{ get; set; }

		Task LoadQuadrupeds();
		Task LoadFowls();

        Task<Quadruped> GetSpecificQuadruped(int id);

        Task<Fowl> GetSpecificFowl(int id);

        Task UpdateQuadruped(Quadruped animal);
        Task UpdateFowl(Fowl animal);

        
        Task DecreaseQuadrupedsNumber (Quadruped animal);

       

    }
}
