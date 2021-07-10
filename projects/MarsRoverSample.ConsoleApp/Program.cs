using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Plateaus;
using MarsRoverSample.Domain.Positions;
using MarsRoverSample.Domain.Rovers;
using MarsRoverSample.Domain.Rovers.Enums;
using MarsRoverSample.Infrastructure.Results;
using System;
using System.Collections.Generic;
using System.IO;

namespace MarsRoverSample.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mars Rover !");

            using (var streamReader = File.OpenText("ProcessInput.txt"))
            {
                var line = streamReader.ReadLine();

                if (line != null)
                {
                    var plateauCoordinateXY = line.Split(' ');
                    int xCoordinate = Convert.ToInt32(plateauCoordinateXY[0]);
                    int yCoordinate = Convert.ToInt32(plateauCoordinateXY[1]);
                    var plateauResult = Plateau.Create(new Position(0, 0, xCoordinate, yCoordinate));
                    if (plateauResult.IsSuccess)
                    {
                        int count = 0;
                        IResult<Rover> roverResult = null;

                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (count % 2 == 0)
                            {
                                var roverInformation = line.Split(' ');
                                int x = Convert.ToInt32(roverInformation[0]);
                                int y = Convert.ToInt32(roverInformation[1]);
                                IDirection direction = DirectionFactory.CreateDirection(roverInformation[2]);
                                roverResult = Rover.Create(new Domain.Rovers.Inputs.CreateInputModel
                                {
                                    Name = Guid.NewGuid().ToString(),
                                    CoordinateX = x,
                                    CoordinateY = y,
                                    Direction = direction,
                                    Plateau = plateauResult.Data
                                });

                            }
                            else
                            {
                                if (roverResult.IsSuccess)
                                {
                                    var rover = roverResult.Data;                    
                                    var commandTypes = CommandTypeCreator.CreateCommandTypes(line);
                                    var executeResult = rover.ExecuteCommand(commandTypes);
                                    if (executeResult.IsSuccess)
                                    {
                                        Console.WriteLine(rover.ReportLocation());
                                    }
                                    else
                                    {
                                        HandleErrorMessages(executeResult.ErrorMessages);
                                    }
                                }
                                else
                                {
                                    HandleErrorMessages(roverResult.ErrorMessages);
                                }
                            }

                            count++;
                        }
                    }
                    else
                    {
                        HandleErrorMessages(plateauResult.ErrorMessages);
                    }
                }
            }

            Console.ReadLine();
        }
        private static void HandleErrorMessages(List<string> messages)
        {
            Console.WriteLine("Error Messages : ");
            foreach (var item in messages)
            {
                Console.WriteLine(item);
            }
        }
    }
}
