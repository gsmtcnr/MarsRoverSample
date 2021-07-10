using MarsRoverSample.Domain.Directions.Enums;
using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Domain.Rovers;

namespace MarsRoverSample.Domain.Directions
{
    public interface IDirection
    {
        DirectionType CurrentDirectionType { get; }
        void SetCurrentDirectionType(DirectionType directionType);
        IDirection Left();
        IDirection Right();
        IResult Move(IRover rover);
    }
}
