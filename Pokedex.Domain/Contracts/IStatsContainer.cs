using System.Collections.Generic;

namespace Pokedex.Domain.Contracts
{
    public interface IStatsContainer
    {
        protected List<int> BaseStats { get; }
        
        public List<int> IV { get; set; }
        
        public List<int> EV { get; set; }
        
        public int Level { get; set; }

        //stats formulas from Bulbapedia
        public int HP => (2 * BaseStats[0] + IV[0] + EV[0] / 4) * Level / 100 + Level + 10;
        public int Atk => (2 * BaseStats[1] + IV[1] + EV[1] / 4) * Level / 100 + 5;
        public int Def => (2 * BaseStats[2] + IV[2] + EV[2] / 4) * Level / 100 + 5;
        public int SpAtk => (2 * BaseStats[3] + IV[3] + EV[3] / 4) * Level / 100 + 5;
        public int SpDef => (2 * BaseStats[4] + IV[4] + EV[4] / 4) * Level / 100 + 5;
        public int Speed => (2 * BaseStats[5] + IV[5] + EV[5] / 4) * Level / 100 + 5;
    }
}