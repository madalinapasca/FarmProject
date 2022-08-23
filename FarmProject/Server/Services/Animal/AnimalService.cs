using FarmProject.Shared;

namespace FarmProject.Server.Services.Animal
{
    public class AnimalService : IAnimalService
    {
        public List<Fowl> Fowls { get; set; } = new List<Fowl>
            {
                new Fowl {Id = 1, Name = "gaini", Quantity = 10, Corn = 2, Hey= null},
                new Fowl {Id = 2, Name = "gaste", Quantity = 0, Corn=null, Hey=null},
                new Fowl {Id = 3, Name = "rate", Quantity = 3, Corn = 1, Hey=null},
                new Fowl {Id = 4, Name = "curci", Quantity = 0, Corn=null, Hey=null}

            };
        public List<Quadruped> Quadrupeds { get; set; } = new List<Quadruped> {
                new Quadruped {  Id = 1, Name = "porci", Quantity = 5, Corn = 2, Hey = 0, },
                new Quadruped {  Id = 2, Name = "oi", Quantity = 0,  Corn=null, Hey=null },
                new Quadruped {  Id = 3, Name = "bovine", Quantity = 3, Corn= null, Hey = 0.5 },
                new Quadruped {  Id = 4, Name = "cai", Quantity = 0, Corn= null, Hey=null }
            };
        public async Task<List<Fowl>> GetFowls()
        {
            return Fowls;
        }

        public async Task<List<Quadruped>> GetQuadrupeds()
        {
            return Quadrupeds;
        }
    }
}
