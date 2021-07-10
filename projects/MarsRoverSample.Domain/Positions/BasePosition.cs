using System.Text;

namespace MarsRoverSample.Domain.Positions
{
    public abstract class BasePosition : IPosition
    {
        public BasePosition(int lowerCoordinateForX, int lowerCoordinateForY, 
            int upperCoordinateForX, int upperCoordinateForY)
        {
            LowerCoordinateForX = lowerCoordinateForX;
            LowerCoordinateForY = lowerCoordinateForY;
            UpperCoordinateForX = upperCoordinateForX;
            UpperCoordinateForY = upperCoordinateForY;
        }
        public int LowerCoordinateForX { get;  private set; }
        public int LowerCoordinateForY { get; private set; }
        public int UpperCoordinateForX { get; private set; }
        public int UpperCoordinateForY { get; private set; }

        public virtual string ReportLocation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Upper X Coordinate : " + UpperCoordinateForX);
            stringBuilder.AppendLine("Lower X Coordinate : " + LowerCoordinateForX);
            stringBuilder.AppendLine("Upper Y Coordinate : " + UpperCoordinateForY);
            stringBuilder.AppendLine("Lower Y Coordinate : " + LowerCoordinateForY);
            return stringBuilder.ToString();
        }
    }

}
