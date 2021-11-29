using System;
using System.Collections.Generic;
using ToyRobot.Commands;
using ToyRobot.Enums;

namespace ToyRobot
{
    public class CommandHandler
    {
        /// <summary>
        /// A map defines all the available commands, for auto choose command purpose
        /// </summary>
        private readonly Dictionary<CommandType, Func<string[],ICommand>> _commandMap;

        public CommandHandler(IMoveable moveable)
        {
            //initilize the command map
            _commandMap = new Dictionary<CommandType, Func<string [],ICommand>>()
            {
                {CommandType.MOVE, args => new MoveCommand(moveable) },
                {CommandType.LEFT, args => new LeftCommand(moveable) },
                {CommandType.RIGHT, args => new RightCommand(moveable) },
                {CommandType.PLACE, args => new PlaceCommand(moveable,args) },
                {CommandType.REPORT, args => new ReportCommand(moveable) }
            };
        }

        public void HandleCommand(string commandStr)
        {
            var comandStrArray = commandStr.Split(' ');

            if(Enum.TryParse(comandStrArray[0],true,out CommandType commandType))
            {
                //choose the command based on input string
                _commandMap[commandType].Invoke(comandStrArray.Length>1? comandStrArray[1].Split(','): Array.Empty<string>()).Execute();   
            }
            else
            {
                throw new FormatException("Invalid Command format,available commands:PLACE,MOVE,REPORT,LEFT,RIGHT");
            }

        }
    }
}
