using System.Collections.Generic;
using Pokedex.Domain.Contracts;

namespace Pokedex.Domain.Models
{
    public class PokemonUpdateModel : IPokemonIdentity, ISpeciesContainer
    {
        public int Id { get; set; }
        
        public string Nickname { get; set; }
        
        public int? SpeciesId { get; set; }
        
        public int Level { get; set; }
        
        public Nature Nature { get; set; }
        
        public ICollection<Move> Moves { get; set; }
        
        public List<int> IV { get; set; }
        
        public List<int> EV { get; set; }
    }
}