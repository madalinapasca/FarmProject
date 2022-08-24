using FarmProject.Server.Data;
using FarmProject.Shared;
using Microsoft.EntityFrameworkCore;

namespace FarmProject.Server.Services.Food
{
    public class FoodServices : IFoodService
    {
        private readonly DataContext _context;

        public FoodServices(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Barn>> GetFoodFromBarn()
        {
            return await _context.Barn.ToListAsync();
        }
    }
}
