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
    public class MoveDataAccess : IMoveDataAccess
    {
        private PokedexContext Context { get; }
        private IMapper Mapper { get; }
        
        public MoveDataAccess(PokedexContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        
        public async Task<Move> GetAsync(IMoveIdentity moveId)
        {
            return Mapper.Map<Move>(await Get(moveId));
        }

        private async Task<Entities.Move> Get(IMoveIdentity moveId)
        {
            if (moveId == null)
            {
                throw new ArgumentNullException(nameof(moveId));
            }
            
            return await Context.Move
                .FirstOrDefaultAsync(m => m.Id == moveId.Id);
        }

        public async Task<IEnumerable<Move>> GetAsync()
        {
            return Mapper.Map<IEnumerable<Move>>(await Context.Move.ToListAsync());
        }

        public async Task<Move> InsertAsync(MoveUpdateModel move)
        {
            var result = await Context.AddAsync(Mapper.Map<Entities.Move>(move));

            await Context.SaveChangesAsync();

            return Mapper.Map<Move>(result.Entity);
        }

        public async Task<Move> UpdateAsync(MoveUpdateModel move)
        {
            var existing = await Get(move);

            var result = Mapper.Map(move, existing);

            Context.Update(result);

            await Context.SaveChangesAsync();

            return Mapper.Map<Move>(result);
        }
        
    }
}