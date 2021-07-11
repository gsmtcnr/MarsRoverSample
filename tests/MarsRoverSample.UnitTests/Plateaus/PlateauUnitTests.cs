using MarsRoverSample.Domain.Plateaus;
using MarsRoverSample.Domain.Positions;
using Shouldly;
using Xunit;

namespace MarsRoverSample.UnitTests.Plateaus
{

    public class PlateauUnitTests
    {
        [Fact]
        public void Create_Should_Be_Return_Success()
        {
            //Arrange

            int lowerCoordinateForX = 0;
            int lowerCoordinateForY = 0;
            int upperCoordinateForX = 5;
            int upperCoordinateForY = 5;

            //Act

            var plateauResult = Plateau.Create(new Position(lowerCoordinateForX, lowerCoordinateForY, upperCoordinateForX, upperCoordinateForY));

            //Assert

            plateauResult.IsSuccess.ShouldBeTrue();
            plateauResult.ErrorMessages.ShouldBeNull();
            plateauResult.Data.Position.LowerCoordinateForX.ShouldBe(lowerCoordinateForX);
            plateauResult.Data.Position.LowerCoordinateForY.ShouldBe(lowerCoordinateForY);
            plateauResult.Data.Position.UpperCoordinateForX.ShouldBe(upperCoordinateForX);
            plateauResult.Data.Position.UpperCoordinateForY.ShouldBe(upperCoordinateForY);

        }

        [Fact]
        public void Create_Should_Be_Return_Fail()
        {

            //Act

            var plateauResult = Plateau.Create(null);

            //Assert

            plateauResult.IsSuccess.ShouldBeFalse();
            plateauResult.ErrorMessages.ShouldNotBeNull();

        }
    }
}
