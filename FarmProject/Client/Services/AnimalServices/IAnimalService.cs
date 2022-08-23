using FarmProject.Shared;

namespace FarmProject.Client.Services.AnimalServices
{
	public interface IAnimalService
	{
		List<Quadruped> Quadrupeds { get; set; }

		List<Fowl> Fowls	{ get; set; }

		Task LoadQuadrupeds();
		Task LoadFowls();
	}
}
