using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Plateaus;

namespace MarsRoverSample.Domain.Rovers.Inputs
{
    public class CreateInputModel
    {
        public string Name { get; set; }
        public IPlateau Plateau { get; set; }
        public IDirection Direction { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
    }
}
