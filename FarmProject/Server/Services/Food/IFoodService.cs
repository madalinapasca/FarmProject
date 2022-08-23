using FarmProject.Shared;

namespace FarmProject.Server.Services.Food
{
    public interface IFoodService
    {
        Task<List<Barn>> GetFoodFromBarn();
    }
}
