using System.Collections.Generic;
using Pokedex.Domain;

namespace Pokedex.Client.DTO.Read
{
    public class SpeciesDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string PrimaryType { get; set; }
        
        public string SecondaryType { get; set; }
        
        public float Weight { get; set; }
        
        public float Height { get; set; }
        
        public IList<int> BaseStats { get; set; }
        
        public IEnumerable<MoveDTO> MovePool { get; set; }
    }
}