using Pokedex.Domain.Contracts;

namespace Pokedex.Domain.Models
{
    public class MoveIdentityModel : IMoveIdentity
    {
        public int Id { get; }

        public MoveIdentityModel(int id)
        {
            Id = id;
        }
    }
}