using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaProjectMars
{
    public class MarsRover : IRover
    {
        private CardinalSystem Position { get; set; }
        private List<char> CurrentOrder { get; set; }
        private GeographicDirection Direction { get; set; }
        private SurfaceArea Area { get; set; }

        public MarsRover(RoverPositionMessage roverPositionMessage, string orderInfo, SurfaceArea area)
        {
            Position = roverPositionMessage.Position;
            Direction = roverPositionMessage.Direction;
            ReadOrder(orderInfo);
            Area = area;
        }
        public MarsRover(CardinalSystem position, GeographicDirection direction, SurfaceArea area)
        {
            Position = position;
            Direction = direction;
            Area = area;
        }

        internal CardinalSystem SetPosition(string positionInfo)
        {
            return new CardinalSystem(Int32.Parse(positionInfo[0].ToString()), Int32.Parse(positionInfo[2].ToString()));
        }
        
        public void ReadOrder(string order)
        {
            CurrentOrder = new List<char>();
            CurrentOrder.AddRange(order);

        }
        public void ExecuteOrder()
        {
            while (CurrentOrder != null && CurrentOrder.Count >0)
            {
                if(CurrentOrder[0] == 'R' || CurrentOrder[0] == 'L')
                {
                    Turn(CurrentOrder[0]);
                }
                else
                {
                    Move();
                }
                CurrentOrder.RemoveAt(0);
            }
            CurrentOrder = null;
        }
        public void Move()
        {
            if(Direction == GeographicDirection.N) {
                if(IsInArea(new CardinalSystem(Position.X, Position.Y + 1)))
                {
                    Position.Y++;
                }
            }
            else if (Direction == GeographicDirection.E) {
                if (IsInArea(new CardinalSystem(Position.X + 1, Position.Y)))
                {
                    Position.X++;
                }
            }
            else if (Direction == GeographicDirection.S) {
                if (IsInArea(new CardinalSystem(Position.X, Position.Y-1)))
                {
                    Position.Y--;
                }
            }
            else {
                if (IsInArea(new CardinalSystem(Position.X - 1 , Position.Y)))
                {
                    Position.X--;
                }
            }
        }
        public void Turn(char rotation)
        {
            if (rotation == 'R')
            {
                if (Direction == GeographicDirection.W)
                    Direction = GeographicDirection.N;
                else
                    Direction++;
            }
            else
            {
                if (Direction == GeographicDirection.N)
                    Direction = GeographicDirection.W;
                else
                    Direction--;
            }
        }
        private bool IsInArea(CardinalSystem newPosition)
        {
            if (newPosition.X <= Area.LimitPoint.X && newPosition.X >= Area.StartPoint.X)
            {
                if (newPosition.Y <= Area.LimitPoint.Y && newPosition.Y >= Area.StartPoint.Y)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
                
        }

        
        public GeographicDirection GetRoverDirection()
        {
            return Direction;
        }
        public CardinalSystem GetRoverPosition()
        {
            return Position;
        }
    }
    
}
