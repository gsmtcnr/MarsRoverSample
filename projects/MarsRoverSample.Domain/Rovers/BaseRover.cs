using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Plateaus;
using MarsRoverSample.Domain.Rovers.Enums;
using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Infrastructure.Validations;
using System.Collections.Generic;

namespace MarsRoverSample.Domain.Rovers
{
    public abstract class BaseRover : IRover
    {
        #region Properties
        public string Name { get; set; }
        public IPlateau Plateau { get; set; }
        public IDirection Direction { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        #endregion

        #region Methods
        public IResult CoordinateControl()
        {
            var plateauPosition = Plateau.Position;
            //X control
            if (CurrentX > plateauPosition.UpperCoordinateForX)
            {
                return Result.Fail(string.Format(ValidationConstant.Rover_Coordinate_OverValue, Name, "X"));
            }

            if (CurrentX < plateauPosition.LowerCoordinateForX)
            {
                return Result.Fail(string.Format(ValidationConstant.Rover_Coordinate_LowValue, Name, "X"));
            }

            //Y control
            if (CurrentY > plateauPosition.UpperCoordinateForY)
            {
                return Result.Fail(string.Format(ValidationConstant.Rover_Coordinate_OverValue, Name, "Y"));
            }

            if (CurrentY < plateauPosition.LowerCoordinateForY)
            {
                return Result.Fail(string.Format(ValidationConstant.Rover_Coordinate_LowValue, Name, "Y"));
            }

            return Result.Success();
        }

        public virtual IResult ExecuteCommand(List<CommandType> commandTypes)
        {
            foreach (var commandType in commandTypes)
            {
                switch (commandType)
                {
                    case CommandType.L:
                        Direction = Direction.Left();
                        break;
                    case CommandType.R:
                        Direction = Direction.Right();
                        break;
                    case CommandType.M:
                        IResult moveResult = Direction.Move(this);
                        if (!moveResult.IsSuccess)
                        {
                            return Result.Fail(moveResult.ErrorMessages);
                        }
                        break;
                }
            }
            return Result.Success();
        }

        public string ReportLocation()
        {
            return string.Format(RoverConstant.Report_Format, Name, CurrentX, CurrentY, Direction.CurrentDirectionType);
        }

        public virtual void SetCurrentX(int coordinate)
        {
            CurrentX = coordinate;
        }

        public virtual void SetCurrentY(int coordinate)
        {
            CurrentY = coordinate;
        }

        #endregion
    }
}
