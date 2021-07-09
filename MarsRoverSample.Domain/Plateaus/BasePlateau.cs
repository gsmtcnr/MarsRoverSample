using MarsRoverSample.Domain.Positions;

namespace MarsRoverSample.Domain.Plateaus
{
    public abstract class BasePlateau : IPlateau
    {
        public BasePlateau(IPosition position)
        {
            Position = position;
        }
        public IPosition Position { get; private set; }
    }
}
