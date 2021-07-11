using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Directions.Enums;
using MarsRoverSample.Domain.Plateaus;
using MarsRoverSample.Domain.Positions;
using MarsRoverSample.Domain.Rovers;
using MarsRoverSample.Infrastructure.Validations;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace MarsRoverSample.UnitTests.Rovers
{
    public class RoverUnitTests
    {

        #region Create

        [Fact]
        public void Create_Should_Be_Return_Success()
        {
            //Arrange

            string name = Guid.NewGuid().ToString();
            int xCoordinate = 1;
            int yCoordinate = 2;
            var plateauResult = Plateau.Create(new Position(0, 0, 5, 5));
            var direction = new NorthDirection();

            //Act

            var roverResult = Rover.Create(new Domain.Rovers.Inputs.CreateInputModel
            {
                CoordinateX = xCoordinate,
                CoordinateY = yCoordinate,
                Direction = direction,
                Name = name,
                Plateau = plateauResult.Data
            });


            //Assert

            roverResult.IsSuccess.ShouldBeTrue();
            roverResult.ErrorMessages.ShouldBeNull();
            roverResult.Data.ShouldNotBeNull();
            roverResult.Data.Direction.CurrentDirectionType.ShouldBe(direction.CurrentDirectionType);
        }
        [Fact]
        public void Create_Should_Be_Return_Fail()
        {
            //Arrange

            string name = string.Empty;
            int xCoordinate = 1;
            int yCoordinate = 2;
            var plateauResult = Plateau.Create(new Position(0, 0, 5, 5));
            var direction = new NorthDirection();

            //Act

            var roverResult = Rover.Create(new Domain.Rovers.Inputs.CreateInputModel
            {
                CoordinateX = xCoordinate,
                CoordinateY = yCoordinate,
                Direction = direction,
                Name = name,
                Plateau = plateauResult.Data
            });


            //Assert

            roverResult.IsSuccess.ShouldBeFalse();
            roverResult.ErrorMessages.ShouldNotBeNull();
            roverResult.Data.ShouldBeNull();
            roverResult.ErrorMessages.Contains(ValidationConstant.Name_EmptyOrNull);
        }

        #endregion

        #region Report Location

        [Fact]
        public void Commands_After_ReportLocation_Should_Be_Return_Success()
        {

            //Arrange

            int exceptedX = 1;
            int exceptedY = 3;
            DirectionType expectedDirectionTye = DirectionType.N;


            int x = 1;
            int y = 2;
            var plateauResult = Plateau.Create(new Position(0, 0, 5, 5));
            var roverResult = Rover.Create(new Domain.Rovers.Inputs.CreateInputModel
            {
                Name = Guid.NewGuid().ToString(),
                CoordinateX = x,
                CoordinateY = y,
                Direction = new NorthDirection(),
                Plateau = plateauResult.Data
            });

            string expectedReportLocation = string.Format(RoverConstant.Report_Format, roverResult.Data.Name, exceptedX, exceptedY, expectedDirectionTye);

            var commandList = new List<Domain.Rovers.Enums.CommandType>
                    {
                         Domain.Rovers.Enums.CommandType.L,
                         Domain.Rovers.Enums.CommandType.M,
                         Domain.Rovers.Enums.CommandType.L,
                         Domain.Rovers.Enums.CommandType.M,
                         Domain.Rovers.Enums.CommandType.L,
                         Domain.Rovers.Enums.CommandType.M,
                         Domain.Rovers.Enums.CommandType.L,
                         Domain.Rovers.Enums.CommandType.M,
                         Domain.Rovers.Enums.CommandType.M
                    };

            //Act

            roverResult.Data.ExecuteCommand(commandList);
            string reportLocation = roverResult.Data.ReportLocation();

            //Assert

            roverResult.IsSuccess.ShouldBeTrue();
            roverResult.ErrorMessages.ShouldBeNull();
            reportLocation.ShouldBe(expectedReportLocation);

        }

        [Fact]
        public void Commands_After_ReportLocation_Should_Be_Return_Fail()
        {

            //Arrange

            int exceptedX = 1;
            int exceptedY = 3;
            DirectionType expectedDirectionTye = DirectionType.N;


            int x = 1;
            int y = 2;
            var plateauResult = Plateau.Create(new Position(0, 0, 5, 5));
            var roverResult = Rover.Create(new Domain.Rovers.Inputs.CreateInputModel
            {
                Name = Guid.NewGuid().ToString(),
                CoordinateX = x,
                CoordinateY = y,
                Direction = new SouthDirection(),
                Plateau = plateauResult.Data
            });

            string expectedReportLocation = string.Format(RoverConstant.Report_Format, roverResult.Data.Name, exceptedX, exceptedY, expectedDirectionTye);

            var commandList = new List<Domain.Rovers.Enums.CommandType>
                    {
                         Domain.Rovers.Enums.CommandType.L,
                         Domain.Rovers.Enums.CommandType.M,
                         Domain.Rovers.Enums.CommandType.L,
                         Domain.Rovers.Enums.CommandType.M,
                         Domain.Rovers.Enums.CommandType.L,
                         Domain.Rovers.Enums.CommandType.M,
                         Domain.Rovers.Enums.CommandType.L,
                         Domain.Rovers.Enums.CommandType.M,
                         Domain.Rovers.Enums.CommandType.M
                    };

            //Act

            roverResult.Data.ExecuteCommand(commandList);
            string reportLocation = roverResult.Data.ReportLocation();

            //Assert

            roverResult.IsSuccess.ShouldBeTrue();
            roverResult.ErrorMessages.ShouldBeNull();
    
            reportLocation.ShouldNotBe(expectedReportLocation);

        }
        #endregion
    }
}
