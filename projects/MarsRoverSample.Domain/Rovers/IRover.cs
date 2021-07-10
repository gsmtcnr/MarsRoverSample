using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Plateaus;
using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Domain.Rovers.Enums;
using System.Collections.Generic;

namespace MarsRoverSample.Domain.Rovers
{
    public interface IRover
    {
        #region Properties
        public string Name { get; set; }
        IPlateau Plateau { get; set; }
        IDirection Direction { get; set; }
        public void SetCurrentX(int coordinate);
        public int CurrentX { get; set; }
        public void SetCurrentY(int coordinate);
        public int CurrentY { get; set; }
        #endregion

        #region Methods
        IResult ExecuteCommand(List<CommandType> commandTypes);
        string ReportLocation();
        IResult CoordinateControl();
        #endregion
    }
}
