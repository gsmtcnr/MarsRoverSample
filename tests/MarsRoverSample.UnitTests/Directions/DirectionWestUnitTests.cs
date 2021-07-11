using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Directions.Enums;
using MarsRoverSample.Domain.Rovers;
using MarsRoverSample.Infrastructure.Results;
using MarsRoverSample.Infrastructure.Validations;
using Shouldly;
using Xunit;

namespace MarsRoverSample.UnitTests.Directions
{
    public class DirectionWestUnitTests : BaseDirectionUnitTest
    {
        private readonly IRover _rover;

        public DirectionWestUnitTests()
        {
            //Arrange
            _rover = CreateSeedRoverData(new WestDirection());

        }
        #region Right
        [Fact]
        public void West_Direction_Turn_Right_Should_Be_Return_Success()
        {
            //Act

            IDirection direction = _rover.Direction.Right();

            //Assert

            direction.CurrentDirectionType.ShouldBe(DirectionType.N);

        }
        #endregion
        #region Left
        [Fact]
        public void West_Direction_Turn_Left_Should_Be_Return_Success()
        {

            //Act

            IDirection direction = _rover.Direction.Left();

            //Assert

            direction.CurrentDirectionType.ShouldBe(DirectionType.S);

        }
        #endregion
        #region Move
        [Fact]
        public void West_Direction_Move_Should_Be_Return_Success()
        {
            //Arrange

            int currentX = _rover.CurrentX;
            int roverX = currentX - 1;

            //Act

            IResult moveResult = _rover.Direction.Move(_rover);

            //Assert

            moveResult.IsSuccess.ShouldBeTrue();
            moveResult.ErrorMessages.ShouldBeNull();

            _rover.CurrentX.ShouldBe(roverX);


        }
        [Fact]
        public void West_Direction_Move_Should_Be_Return_Fail()
        {
            //Arrange

            _rover.SetCurrentX(_rover.Plateau.Position.LowerCoordinateForX);
            string expectedErrorMessage = string.Format(ValidationConstant.Rover_Coordinate_LowValue, _rover.Name, "X");
            
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
