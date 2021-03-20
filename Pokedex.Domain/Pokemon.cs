using System.Collections.Generic;
using System.Data;
using System.Transactions;
using Pokedex.Domain.Contracts;

namespace Pokedex.Domain
{
    public class Pokemon : ISpeciesContainer, IStatsContainer
    {
        
        public int Id { get; set; }
        
        public string Nickname { get; set; }
        
        public Species Species { get; set; }
        
        public int Level { get; set; }
        
        public Nature Nature { get; set; }      
        
        public ICollection<Move> Moves { get; }
        
        public List<int> IV { get; set; }
        
        public List<int> EV { get; set; }
        
        int? ISpeciesContainer.SpeciesId => this.Species.Id;
        
        List<int> IStatsContainer.BaseStats => this.Species.BaseStats;
    }
}