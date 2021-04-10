using System.Collections.Generic;
using Pokedex.Domain;

namespace Pokedex.Client.DTO.Read
{
    public class PokemonDTO
    {
        public int Id { get; set; }
        
        public string Nickname { get; set; }
        
        public SpeciesDTO Species { get; set; }
        
        public int Level { get; set; }
        
        public string Nature { get; set; }
        
        public ICollection<MoveDTO> Moves { get; set; }
        
        public IList<int> IV { get; set; }
        
        public IList<int> EV { get; set; }
    }
}