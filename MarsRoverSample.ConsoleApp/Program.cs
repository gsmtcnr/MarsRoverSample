using MarsRoverSample.Domain.Directions;
using MarsRoverSample.Domain.Plateaus;
using MarsRoverSample.Domain.Positions;
using MarsRoverSample.Domain.Results;
using MarsRoverSample.Domain.Rovers;
using MarsRoverSample.Domain.Rovers.Enums;
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
                                //1 2 N
                                var roverInformation = line.Split(' ');
                                int x = Convert.ToInt32(roverInformation[0]);
                                int y = Convert.ToInt32(roverInformation[1]);
                                IDirection direction = CreateDirection(roverInformation[2]);
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
                                    var commandTypes = CreateCommandTypes(line);
                                    rover.ExecuteCommand(commandTypes);
                                    Console.WriteLine(rover.ReportLocation());
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
























            //Input 5 5
            //var plateauResult = Plateau.Create(new Position(0, 0, 5, 5));

            //if (plateauResult.IsSuccess)
            //{
            //    var plateau = plateauResult.Data;

            //    var firstRoverResult = Rover.Create(new Domain.Rovers.Inputs.CreateInputModel
            //    {
            //        Name = "Elon Musk",
            //        CoordinateX = 1,
            //        CoordinateY = 2,
            //        Direction = new NorthDirection(),
            //        Plateau = plateau
            //    });

            //    var secondRoverResult = Rover.Create(new Domain.Rovers.Inputs.CreateInputModel
            //    {
            //        Name = "Bill Gates",
            //        CoordinateX = 3,
            //        CoordinateY = 3,
            //        Direction = new EastDirection(),
            //        Plateau = plateau
            //    });

            //    if (firstRoverResult.IsSuccess && secondRoverResult.IsSuccess)
            //    {
            //        var firstRover = firstRoverResult.Data;

            //        firstRover.ExecuteCommand(new List<Domain.Rovers.Enums.CommandType>
            //        {
            //             Domain.Rovers.Enums.CommandType.L,
            //             Domain.Rovers.Enums.CommandType.M,
            //             Domain.Rovers.Enums.CommandType.L,
            //             Domain.Rovers.Enums.CommandType.M,
            //             Domain.Rovers.Enums.CommandType.L,
            //             Domain.Rovers.Enums.CommandType.M,
            //             Domain.Rovers.Enums.CommandType.L,
            //             Domain.Rovers.Enums.CommandType.M,
            //             Domain.Rovers.Enums.CommandType.M
            //        });



            //        var secondRever = secondRoverResult.Data;
            //        secondRever.ExecuteCommand(new List<Domain.Rovers.Enums.CommandType> {

            //            Domain.Rovers.Enums.CommandType.M,
            //            Domain.Rovers.Enums.CommandType.M,
            //            Domain.Rovers.Enums.CommandType.R,
            //            Domain.Rovers.Enums.CommandType.M,
            //            Domain.Rovers.Enums.CommandType.M,
            //            Domain.Rovers.Enums.CommandType.R,
            //            Domain.Rovers.Enums.CommandType.M,
            //            Domain.Rovers.Enums.CommandType.R,
            //            Domain.Rovers.Enums.CommandType.R,
            //            Domain.Rovers.Enums.CommandType.M

            //        });

            //        Console.WriteLine(firstRover.ReportLocation());
            //        Console.WriteLine(secondRever.ReportLocation());

            //    }
            //    else
            //    {
            //        HandleErrorMessages(firstRoverResult.ErrorMessages);
            //        HandleErrorMessages(secondRoverResult.ErrorMessages);
            //    }
            //}
            //else
            //{
            //    HandleErrorMessages(plateauResult.ErrorMessages);
            //}


            Console.ReadLine();
        }

        private static List<CommandType> CreateCommandTypes(string line)
        {
            List<CommandType> commandTypes = new List<CommandType>();
            foreach (var command in line)
            {
                switch (command)
                {
                    case 'M':
                        commandTypes.Add(CommandType.M);
                        break;
                    case 'R':
                        commandTypes.Add(CommandType.R);
                        break;
                    case 'L':
                        commandTypes.Add(CommandType.L);
                        break;
                }
            }
            return commandTypes;
        }

        private static IDirection CreateDirection(string directionVal)
        {
            IDirection direction = null;
            switch (directionVal)
            {
                case "N":
                    direction = new NorthDirection();
                    break;
                case "E":
                    direction = new EastDirection();
                    break;
                case "W":
                    direction = new WestDirection();
                    break;
                case "S":
                    direction = new SouthDirection();
                    break;
            }
            return direction;
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
