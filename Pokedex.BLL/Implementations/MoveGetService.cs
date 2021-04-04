using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokedex.BLL.Contracts;
using Pokedex.DataAccess.Contracts;
using Pokedex.Domain;
using Pokedex.Domain.Contracts;

namespace Pokedex.BLL.Implementations
{
    public class MoveGetService : IMoveGetService
    {
        private IMoveDataAccess MoveDataAccess { get; }

        public MoveGetService(IMoveDataAccess moveDataAccess)
        {
            MoveDataAccess = moveDataAccess;
        }


        public async Task<Move> GetAsync(IMoveIdentity moveId)
        {
            return await MoveDataAccess.GetAsync(moveId);
        }

        public async Task<IEnumerable<Move>> GetAsync()
        {
            return await MoveDataAccess.GetAsync();
        }

        public async Task ValidateAsync(IMovesContainer movesContainer)
        {
            if (movesContainer == null)
            {
                throw new ArgumentNullException(nameof(movesContainer));
            }

            var moves = await GetAsync();
            
            if (!movesContainer.MoveIds.All(id => moves.Any(move => move.Id == id)))
            {
                throw new InvalidOperationException("Moves not found");
            }
        }
        
    }
}