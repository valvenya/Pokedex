using System.Threading.Tasks;
using Pokedex.Domain;
using Pokedex.Domain.Models;

namespace Pokedex.BLL.Contracts
{
    public interface IMoveUpdateService
    {
        Task<Move> UpdateAsync(MoveUpdateModel move);
    }
}