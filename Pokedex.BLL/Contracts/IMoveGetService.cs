using System.Collections.Generic;
using System.Threading.Tasks;
using Pokedex.Domain;
using Pokedex.Domain.Contracts;

namespace Pokedex.BLL.Contracts
{
    public interface IMoveGetService
    {
        Task<Move> GetAsync(IMoveIdentity moveId);
        Task<IEnumerable<Move>> GetAsync();
        Task ValidateAsync(IMovesContainer movesContainer);
    }
}