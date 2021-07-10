using MarsRoverSample.Domain.Rovers;

namespace MarsRoverSample.Domain.Directions
{
    public class EastDirection : BaseDirection, IDirection
    {
        public EastDirection()
        {
            SetCurrentDirectionType(Enums.DirectionType.E);
        }
        public override IDirection Left()
        {
            return new NorthDirection();
        }
        public override IDirection Right()
        {
            return new SouthDirection();
        }
        public override void MoveOn(IRover rover)
        {
            rover.SetCurrentX(rover.CurrentX + 1);
        }
    }
}
