using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Plateaus;
using MarsRoverSample.Domain.Rovers.Enums;

namespace MarsRoverSample.Domain.Rovers
{
    public abstract class BaseRover : IRover
    {
        public IPlateau Plateau { get; set; }
        public IDirection Direction { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }

        public virtual void ExecuteCommand(CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.L:
                    Direction.Left();
                    break;
                case CommandType.R:
                    Direction.Right();
                    break;
                case CommandType.M:
                    Direction.Move(this);
                    break;
            }
        }

        public virtual void SetCurrentX(int coordinate)
        {
            CurrentX = coordinate;
        }

        public virtual void SetCurrentY(int coordinate)
        {
            CurrentX = CurrentY;
        }
    }
}
