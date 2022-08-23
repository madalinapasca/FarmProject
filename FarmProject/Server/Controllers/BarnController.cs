using FarmProject.Server.Services.Food;
using FarmProject.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarnController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public BarnController(IFoodService foodService)
        {
            _foodService = foodService;

        }

        [HttpGet]
        public async Task<ActionResult<List<Barn>>> GetFoodFromBarn()
        {
            return Ok(await _foodService.GetFoodFromBarn());
        }
    }
}
