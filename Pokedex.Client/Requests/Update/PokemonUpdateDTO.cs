using Pokedex.Client.Requests.Create;

namespace Pokedex.Client.Requests.Update
{
    public class PokemonUpdateDTO : PokemonCreateDTO
    {
        public int Id { get; set; }
    }
}