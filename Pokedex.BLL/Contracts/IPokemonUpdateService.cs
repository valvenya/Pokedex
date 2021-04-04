using System.Threading.Tasks;
using Pokedex.Domain;
using Pokedex.Domain.Models;

namespace Pokedex.BLL.Contracts
{
    public interface IPokemonUpdateService
    {
        Task<Pokemon> UpdateAsync(PokemonUpdateModel pokemon);
    }
}