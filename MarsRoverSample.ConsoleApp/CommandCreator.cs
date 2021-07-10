using MarsRoverSample.Domain.Rovers.Enums;
using System.Collections.Generic;

namespace MarsRoverSample.ConsoleApp
{
    public static class CommandTypeCreator
    {
        public static List<CommandType> CreateCommandTypes(string line)
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
    }
}
