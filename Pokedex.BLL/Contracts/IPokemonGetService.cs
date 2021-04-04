using System.Collections.Generic;
using System.Threading.Tasks;
using Pokedex.Domain;
using Pokedex.Domain.Contracts;

namespace Pokedex.BLL.Contracts
{
    public interface IPokemonGetService
    {
        Task<Pokemon> GetAsync(IPokemonIdentity pokemonId);
        Task<IEnumerable<Pokemon>> GetAsync();
    }
}