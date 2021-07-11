using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Directions.Enums;
using MarsRoverSample.Domain.Rovers;
using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Infrastructure.Validations;
using Shouldly;
using Xunit;

namespace MarsRoverSample.UnitTests.Directions
{
    public class DirectionNorthUnitTests : BaseDirectionUnitTest
    {
        private readonly IRover _rover;

        public DirectionNorthUnitTests()
        {
            //Arrange
            _rover = CreateSeedRoverData(new NorthDirection());

        }
        #region Right
        [Fact]
        public void North_Direction_Turn_Right_Should_Be_Return_Success()
        {
            //Act

            IDirection direction = _rover.Direction.Right();

            //Assert

            direction.CurrentDirectionType.ShouldBe(DirectionType.E);

        }
        #endregion
        #region Left
        [Fact]
        public void North_Direction_Turn_Left_Should_Be_Return_Success()
        {

            //Act

            IDirection direction = _rover.Direction.Left();

            //Assert

            direction.CurrentDirectionType.ShouldBe(DirectionType.W);

        }
        #endregion
        #region Move
        [Fact]
        public void North_Direction_Move_Should_Be_Return_Success()
        {
            //Arrange

            int currentY = _rover.CurrentY;
            int roverY = currentY + 1;

            //Act

            IResult moveResult = _rover.Direction.Move(_rover);

            //Assert

            moveResult.IsSuccess.ShouldBeTrue();
            moveResult.ErrorMessages.ShouldBeNull();

            _rover.CurrentY.ShouldBe(roverY);


        }
        [Fact]
        public void North_Direction_Move_Should_Be_Return_Fail()
        {
            //Arrange

            _rover.SetCurrentY(_rover.Plateau.Position.UpperCoordinateForY);
            string expectedErrorMessage = string.Format(ValidationConstant.Rover_Coordinate_OverValue, _rover.Name, "Y");

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
