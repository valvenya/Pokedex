using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using Pokedex.Domain.Contracts;

namespace Pokedex.Domain
{
    public class Pokemon : ISpeciesContainer, IStatsContainer, IMovesContainer
    {
        
        public int Id { get; set; }
        
        public string Nickname { get; set; }
        
        public Species Species { get; set; }
        
        public int Level { get; set; }
        
        public Nature Nature { get; set; }      
        
        public ICollection<Move> Moves { get; set; }
        
        public IList<int> IV { get; set; }
        
        public IList<int> EV { get; set; }
        
        int ISpeciesContainer.SpeciesId => this.Species.Id;
        
        IList<int> IStatsContainer.BaseStats => this.Species.BaseStats;

        ICollection<int> IMovesContainer.MoveIds => Moves.Select(x => x.Id).ToList();
    }
}