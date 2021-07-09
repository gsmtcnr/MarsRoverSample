using MarsRoverSample.Domain.Rovers;

namespace MarsRoverSample.Domain.Directions
{
    public class NorthDirection : BaseDirection, IDirection
    {
        public override IDirection Left()
        {
            return new EastDirection();
        }
        public override IDirection Right()
        {
            return new EastDirection();
        }
        public override void Move(IRover rover)
        {
            rover.SetCurrentY(rover.CurrentY++);
        }
    }
}
