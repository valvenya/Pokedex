using System.Collections.Generic;

namespace Pokedex.Domain.Contracts
{
    public interface IMovesContainer
    {
        public ICollection<int> MoveIds { get; }
    }
}