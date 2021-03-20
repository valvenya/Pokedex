namespace Pokedex.Domain
{
    public class Move
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Type Type { get; set; }
        
        public int Power { get; set; }
        
        public int Accuracy { get; set; }
        
        public string Description { get; set; }
    }
}