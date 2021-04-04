using System.Collections.Generic;
using System.Threading.Tasks;
using Pokedex.BLL.Contracts;
using Pokedex.DataAccess.Contracts;
using Pokedex.Domain;
using Pokedex.Domain.Contracts;

namespace Pokedex.BLL.Implementations
{
    public class PokemonGetService : IPokemonGetService
    {
        private IPokemonDataAccess PokemonDataAccess { get; }

        public PokemonGetService(IPokemonDataAccess pokemonDataAccess)
        {
            PokemonDataAccess = pokemonDataAccess;
        }

        public async Task<Pokemon> GetAsync(IPokemonIdentity pokemonId)
        {
            return await PokemonDataAccess.GetAsync(pokemonId);
        }

        public async Task<IEnumerable<Pokemon>> GetAsync()
        {
            return await PokemonDataAccess.GetAsync();
        }
    }
}