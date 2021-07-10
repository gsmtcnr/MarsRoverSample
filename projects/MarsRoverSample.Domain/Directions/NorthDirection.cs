using MarsRoverSample.Domain.Rovers;

namespace MarsRoverSample.Domain.Directions
{
    public class NorthDirection : BaseDirection, IDirection
    {
        public NorthDirection()
        {
            SetCurrentDirectionType(Enums.DirectionType.N);
        }
        public override IDirection Left()
        {
            return new WestDirection();
        }
        public override IDirection Right()
        {
            return new EastDirection();
        }
        public override void MoveOn(IRover rover)
        {
            rover.SetCurrentY(rover.CurrentY + 1);
        }
    }
}
