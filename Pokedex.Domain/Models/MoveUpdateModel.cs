using Pokedex.Domain.Contracts;

namespace Pokedex.Domain.Models
{
    public class MoveUpdateModel : IMoveIdentity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Type Type { get; set; }
        
        public int Power { get; set; }
        
        public int Accuracy { get; set; }
        
        public string Description { get; set; }
    }
}