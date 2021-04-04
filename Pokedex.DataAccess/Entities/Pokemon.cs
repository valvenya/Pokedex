using System.Collections.Generic;
using Pokedex.Domain;

namespace Pokedex.DataAccess.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
        
        public string Nickname { get; set; }
        public int SpeciesId { get; set; }
        public int Level { get; set; }
        public Nature Nature { get; set; }
        public int Move1Id { get; set; }
        public int? Move2Id { get; set; }
        public int? Move3Id { get; set; }
        public int? Move4Id { get; set; }
        public IList<int> IV { get; set; }
        public IList<int> EV { get; set; }
        
        public virtual Species Species { get; set; }
        public virtual Move Move1 { get; set; }
        public virtual Move Move2 { get; set; }
        public virtual Move Move3 { get; set; }
        public virtual Move Move4 { get; set; }
    }
}