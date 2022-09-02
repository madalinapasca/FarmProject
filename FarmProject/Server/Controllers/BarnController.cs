using FarmProject.Server.Data;

using FarmProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FarmProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarnController : ControllerBase
    {
        
        private readonly DataContext _context;
        
        public BarnController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Barn>>> GetFoodFromBarn()
        {
            var food = await _context.Barn.ToListAsync(); 
            return Ok(food);
        }

        [HttpGet("cornquantity")]
        public async Task<double?> GetCornQuantity()
        {
            var corn = await _context.Barn.FirstOrDefaultAsync(h => h.Name == "porumb");
            if (corn == null)
            {
                return null;
            }
            else
            {
                double? quantity = corn.Quantity;
                return quantity;
            }
           
        }

        [HttpGet("heyquantity")]
        public async Task<double?> GetHeyQuantity()
        {
            var hey = await _context.Barn.FirstOrDefaultAsync(h => h.Name == "fan");
            if (hey == null)
            {
                return null;
            }
            else
            {
                double? quantity = hey.Quantity;
                return quantity;
            }

        }



        [HttpGet("{id}")]
        public async Task<ActionResult<List<Barn>>> GetSpecificFood(int id)
        {
            var food = await _context.Barn.FirstOrDefaultAsync(h => h.Id == id);

            if (food == null)
            { 
                return NotFound("Hrana solicitata nu este disponibila. :/");
            }

            return Ok(food);
        }


        [HttpPut("{id}")]

        public async Task<ActionResult<List<Barn>>> UpdateFood(Barn food, int id)
        {
            var dbFood = await _context.Barn.FirstOrDefaultAsync(h => h.Id == id);

            if (dbFood == null)
            {
                return NotFound("Hrana solicitata nu este disponibila. :/");
            }

            dbFood.Name = food.Name;
            dbFood.Quantity += food.Quantity;
            dbFood.Id = food.Id;

            await _context.SaveChangesAsync();

            return Ok(await GetDbFoodFromBarn());
        }

        private async Task<List<Barn>> GetDbFoodFromBarn()
        {
            return await _context.Barn.ToListAsync();
        }
    }
}
