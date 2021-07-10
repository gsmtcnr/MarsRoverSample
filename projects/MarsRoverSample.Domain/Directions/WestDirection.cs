using MarsRoverSample.Domain.Rovers;

namespace MarsRoverSample.Domain.Directions
{
    public class WestDirection : BaseDirection, IDirection
    {
        public WestDirection()
        {
            SetCurrentDirectionType(Enums.DirectionType.W);
        }
        public override IDirection Left()
        {
            return new SouthDirection();
        }
        public override IDirection Right()
        {
            return new NorthDirection();
        }
        public override void MoveOn(IRover rover)
        {
            rover.SetCurrentX(rover.CurrentX - 1);
        }
    }
}
