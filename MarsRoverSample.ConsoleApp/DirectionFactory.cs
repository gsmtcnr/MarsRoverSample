using MarsRoverSample.Domain.Directions;

namespace MarsRoverSample.ConsoleApp
{
    public static class DirectionFactory
    {
        public static IDirection CreateDirection(string directionVal)
        {
            IDirection direction = null;
            switch (directionVal)
            {
                case "N":
                    direction = new NorthDirection();
                    break;
                case "E":
                    direction = new EastDirection();
                    break;
                case "W":
                    direction = new WestDirection();
                    break;
                case "S":
                    direction = new SouthDirection();
                    break;
            }
            return direction;
        }
    }
}
