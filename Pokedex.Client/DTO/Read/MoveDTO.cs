using System;
using Type = Pokedex.Domain.Type;

namespace Pokedex.Client.DTO.Read
{
    public class MoveDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Type { get; set; }
        
        public int Power { get; set; }
        
        public int Accuracy { get; set; }
        
        public string Description { get; set; }
    }
}