using FarmProject.Server.Services.Animal;
using FarmProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        public AnimalController(IAnimalService animalService)
        {

            _animalService = animalService;
                
        }

        [HttpGet]
        public async Task<ActionResult<List<Quadruped>>> GetQuadrupeds()
        {

            return Ok(await _animalService.GetQuadrupeds());


        }


        
    }
}
