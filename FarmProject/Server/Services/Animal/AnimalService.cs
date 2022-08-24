using FarmProject.Server.Data;
using FarmProject.Shared;
using Microsoft.EntityFrameworkCore;

namespace FarmProject.Server.Services.Animal
{
    public class AnimalService : IAnimalService
    {
        private readonly DataContext _context;

        public AnimalService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Fowl>> GetFowls()
        {
            return await _context.Fowls.ToListAsync();
        }

        public async Task<List<Quadruped>> GetQuadrupeds()
        {
            return await _context.Quadrupeds.ToListAsync();
        }
    }
}
