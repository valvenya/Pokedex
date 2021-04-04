using System.Collections.Generic;
using Pokedex.Domain;

namespace Pokedex.DataAccess.Entities
{
    public class Move
    {
        public Move()
        {
            Pokemon = new HashSet<Pokemon>();
            Species = new HashSet<Species>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public int Power { get; set; }
        public int? Accuracy { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<Pokemon> Pokemon { get; set; }
        public virtual ICollection<Species> Species { get; set; }
    }
}