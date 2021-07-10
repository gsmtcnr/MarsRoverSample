namespace MarsRoverSample.Domain.Positions
{
    public class Position : BasePosition, IPosition
    {
        public Position(int lowerCoordinateForX, int lowerCoordinateForY, int upperCoordinateForX, int upperCoordinateForY) : base(lowerCoordinateForX, lowerCoordinateForY, upperCoordinateForX, upperCoordinateForY)
        {
        }
    }
}
