using System;
using System.Collections.Generic;
using Pokedex.Domain.Contracts;

namespace Pokedex.Domain.Models
{
    public class PokemonUpdateModel : IPokemonIdentity, IMovesAndSpeciesContainer
    {
        public int Id { get; set; }
        
        public string Nickname { get; set; }
        
        public int SpeciesId { get; set; }
        
        public int Level { get; set; }
        
        public Nature Nature { get; set; }

        public ICollection<int> MoveIds { get; set; }

        public List<int> IV { get; set; }
        
        public List<int> EV { get; set; }
        
        public void Validate()
        {
            if (MoveIds.Count < 1 || MoveIds.Count > 4)
            {
                throw new ArgumentException("There must be 1-4 moves");
            }

            if (IV.Count != 6 || EV.Count != 6)
            {
                throw new ArgumentException("There must be EV and IV for each stat (6)");
            }
        }
    }
}