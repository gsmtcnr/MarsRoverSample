using MarsRoverSample.Domain.Rovers;

namespace MarsRoverSample.Domain.Directions
{
    public interface IDirection
    {
        IDirection Left();
        IDirection Right();
        void Move(IRover rover);
    }
}
