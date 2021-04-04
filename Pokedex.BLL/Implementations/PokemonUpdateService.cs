using System.Threading.Tasks;
using Pokedex.BLL.Contracts;
using Pokedex.DataAccess.Contracts;
using Pokedex.Domain;
using Pokedex.Domain.Models;

namespace Pokedex.BLL.Implementations
{
    public class PokemonUpdateService : IPokemonUpdateService
    {
        private IPokemonDataAccess PokemonDataAccess { get; }
        private ISpeciesGetService SpeciesGetService { get; }

        public PokemonUpdateService(IPokemonDataAccess pokemonDataAccess, ISpeciesGetService speciesGetService)
        {
            PokemonDataAccess = pokemonDataAccess;
            SpeciesGetService = speciesGetService;
        }
        
        public async Task<Pokemon> UpdateAsync(PokemonUpdateModel pokemon)
        {
            pokemon.Validate();
            
            await SpeciesGetService.ValidateMoveAsync(pokemon);
            
            return await PokemonDataAccess.UpdateAsync(pokemon);
        }
    }
}