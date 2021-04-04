using System.Threading.Tasks;
using Pokedex.BLL.Contracts;
using Pokedex.DataAccess.Contracts;
using Pokedex.Domain;
using Pokedex.Domain.Contracts;

namespace Pokedex.BLL.Implementations
{
    public class PokemonRemoveService : IPokemonRemoveService
    {
        private IPokemonDataAccess PokemonDataAccess { get; }

        public PokemonRemoveService(IPokemonDataAccess pokemonDataAccess)
        {
            PokemonDataAccess = pokemonDataAccess;
        }
        
        public async Task<Pokemon> RemoveAsync(IPokemonIdentity pokemonId)
        {
            return await PokemonDataAccess.RemoveAsync(pokemonId);
        }
    }
}