using System.Threading.Tasks;
using Pokedex.Domain;
using Pokedex.Domain.Contracts;

namespace Pokedex.BLL.Contracts
{
    public interface IPokemonRemoveService
    {
        Task<Pokemon> RemoveAsync(IPokemonIdentity pokemonId);
    }
}