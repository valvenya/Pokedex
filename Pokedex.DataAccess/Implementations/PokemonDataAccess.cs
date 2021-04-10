using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    public class PokemonDataAccess : IPokemonDataAccess
    {
        private PokedexContext Context { get; }
        private IMapper Mapper { get; }
        
        public PokemonDataAccess(PokedexContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        public async Task<Pokemon> GetAsync(IPokemonIdentity pokemonId)
        {
            return Mapper.Map<Pokemon>(await Get(pokemonId));
        }

        private async Task<Entities.Pokemon> Get(IPokemonIdentity pokemonId)
        {
            if (pokemonId == null)
            {
                throw new ArgumentNullException(nameof(pokemonId));
            }

            return await Context.Pokemon
                .Include(p => p.Species)
                .Include(p => p.Moves)
                .FirstOrDefaultAsync(p => p.Id == pokemonId.Id);
        }
        public async Task<IEnumerable<Pokemon>> GetAsync()
        {
            return Mapper.Map<IEnumerable<Pokemon>>(await Context.Pokemon
                .Include(p => p.Species)
                .Include(p => p.Moves)
                .ToListAsync());
        }

        public async Task<Pokemon> InsertAsync(PokemonUpdateModel pokemon)
        {
            var pokemonEntity = Mapper.Map<Entities.Pokemon>(pokemon);
            Context.AttachRange(pokemonEntity.Moves);
            
            var result = await Context.AddAsync(pokemonEntity);

            await Context.SaveChangesAsync();

            return Mapper.Map<Pokemon>(result);
        }

        public async Task<Pokemon> UpdateAsync(PokemonUpdateModel pokemon)
        {
            var existing = await Get(pokemon);

            var result = Mapper.Map(pokemon, existing);
            Context.AttachRange(result.Moves);

            Context.Update(result);
            await Context.SaveChangesAsync();

            return Mapper.Map<Pokemon>(result);
        }

        public async Task<Pokemon> RemoveAsync(IPokemonIdentity pokemonId)
        {
            var result = await Get(pokemonId);
            Context.AttachRange(result.Moves);

            Context.Remove(result);
            await Context.SaveChangesAsync();

            return Mapper.Map<Pokemon>(result);
        }
    }
}