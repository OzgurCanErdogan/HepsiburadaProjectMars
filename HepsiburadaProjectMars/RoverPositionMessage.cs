namespace HepsiburadaProjectMars
{
    public class RoverPositionMessage
    {
        public CardinalSystem Position { get; set; }
        public GeographicDirection Direction { get; set; }
        public RoverPositionMessage(CardinalSystem position, GeographicDirection direction)
        {
            Position = position;
            Direction = direction;
        }
        
    }
}
