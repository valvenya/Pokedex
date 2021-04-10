using System.Collections.Generic;
using Pokedex.Domain;

namespace Pokedex.DataAccess.Entities
{
    public class Pokemon
    {
        public Pokemon()
        {
            Moves = new HashSet<Move>();
        }

        public int Id { get; set; }

        public string Nickname { get; set; }
        public int SpeciesId { get; set; }
        public int Level { get; set; }
        public Nature Nature { get; set; }
        public int[] IV { get; set; }
        public int[] EV { get; set; }

        public virtual Species Species { get; set; }
        public virtual ICollection<Move> Moves { get; set; }

    }
}