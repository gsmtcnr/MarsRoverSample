using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Plateaus;
using MarsRoverSample.Domain.Rovers.Enums;

namespace MarsRoverSample.Domain.Rovers
{
    public interface IRover
    {
        #region Properties
        IPlateau Plateau { get; set; }
        IDirection Direction { get; set; }
        public void SetCurrentX(int coordinate);
        public int CurrentX { get; set; }
        public void SetCurrentY(int coordinate);
        public int CurrentY { get; set; }
        #endregion

        #region Methods
        void ExecuteCommand(CommandType commandType);
        #endregion
    }
}
