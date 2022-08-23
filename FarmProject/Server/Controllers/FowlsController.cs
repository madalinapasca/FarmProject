using FarmProject.Server.Services.Animal;
using FarmProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmProject.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FowlsController : ControllerBase
	{

        private readonly IAnimalService _animalService;

        public FowlsController(IAnimalService animalService)
        {
                
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Fowl>>> GetFowls()
        {
            return Ok(await _animalService.GetFowls());
        }
    }
}
