using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pokedex.Domain;

namespace Pokedex.Client.Requests.Create
{
    public class PokemonCreateDTO
    {
        public string Nickname { get; set; }
        
        [Required]
        public int SpeciesId { get; set; }
        
        [Required]
        public int Level { get; set; }
        
        [Required]
        public string Nature { get; set; }
        
        [Required, MinLength(1), MaxLength(4)]
        public ICollection<int> MoveIds { get; set; }
        
        [Required, MinLength(6), MaxLength(6)]
        public List<int> IV { get; set; }
        
        [Required, MinLength(6), MaxLength(6)]
        public List<int> EV { get; set; }
    }
}