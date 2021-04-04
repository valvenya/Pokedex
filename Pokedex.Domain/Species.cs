using System.Collections.Generic;
using System.Linq;
using Pokedex.Domain.Contracts;

namespace Pokedex.Domain
{
    public class Species : IMovesContainer
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Type PrimaryType { get; set; }
        
        public Type SecondaryType { get; set; }
        
        public float Weight { get; set; }
        
        public float Height { get; set; }
        
        public IList<int> BaseStats { get; set; }
        
        public IEnumerable<Move> MovePool { get; set; }

        ICollection<int> IMovesContainer.MoveIds => MovePool.Select(x => x.Id).ToList();
    }
}