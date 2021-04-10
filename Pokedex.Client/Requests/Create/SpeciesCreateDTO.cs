using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pokedex.Domain;

namespace Pokedex.Client.Requests.Create
{
    public class SpeciesCreateDTO
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string PrimaryType { get; set; }
        
        public string SecondaryType { get; set; }
        
        [Required]
        public float Weight { get; set; }
        
        [Required]
        public float Height { get; set; }
        
        [Required, MinLength(6), MaxLength(6)]
        public IList<int> BaseStats { get; set; }
        
        [Required, MinLength(1)]
        public ICollection<int> MoveIds { get; set; }
    }
}