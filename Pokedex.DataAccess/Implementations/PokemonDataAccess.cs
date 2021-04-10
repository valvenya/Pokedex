using System;
using System.Collections.Generic;
using System.Linq;
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
            
            var moves = Context.Move.Where(m => pokemon.MoveIds.Contains(m.Id)).ToList();
            foreach (var move in moves)
            {
                pokemonEntity.Moves.Add(move);
            }
            
            var result = await Context.AddAsync(pokemonEntity);

            await Context.SaveChangesAsync();

            return Mapper.Map<Pokemon>(result.Entity);
        }

        public async Task<Pokemon> UpdateAsync(PokemonUpdateModel pokemon)
        {
            var existing = await Get(pokemon);

            var result = Mapper.Map(pokemon, existing);
            
            result.Moves.Clear();
            var moves = Context.Move.Where(m => pokemon.MoveIds.Contains(m.Id)).ToList();
            foreach (var move in moves)
            {
                result.Moves.Add(move);
            }

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