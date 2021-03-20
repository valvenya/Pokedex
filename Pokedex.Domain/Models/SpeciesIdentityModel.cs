using Pokedex.Domain.Contracts;

namespace Pokedex.Domain.Models
{
    public class SpeciesIdentityModel : ISpeciesIdentity
    {
        public int Id { get; }

        public SpeciesIdentityModel(int id)
        {
            Id = id;
        }
    }
}