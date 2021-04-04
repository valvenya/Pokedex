using System.Collections.Generic;
using System.Threading.Tasks;
using Pokedex.Domain;
using Pokedex.Domain.Contracts;
using Pokedex.Domain.Models;

namespace Pokedex.DataAccess.Contracts
{
    public interface IPokemonDataAccess
    {
        Task<Pokemon> GetAsync(IPokemonIdentity pokemonId);
        Task<IEnumerable<Pokemon>> GetAsync();
        Task<Pokemon> InsertAsync(PokemonUpdateModel pokemon);
        Task<Pokemon> UpdateAsync(PokemonUpdateModel pokemon);
        Task<Pokemon> RemoveAsync(IPokemonIdentity pokemonId);
    }
}