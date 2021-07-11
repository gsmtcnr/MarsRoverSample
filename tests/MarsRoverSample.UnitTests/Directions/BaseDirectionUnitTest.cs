using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Plateaus;
using MarsRoverSample.Domain.Positions;
using MarsRoverSample.Domain.Rovers;
using System;

namespace MarsRoverSample.UnitTests.Directions
{
    public abstract class BaseDirectionUnitTest
    {
        public Rover CreateSeedRoverData(IDirection direction)
        {
            int xCoordinate = 1;
            int yCoordinate = 2;
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
    }
}
