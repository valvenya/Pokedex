using System.Collections.Generic;
using System.Threading.Tasks;
using Pokedex.Domain;
using Pokedex.Domain.Contracts;

namespace Pokedex.BLL.Contracts
{
    public interface ISpeciesGetService
    {
        Task<Species> GetAsync(ISpeciesIdentity speciesId);
        Task<IEnumerable<Species>> GetAsync();
        Task ValidateAsync(ISpeciesContainer speciesContainer);
        Task ValidateMoveAsync(IMovesAndSpeciesContainer movesAndSpeciesContainer);
    }
}