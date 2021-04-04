using System.Threading.Tasks;
using Pokedex.Domain;
using Pokedex.Domain.Models;

namespace Pokedex.BLL.Contracts
{
    public interface IMoveCreateService
    {
        Task<Move> InsertAsync(MoveUpdateModel move);
    }
}