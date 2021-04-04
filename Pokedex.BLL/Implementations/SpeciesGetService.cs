using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokedex.BLL.Contracts;
using Pokedex.DataAccess.Contracts;
using Pokedex.Domain;
using Pokedex.Domain.Contracts;
using Pokedex.Domain.Models;

namespace Pokedex.BLL.Implementations
{
    public class SpeciesGetService : ISpeciesGetService
    {
        private ISpeciesDataAccess SpeciesDataAccess { get; }

        public SpeciesGetService(ISpeciesDataAccess speciesDataAccess)
        {
            SpeciesDataAccess = speciesDataAccess;
        }

        public async Task<Species> GetAsync(ISpeciesIdentity speciesId)
        {
            return await SpeciesDataAccess.GetAsync(speciesId);
        }

        public async Task<IEnumerable<Species>> GetAsync()
        {
            return await SpeciesDataAccess.GetAsync();
        }

        public async Task ValidateAsync(ISpeciesContainer speciesContainer)
        {
            if (speciesContainer == null)
            {
                throw new ArgumentNullException(nameof(speciesContainer));
            }
            

            if (!await SpeciesDataAccess.ValidateAsync(speciesContainer))
            {
                throw new InvalidOperationException($"Species with id {speciesContainer.SpeciesId} not found");
            }
        }

        public async Task ValidateMoveAsync(IMovesAndSpeciesContainer movesAndSpeciesContainer)
        {
            if (movesAndSpeciesContainer == null)
            {
                throw new ArgumentNullException(nameof(movesAndSpeciesContainer));
            }

            var species = await SpeciesDataAccess.GetByAsync(movesAndSpeciesContainer);

            if (species == null)
            {
                throw new InvalidOperationException($"Species with id {movesAndSpeciesContainer.SpeciesId} not found");
            }

            foreach (var id in movesAndSpeciesContainer.MoveIds)
            {
                if (species.MovePool.All(move => move.Id != id))
                {
                    throw new InvalidOperationException($"Illegal move with id {id}");
                }
            }
        }
    }
}