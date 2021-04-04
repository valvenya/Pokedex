using System;
using System.Threading.Tasks;
using Pokedex.BLL.Contracts;
using Pokedex.DataAccess.Contracts;
using Pokedex.Domain;
using Pokedex.Domain.Models;

namespace Pokedex.BLL.Implementations
{
    public class PokemonCreateService : IPokemonCreateService
    {
        private IPokemonDataAccess PokemonDataAccess { get; }
        private ISpeciesGetService SpeciesGetService { get; }

        public PokemonCreateService(IPokemonDataAccess pokemonDataAccess, ISpeciesGetService speciesGetService)
        {
            PokemonDataAccess = pokemonDataAccess;
            SpeciesGetService = speciesGetService;
        }
        
        public async Task<Pokemon> InsertAsync(PokemonUpdateModel pokemon)
        {
            pokemon.Validate();
            
            await SpeciesGetService.ValidateMoveAsync(pokemon);

            return await PokemonDataAccess.InsertAsync(pokemon);
        }
        
    }
}