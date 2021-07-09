using MarsRoverSample.Domain.Rovers;

namespace MarsRoverSample.Domain.Directions
{
    public abstract class BaseDirection : IDirection
    {
        public abstract IDirection Right();
        public abstract IDirection Left();
        public abstract void Move(IRover rover);
    }
}
