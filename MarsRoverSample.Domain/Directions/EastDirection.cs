using MarsRoverSample.Domain.Rovers;

namespace MarsRoverSample.Domain.Directions
{
    public class EastDirection : BaseDirection, IDirection
    {
        public override IDirection Left()
        {
            return new SouthDirection();
        }
        public override IDirection Right()
        {
            return new NorthDirection();
        }
        public override void Move(IRover rover)
        {
            rover.SetCurrentX(rover.CurrentX++);
        }
    }
}
