using MarsRoverSample.Domain.Rovers;

namespace MarsRoverSample.Domain.Directions
{
    public class SouthDirection : BaseDirection, IDirection
    {
        public override IDirection Left()
        {
            return new EastDirection();
        }
        public override IDirection Right()
        {
            return new WestDirection();
        }
        public override void Move(IRover rover)
        {
            rover.SetCurrentY(rover.CurrentY--);
        }
    }
}
