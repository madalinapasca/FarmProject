using FarmProject.Server.Data;

using FarmProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            return Ok(await GetDbQFowls());
        }

        private async Task<List<Fowl>> GetDbQFowls()
        {
            return await _context.Fowls.ToListAsync();
        }


    }
}
