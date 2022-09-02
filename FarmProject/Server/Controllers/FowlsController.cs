using FarmProject.Server.Data;

using FarmProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FarmProject.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FowlsController : ControllerBase
	{

        private readonly DataContext _context;

        public FowlsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Fowl>> GetFowls()
        {

            return await _context.Fowls.ToListAsync();


        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Fowl>>> GetSpecificFowl(int id)
        {
            var animal = await _context.Fowls.FirstOrDefaultAsync(h => h.Id == id);

            if (animal == null)
            {
                return NotFound("Animalul cautat nu exista. :/");
            }

            return Ok(animal);
        }

        [HttpGet("cornquantity")]
        public async Task<double?> FowlsCornNeeds()
        {
            double? sum = 0;
            var animals = await _context.Fowls.ToListAsync();
            foreach (Fowl q in animals)
            {
                if (q.Quantity != null & q.Corn != null)
                    sum += (q.Corn * q.Quantity);
                else
                    sum += 0;
            }
            return sum;
        }

        

        [HttpPut("{id}")]

        public async Task<ActionResult<List<Fowl>>> UpdateFowl(Fowl animal, int id)
        {
            var dbAnimal = await _context.Fowls.FirstOrDefaultAsync(h => h.Id == id);

            if (dbAnimal == null)
            {
                return NotFound("Animalul solicitat nu este disponibil. :/");
            }

            dbAnimal.Name = animal.Name;
            dbAnimal.Quantity += animal.Quantity;
            dbAnimal.Corn = animal.Corn;
            dbAnimal.Hey = animal.Hey;
            dbAnimal.Id = animal.Id;

            await _context.SaveChangesAsync();

            return Ok(await GetDbFowls());
        }

        [HttpPut("decreasefowls/{id}")] 

        public async Task<ActionResult<List<Fowl>>> DecreaseFowlsNumber(Fowl animal, int id)
        {
            var dbAnimal = await _context.Fowls.FirstOrDefaultAsync(h => h.Id == id);

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

            return Ok(await GetDbFowls());
        }


        private async Task<List<Fowl>> GetDbFowls()
        {
            return await _context.Fowls.ToListAsync();
        }


    }
}
