using System.Threading.Tasks;
using Pokedex.BLL.Contracts;
using Pokedex.DataAccess.Contracts;
using Pokedex.Domain;
using Pokedex.Domain.Models;

namespace Pokedex.BLL.Implementations
{
    public class SpeciesUpdateService
    {
        private ISpeciesDataAccess SpeciesDataAccess { get; }
        private IMoveGetService MoveGetService { get;  }

        public SpeciesUpdateService(ISpeciesDataAccess speciesDataAccess, IMoveGetService moveGetService)
        {
            SpeciesDataAccess = speciesDataAccess;
            MoveGetService = moveGetService;
        }
        
        public async Task<Species> UpdateAsync(SpeciesUpdateModel species)
        {
            species.Validate();

            await MoveGetService.ValidateAsync(species);
            
            return await SpeciesDataAccess.UpdateAsync(species);
        }
    }
}