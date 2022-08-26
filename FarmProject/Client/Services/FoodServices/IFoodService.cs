using FarmProject.Shared;

namespace FarmProject.Client.Services.FoodServices
{
    public interface IFoodService
    {
        List<Barn> Barn { get; set; }

        Task LoadFood();

        Task<Barn> GetSpecificFood(int id);

        Task UpdateFood(Barn food);
    }
}
