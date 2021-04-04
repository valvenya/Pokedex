using System.Collections.Generic;
using System.Threading.Tasks;
using Pokedex.Domain;
using Pokedex.Domain.Contracts;
using Pokedex.Domain.Models;

namespace Pokedex.DataAccess.Contracts
{
    public interface ISpeciesDataAccess
    {
        Task<Species> GetAsync(ISpeciesIdentity speciesId);
        Task<IEnumerable<Species>> GetAsync();
        Task<Species> InsertAsync(SpeciesUpdateModel species);
        Task<Species> UpdateAsync(SpeciesUpdateModel species);
        Task<bool> ValidateAsync(ISpeciesContainer speciesContainer);
        Task<Species> GetByAsync(ISpeciesContainer speciesContainer);
    }
}