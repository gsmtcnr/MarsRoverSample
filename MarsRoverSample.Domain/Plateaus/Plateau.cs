using MarsRoverSample.Domain.Positions;

namespace MarsRoverSample.Domain.Plateaus
{
    public class Plateau : BasePlateau, IPlateau
    {
        public Plateau(IPosition position) : base(position)
        {
        }
    }
}
