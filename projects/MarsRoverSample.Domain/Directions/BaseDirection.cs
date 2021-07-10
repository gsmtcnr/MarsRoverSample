using MarsRoverSample.Domain.Directions.Enums;
using MarsRoverSample.Domain.Results;
using MarsRoverSample.Domain.Rovers;

namespace MarsRoverSample.Domain.Directions
{
    public abstract class BaseDirection : IDirection
    {
        public DirectionType CurrentDirectionType { get; private set; }
        public virtual void SetCurrentDirectionType(DirectionType directionType)
        {
            CurrentDirectionType = directionType;
        }
        public abstract IDirection Right();
        public abstract IDirection Left();
        public abstract void MoveOn(IRover rover);
        public virtual IResult Move(IRover rover)
        {
            //Template Method..
            MoveOn(rover);

            return rover.CoordinateControl();
        }
    }
}
