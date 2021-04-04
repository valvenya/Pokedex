using System;
using System.Collections.Generic;
using Pokedex.Domain.Contracts;

namespace Pokedex.Domain.Models
{
    public class SpeciesUpdateModel : ISpeciesIdentity, IMovesContainer
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Type PrimaryType { get; set; }
        
        public Type SecondaryType { get; set; }
        
        public float Weight { get; set; }
        
        public float Height { get; set; }
        
        public IList<int> BaseStats { get; set; }
        
        public ICollection<int> MoveIds { get; set; } 
        
        public void Validate()
        {
            if (MoveIds.Count < 1)
            {
                throw new ArgumentException("There must be at least 1 move");
            }

            if (BaseStats.Count != 6)
            {
                throw new ArgumentException("There must be EV and IV for each stat (6)");
            }
        }
    }
}