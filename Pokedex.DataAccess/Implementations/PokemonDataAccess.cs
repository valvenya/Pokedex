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
                .Include(p => p.Move1)
                .Include(p => p.Move2)
                .Include(p => p.Move3)
                .Include(p => p.Move4)
                .FirstOrDefaultAsync(p => p.Id == pokemonId.Id);
        }
        public async Task<IEnumerable<Pokemon>> GetAsync()
        {
            return Mapper.Map<IEnumerable<Pokemon>>(await Context.Pokemon
                .Include(p => p.Species)
                .Include(p => p.Move1)
                .Include(p => p.Move2)
                .Include(p => p.Move3)
                .Include(p => p.Move4)
                .ToListAsync());
        }

        public async Task<Pokemon> InsertAsync(PokemonUpdateModel pokemon)
        {
            var result = await Context.AddAsync(Mapper.Map<Entities.Pokemon>(pokemon));

            await Context.SaveChangesAsync();

            return Mapper.Map<Pokemon>(result);
        }

        public async Task<Pokemon> UpdateAsync(PokemonUpdateModel pokemon)
        {
            var existing = await Get(pokemon);

            var result = Mapper.Map(pokemon, existing);

            Context.Update(result);
            await Context.SaveChangesAsync();

            return Mapper.Map<Pokemon>(result);
        }

        public async Task<Pokemon> RemoveAsync(IPokemonIdentity pokemonId)
        {
            var result = await Get(pokemonId);

            Context.Remove(result);
            await Context.SaveChangesAsync();

            return Mapper.Map<Pokemon>(result);
        }
    }
}