using System.Threading.Tasks;
using Pokedex.BLL.Contracts;
using Pokedex.DataAccess.Contracts;
using Pokedex.Domain;
using Pokedex.Domain.Models;

namespace Pokedex.BLL.Implementations
{
    public class MoveUpdateService : IMoveUpdateService
    {
        private IMoveDataAccess MoveDataAccess { get; }

        public MoveUpdateService(IMoveDataAccess moveDataAccess)
        {
            MoveDataAccess = moveDataAccess;
        }
        
        public async Task<Move> UpdateAsync(MoveUpdateModel move)
        {
            return await MoveDataAccess.UpdateAsync(move);
        }
    }
}