using System.ComponentModel.DataAnnotations;
using Pokedex.Domain;

namespace Pokedex.Client.Requests.Create
{
    public class MoveCreateDTO
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Type { get; set; }
        
        [Required]
        public int Power { get; set; }
        
        public int Accuracy { get; set; }
        
        public string Description { get; set; }
    }
}