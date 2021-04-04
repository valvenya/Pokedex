using System.Threading.Tasks;
using Pokedex.BLL.Contracts;
using Pokedex.DataAccess.Contracts;
using Pokedex.Domain;
using Pokedex.Domain.Models;

namespace Pokedex.BLL.Implementations
{
    public class MoveCreateService : IMoveCreateService
    {
        private IMoveDataAccess MoveDataAccess { get; }

        public MoveCreateService(IMoveDataAccess moveDataAccess)
        {
            MoveDataAccess = moveDataAccess;
        }
        
        public async Task<Move> InsertAsync(MoveUpdateModel move)
        {
            return await MoveDataAccess.InsertAsync(move);
        }
    }
}