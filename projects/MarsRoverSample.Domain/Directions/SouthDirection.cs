using MarsRoverSample.Domain.Rovers;

namespace MarsRoverSample.Domain.Directions
{
    public class SouthDirection : BaseDirection, IDirection
    {
        public SouthDirection()
        {
            SetCurrentDirectionType(Enums.DirectionType.S);
        }
        public override IDirection Left()
        {
            return new EastDirection();
        }
        public override IDirection Right()
        {
            return new WestDirection();
        }
        public override void MoveOn(IRover rover)
        {
            rover.SetCurrentY(rover.CurrentY - 1);
        }
    }
}
