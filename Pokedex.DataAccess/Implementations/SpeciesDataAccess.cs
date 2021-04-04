using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pokedex.DataAccess.Context;
using Pokedex.DataAccess.Contracts;
using Pokedex.Domain;
using Pokedex.Domain.Contracts;
using Pokedex.Domain.Models;

namespace Pokedex.DataAccess.Implementations
{
    public class SpeciesDataAccess : ISpeciesDataAccess
    {
        private PokedexContext Context { get; }
        private IMapper Mapper { get; }
        
        public SpeciesDataAccess(PokedexContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        public async Task<Species> GetAsync(ISpeciesIdentity speciesId)
        {
            return Mapper.Map<Species>(await Get(speciesId));
        }

        private async Task<Entities.Species> Get(ISpeciesIdentity speciesId)
        {
            if (speciesId == null)
            {
                throw new ArgumentNullException(nameof(speciesId));
            }

            return await Context.Species
                .Include(s => s.MovePool)
                .FirstOrDefaultAsync(s => s.Id == speciesId.Id);
        }

        public async Task<IEnumerable<Species>> GetAsync()
        {
            return Mapper.Map<IEnumerable<Species>>(await Context.Species
                .Include(s => s.MovePool)
                .ToListAsync());
        }

        public async Task<Species> InsertAsync(SpeciesUpdateModel species)
        {
            var speciesEntity = Mapper.Map<Entities.Species>(species);
            Context.AttachRange(speciesEntity.MovePool);
            
            var result = await Context.AddAsync(speciesEntity);
            await Context.SaveChangesAsync();

            return Mapper.Map<Species>(result);
        }

        public async Task<Species> UpdateAsync(SpeciesUpdateModel species)
        {
            var existing = await Get(species);

            var result = Mapper.Map(species, existing);
            Context.AttachRange(result.MovePool);
            Context.Update(result);

            await Context.SaveChangesAsync();

            return Mapper.Map<Species>(result);
        }

        public async Task<bool> ValidateAsync(ISpeciesContainer speciesContainer)
        {
            return await Context.Species.AnyAsync(species => species.Id == speciesContainer.SpeciesId);
        }

        public async Task<Species> GetByAsync(ISpeciesContainer speciesContainer)
        {
            return Mapper.Map<Species>(
                await Context.Species
                    .Include(s => s.MovePool)
                    .FirstOrDefaultAsync(species => species.Id == speciesContainer.SpeciesId));
        }
    }
}