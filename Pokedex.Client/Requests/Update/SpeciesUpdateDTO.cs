using Pokedex.Client.Requests.Create;

namespace Pokedex.Client.Requests.Update
{
    public class SpeciesUpdateDTO : SpeciesCreateDTO
    {
        public int Id { get; set; }
    }
}