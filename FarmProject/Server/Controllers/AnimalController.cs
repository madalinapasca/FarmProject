using FarmProject.Server.Data;
using FarmProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly DataContext _context;

        public AnimalController(DataContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public async Task<List<Quadruped>> GetQuadrupeds()
        {

            return await _context.Quadrupeds.ToListAsync();


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Quadruped>>> GetSpecificQuadruped(int id)
        {
            var animal = await _context.Quadrupeds.FirstOrDefaultAsync(h => h.Id == id);

            if (animal == null)
            {
                return NotFound("Animalul cautat nu exista. :/");
            }

            return Ok(animal);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<List<Quadruped>>> UpdateQuadruped(Quadruped animal, int id)
        {
            var dbAnimal = await _context.Quadrupeds.FirstOrDefaultAsync(h => h.Id == id);

            if (dbAnimal == null)
            {
                return NotFound("Hrana solicitata nu este disponibila. :/");
            }

            dbAnimal.Name = animal.Name;
            dbAnimal.Quantity += animal.Quantity;
            dbAnimal.Corn = animal.Corn;
            dbAnimal.Hey = animal.Hey;
            dbAnimal.Id = animal.Id;

            await _context.SaveChangesAsync();

            return Ok(await GetDbQuadrupeds());
        }

        [HttpPut("decrease/{id}")]

        public async Task<ActionResult<List<Quadruped>>> DecreaseQuadrupedsNumber(Quadruped animal, int id)
        {
            var dbAnimal = await _context.Quadrupeds.FirstOrDefaultAsync(h => h.Id == id);

            if (dbAnimal == null)
            {
                return NotFound("Hrana solicitata nu este disponibila. :/");
            }

            dbAnimal.Name = animal.Name;
            dbAnimal.Quantity -= animal.Quantity;
            dbAnimal.Corn = animal.Corn;
            dbAnimal.Hey = animal.Hey;
            dbAnimal.Id = animal.Id;

            await _context.SaveChangesAsync();

            return Ok(await GetDbQuadrupeds());
        }



        private async Task<List<Quadruped>> GetDbQuadrupeds()
        {
            return await _context.Quadrupeds.ToListAsync();
        }



    }
}
