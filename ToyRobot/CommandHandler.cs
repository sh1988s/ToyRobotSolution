using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Commands;
using ToyRobot.Enums;

namespace ToyRobot
{
    public class CommandHandler
    {

        private IMoveable _moveable;
        public CommandHandler(IMoveable moveable)
        {
            _moveable = moveable;
        }

        public void HandleCommand(string commandStr)
        {
            var comandStrArray = commandStr.Split(' ');

            if(Enum.TryParse(comandStrArray[0],true,out CommandType commandType))
            {
                switch (commandType)
                {
                    case CommandType.PLACE:
                        new PlaceCommand(_moveable, comandStrArray[1].Split(',')).Execute();
                        break;
                    case CommandType.MOVE:
                        new MoveCommand(_moveable).Execute();
                        break;
                    case CommandType.REPORT:
                        new ReportCommand(_moveable).Execute();
                        break;
                    case CommandType.LEFT:
                        new LeftCommand(_moveable).Execute();
                        break;
                    case CommandType.RIGHT:
                        new RightCommand(_moveable).Execute();
                        break;
                }
            }
            else
            {
                throw new InvalidCastException("Invalid Command,available commands:PLACE,MOVE,REPORT,LEFT,RIGHT");
            }

        }
    }
}
