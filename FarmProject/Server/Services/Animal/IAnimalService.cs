using FarmProject.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FarmProject.Server.Services.Animal
{
    public interface IAnimalService
    {
         Task<List<Quadruped>> GetQuadrupeds();

         Task<List<Fowl>> GetFowls();
    }
}
