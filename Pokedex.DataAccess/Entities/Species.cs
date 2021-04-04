using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pokedex.Domain;

namespace Pokedex.DataAccess.Entities
{
    public class Species
    {
        public Species()
        {
            MovePool = new HashSet<Move>();
            Pokemon = new HashSet<Pokemon>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public Type PrimaryType { get; set; }
        public Type? SecondaryType { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public IList<int> BaseStats { get; set; }
        
        public virtual ICollection<Move> MovePool { get; set; }
        public virtual ICollection<Pokemon> Pokemon { get; set; }
    }
}