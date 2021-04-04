using System.Collections.Generic;
using System.Threading.Tasks;
using Pokedex.Domain;
using Pokedex.Domain.Contracts;
using Pokedex.Domain.Models;

namespace Pokedex.DataAccess.Contracts
{
    public interface IMoveDataAccess
    {
        Task<Move> GetAsync(IMoveIdentity moveId);
        Task<IEnumerable<Move>> GetAsync();
        Task<Move> InsertAsync(MoveUpdateModel move);
        Task<Move> UpdateAsync(MoveUpdateModel move);
    }
}