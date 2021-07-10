using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Directions.Enums;
using MarsRoverSample.Domain.Plateaus;
using MarsRoverSample.Domain.Positions;
using MarsRoverSample.Domain.Rovers;
using MarsRoverSample.Infrastructure.Results;
using Shouldly;
using System;
using Xunit;

namespace MarsRoverSample.UnitTests
{
    public class DirectionUnitTests
    {
        #region Seed_Data

        private static Rover Rover_Seed_Data()
        {
            int xCoordinate = 1;
            int yCoordinate = 2;
            IDirection direction = new EastDirection();
            var plateauResult = Plateau.Create(new Position(0, 0, 5, 5));

            var roverResult = Rover.Create(new Domain.Rovers.Inputs.CreateInputModel
            {
                CoordinateX = xCoordinate,
                CoordinateY = yCoordinate,
                Direction = direction,
                Name = Guid.NewGuid().ToString(),
                Plateau = plateauResult.Data
            });

            Rover rover = roverResult.Data;
            return rover;
        }

        #endregion

        #region East 
        #region Right
        [Fact]
        public void East_Direction_Turn_Right_Should_Be_Return_Success()
        {
            //Arrange

            var rover = Rover_Seed_Data();

            //Act

            IDirection direction = rover.Direction.Right();

            //Assert

            direction.CurrentDirectionType.ShouldBe(DirectionType.S);

        }
        #endregion
        #region Left
        [Fact]
        public void East_Direction_Turn_Left_Should_Be_Return_Success()
        {
            //Arrange

            var rover = Rover_Seed_Data();

            //Act

            IDirection direction = rover.Direction.Left();

            //Assert

            direction.CurrentDirectionType.ShouldBe(DirectionType.N);

        }
        #endregion
        #region Move
        [Fact]
        public void East_Direction_Move_Should_Be_Return_Success()
        {
            //Arrange

            var rover = Rover_Seed_Data();
            int currentX = rover.CurrentX;
            int roverX = currentX + 1;

            //Act

            IResult moveResult = rover.Direction.Move(rover);

            //Assert

            moveResult.IsSuccess.ShouldBeTrue();
            moveResult.ErrorMessages.ShouldBeNull();

            rover.CurrentX.ShouldBe(roverX);
           

        }
        [Fact]
        public void East_Direction_Move_Should_Be_Return_Fail()
        {
            //Arrange

            var rover = Rover_Seed_Data();
            int currentX = rover.CurrentX;
            int roverX = currentX + 2;

            //Act

            IResult moveResult = rover.Direction.Move(rover);

            //Assert

            moveResult.IsSuccess.ShouldBeTrue();
            moveResult.ErrorMessages.ShouldBeNull();
            rover.CurrentX.ShouldNotBe(roverX);

        }
        #endregion
        #endregion

    }
}
