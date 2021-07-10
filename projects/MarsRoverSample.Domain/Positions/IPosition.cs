namespace MarsRoverSample.Domain.Positions
{
    public interface IPosition
    {
        /// <summary>
        /// X alt sınır koordinatı
        /// </summary>
        int LowerCoordinateForX { get; }
        /// <summary>
        /// Y alt sınır koordinatı
        /// </summary>
        int LowerCoordinateForY { get; }
        /// <summary>
        /// X üst sınır koordinatı
        /// </summary>
        int UpperCoordinateForX { get; }
        /// <summary>
        /// Y
        /// </summary>
        int UpperCoordinateForY { get; }
        string ReportLocation();
    }

}
