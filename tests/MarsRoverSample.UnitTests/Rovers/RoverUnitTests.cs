using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Plateaus;
using MarsRoverSample.Domain.Positions;
using MarsRoverSample.Domain.Rovers;
using MarsRoverSample.Infrastructure.Validations;
using Shouldly;
using System;
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
    }
}
