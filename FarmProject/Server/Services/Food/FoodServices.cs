using FarmProject.Shared;

namespace FarmProject.Server.Services.Food
{
    public class FoodServices : IFoodService
    {
        public List<Barn> Barn { get; set; }=new List<Barn> {
            new Barn{Id=1, Name="porumb", Quantity=4},
            new Barn{Id=2, Name="fan", Quantity=6}
         };
        public async Task<List<Barn>> GetFoodFromBarn()
        {
            return Barn;
        }
    }
}
