using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Directions.Enums;
using MarsRoverSample.Domain.Rovers;
using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Infrastructure.Validations;
using Shouldly;
using Xunit;

namespace MarsRoverSample.UnitTests.Directions
{
    public class DirectionSouthUnitTests : BaseDirectionUnitTest
    {
        private readonly IRover _rover;

        public DirectionSouthUnitTests()
        {
            //Arrange
            _rover = CreateSeedRoverData(new SouthDirection());

        }
        #region Right
        [Fact]
        public void South_Direction_Turn_Right_Should_Be_Return_Success()
        { 
            //Act

            IDirection direction = _rover.Direction.Right();

            //Assert

            direction.CurrentDirectionType.ShouldBe(DirectionType.W);

        }
        #endregion
        #region Left
        [Fact]
        public void South_Direction_Turn_Left_Should_Be_Return_Success()
        {

            //Act

            IDirection direction = _rover.Direction.Left();

            //Assert

            direction.CurrentDirectionType.ShouldBe(DirectionType.E);

        }
        #endregion
        #region Move
        [Fact]
        public void South_Direction_Move_Should_Be_Return_Success()
        {
            //Arrange
            int currentY = _rover.CurrentY;
            int roverY = currentY - 1;

            //Act

            IResult moveResult = _rover.Direction.Move(_rover);

            //Assert

            moveResult.IsSuccess.ShouldBeTrue();
            moveResult.ErrorMessages.ShouldBeNull();

            _rover.CurrentY.ShouldBe(roverY);


        }
        [Fact]
        public void South_Direction_Move_Should_Be_Return_Fail()
        {
            //Arrange
            _rover.SetCurrentY(_rover.Plateau.Position.LowerCoordinateForY);
            string expectedErrorMessage = string.Format(ValidationConstant.Rover_Coordinate_LowValue, _rover.Name, "Y");

            //Act

            IResult moveResult = _rover.Direction.Move(_rover);

            //Assert

            moveResult.IsSuccess.ShouldBeFalse();
            moveResult.ErrorMessages.ShouldNotBeNull();
            moveResult.ErrorMessages.Contains(expectedErrorMessage).ShouldBeTrue();

        }
        #endregion
    }
}
