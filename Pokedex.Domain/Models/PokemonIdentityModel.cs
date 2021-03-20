using Pokedex.Domain.Contracts;

namespace Pokedex.Domain.Models
{
    public class PokemonIdentityModel : IPokemonIdentity
    {
        public int Id { get; }

        public PokemonIdentityModel(int id)
        {
            Id = id;
        }
    }
}