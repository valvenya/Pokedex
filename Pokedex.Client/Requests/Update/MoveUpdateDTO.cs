using Pokedex.Client.Requests.Create;

namespace Pokedex.Client.Requests.Update
{
    public class MoveUpdateDTO : MoveCreateDTO
    {
        public int Id { get; set; }
    }
}