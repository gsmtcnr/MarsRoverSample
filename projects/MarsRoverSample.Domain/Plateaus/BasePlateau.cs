using MarsRoverSample.Domain.Positions;

namespace MarsRoverSample.Domain.Plateaus
{
    public abstract class BasePlateau : IPlateau
    {
        public IPosition Position { get; protected set; }
    }
}
