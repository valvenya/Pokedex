using System.Collections.Generic;

namespace Pokedex.Domain
{
    public class Species
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Type PrimaryType { get; set; }
        
        public Type SecondaryType { get; set; }
        
        public float Weight { get; set; }
        
        public float Height { get; set; }
        
        public List<int> BaseStats { get; set; }
        
        public ICollection<Move> MovePool { get; set; } 
        
    }
}